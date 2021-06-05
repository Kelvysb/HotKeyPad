using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace HotKeyPad
{
    internal class HotKeyPadService
    {
        private const int BLOCK_SIZE = 85;
        private const int TIMEOUT = 5000;

        private string PresetFolder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HotKeyPad");
        private SerialPort _serialPort;

        public HotKeyPadService()
        {
            if (!Directory.Exists(PresetFolder))
            {
                Directory.CreateDirectory(PresetFolder);
            }
        }

        public string LastDataReceived { get; set; }

        public string SearchDevice()
        {
            var ports = SerialPort.GetPortNames();

            foreach (var port in ports)
            {
                try
                {
                    _serialPort = new SerialPort(port);
                    _serialPort.BaudRate = 9600;
                    _serialPort.Parity = Parity.None;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.DataBits = 8;
                    _serialPort.Handshake = Handshake.None;
                    _serialPort.RtsEnable = true;
                    _serialPort.Open();
                    _serialPort.DiscardInBuffer();
                    _serialPort.WriteLine("A\n");
                    var result = Encoding.ASCII.GetString(WaitResponse().ToArray());
                    if (!string.IsNullOrEmpty(result) && result.StartsWith("HOTKEYPAD"))
                    {
                        return $"{result.Replace("\r\n", "")} on {_serialPort.PortName}";
                    }
                }
                catch
                {
                    if (_serialPort != null)
                    {
                        _serialPort.Close();
                        _serialPort.Dispose();
                        _serialPort = null;
                    }
                }
            }

            return "No device found.";
        }

        public bool SetCommand(Command command)
        {
            if (_serialPort == null) throw new System.Exception("No device connected");
            if (!_serialPort.IsOpen) _serialPort.Open();

            byte[] buffer = new byte[BLOCK_SIZE + 1];
            buffer[0] = (byte)'S';
            buffer[1] = (byte)(command.Position + 48);
            buffer[2] = (byte)(command.Mode == CommandMode.Hold ? '0' : '1');
            buffer[3] = (byte)command.HoldTime;
            buffer[4] = (byte)command.DelayTime;
            buffer[5] = (byte)(command.Ctrl ? '1' : '0');
            buffer[6] = (byte)(command.Alt ? '1' : '0');
            buffer[7] = (byte)(command.Shift ? '1' : '0');
            buffer[8] = (byte)(command.Gui ? '1' : '0');

            int index = 9;
            foreach (var key in command.Keys)
            {
                buffer[index] = (byte)key;
                index++;
            }

            _serialPort.DiscardInBuffer();
            _serialPort.Write(buffer, 0, BLOCK_SIZE);
            var result = WaitResponse();
            return Encoding.ASCII.GetString(result.ToArray()).StartsWith("OK");
        }

        public List<Command> ReadMemory()
        {
            if (_serialPort == null) throw new System.Exception("No device connected");
            if (!_serialPort.IsOpen) _serialPort.Open();
            var result = new List<Command>();

            _serialPort.DiscardInBuffer();
            _serialPort.WriteLine("R\n");
            var rawResult = WaitResponse();

            var commands =
                rawResult
                .Where(s => s != (byte)'\r')
                .Split(s => s == (byte)'\n')
                .ToList();

            foreach (var command in commands)
            {
                if (command.Any())
                {
                    var blocks = command.Split(s => s == (byte)':').ToList();
                    result.Add(new Command());
                    result.Last().Position = blocks[1][0] - 48;
                    var commandItens = blocks[2];
                    result.Last().Mode = commandItens[0] == '1' ? CommandMode.Sequence : CommandMode.Hold;
                    result.Last().HoldTime = commandItens[1] != 0 ? commandItens[1] : (byte)'0';
                    result.Last().DelayTime = commandItens[2] != 0 ? commandItens[2] : (byte)'0';
                    result.Last().Ctrl = commandItens[3] == '1';
                    result.Last().Alt = commandItens[4] == '1';
                    result.Last().Shift = commandItens[5] == '1';
                    result.Last().Gui = commandItens[6] == '1';

                    result.Last().Keys = new List<byte>();
                    for (int i = 7; i < commandItens.Count - 1; i++)
                    {
                        result.Last().Keys.Add(commandItens[i]);
                    }
                }
            }

            return result;
        }

        public bool ClearMemory()
        {
            if (_serialPort == null) throw new System.Exception("No device connected");
            if (!_serialPort.IsOpen) _serialPort.Open();
            _serialPort.DiscardInBuffer();
            _serialPort.WriteLine("C\n");
            var result = WaitResponse();
            return Encoding.ASCII.GetString(result.ToArray()).StartsWith("OK");
        }

        public List<Preset> LoadPresets()
        {
            var result = new List<Preset>();
            var files = Directory.GetFiles(PresetFolder);
            foreach (var fileName in files)
            {
                using (var file = File.OpenText(fileName))
                {
                    try
                    {
                        result.Add(JsonSerializer.Deserialize<Preset>(file.ReadToEnd()));
                    }
                    finally
                    {
                        file.Close();
                    }
                }
            }
            return result;
        }

        public void SavePereset(Preset preset)
        {
            var fileName = Path.Join(PresetFolder, $"{preset.Name}.json");
            File.WriteAllText(fileName, JsonSerializer.Serialize(preset));
        }

        public void DeletePereset(string presetName)
        {
            var fileName = Path.Join(PresetFolder, $"{presetName}.json");
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private List<byte> WaitResponse()
        {
            int timeoutCount = 0;
            do
            {
                if (_serialPort.BytesToRead > 0)
                {
                    List<byte> buffer = new List<byte>();
                    do
                    {
                        buffer.Add((byte)_serialPort.ReadByte());
                    } while (_serialPort.BytesToRead > 0);

                    return buffer;
                }

                Thread.Sleep(100);
                timeoutCount++;
            } while (timeoutCount < (TIMEOUT / 100));
            throw new System.Exception($"Timeout reading device on serial port {_serialPort.PortName}");
        }
    }
}