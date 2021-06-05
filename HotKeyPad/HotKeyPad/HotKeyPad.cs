using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotKeyPad
{
    public partial class HotKeyPad : Form
    {
        private const string APP_NAME = "HotKeyPad";
        private HotKeyPadService service;
        private List<Command> commands = new List<Command>();
        private Dictionary<string, char> especialKeys;
        private Command selectedButton = null;

        public HotKeyPad()
        {
            InitializeComponent();
            service = new HotKeyPadService();
        }

        private void HotKeyPad_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDevice();
                InitializeEspecialKeys();
                LoadCommands();
                SelectButton(1);
                Minimize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HotKeyPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = CloseQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                SelectButton(int.Parse(((Button)sender).Tag.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveCommand_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                Minimize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearDevice_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDevice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Maximize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbEspecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Addespecial(CmbEspecial.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                AddKey(e.KeyChar);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDevice()
        {
            LblDevice.Text = service.SearchDevice();
        }

        private void InitializeEspecialKeys()
        {
            especialKeys = new Dictionary<string, char>
            {
                { "LEFT CTRL", (char)128 },
                { "LEFT SHIFT", (char)129 },
                { "LEFT ALT", (char)130 },
                { "LEFT GUI", (char)131 },
                { "RIGHT CTRL", (char)132 },
                { "RIGHT SHIFT", (char)133 },
                { "RIGHT ALT", (char)134 },
                { "RIGHT GUI", (char)135 },
                { "UP ARROW", (char)218 },
                { "DOWN ARROW", (char)217 },
                { "LEFT ARROW", (char)216 },
                { "RIGHT ARROW", (char)215 },
                { "BACKSPACE", (char)178 },
                { "TAB", (char)179 },
                { "RETURN", (char)176 },
                { "ESC", (char)177 },
                { "INSERT", (char)209 },
                { "DELETE", (char)212 },
                { "PAGE UP", (char)211 },
                { "PAGE DOWN", (char)214 },
                { "HOME", (char)210 },
                { "END", (char)213 },
                { "CAPS LOCK", (char)193 },
                { "F1", (char)194 },
                { "F2", (char)195 },
                { "F3", (char)196 },
                { "F4", (char)197 },
                { "F5", (char)198 },
                { "F6", (char)199 },
                { "F7", (char)200 },
                { "F8", (char)201 },
                { "F9", (char)202 },
                { "F10", (char)203 },
                { "F11", (char)204 },
                { "F12", (char)205 },
                { "F13", (char)240 },
                { "F14", (char)241 },
                { "F15", (char)242 },
                { "F16", (char)243 },
                { "F17", (char)244 },
                { "F18", (char)245 },
                { "F19", (char)246 },
                { "F20", (char)247 },
                { "F21", (char)248 },
                { "F22", (char)249 },
                { "F23", (char)250 },
                { "F24", (char)251 }
            };
            CmbEspecial.Items.Clear();
            CmbEspecial.Items.AddRange(especialKeys.Keys.ToArray());
            CmbEspecial.SelectedIndex = -1;
        }

        private void LoadCommands()
        {
            commands = service.ReadMemory();
        }

        private void SelectButton(int button)
        {
            selectedButton = null;
            if (button > 0 && button <= 12)
            {
                selectedButton = commands[button - 1];
                LblSelectedButton.Text = (selectedButton.Position + 1).ToString();
                RadHold.Checked = selectedButton.Mode == CommandMode.Hold;
                NumHoldTime.Value = int.Parse(selectedButton.HoldTime.ToString());
                NumDelayTime.Value = int.Parse(selectedButton.DelayTime.ToString());
                ChkCtrl.Checked = selectedButton.Ctrl;
                ChkAlt.Checked = selectedButton.Alt;
                chkShift.Checked = selectedButton.Shift;
                ChkGui.Checked = selectedButton.Gui;
                UpdateCommand();
            }
        }

        private void SaveCommand()
        {
            selectedButton.Mode = RadHold.Checked ? CommandMode.Hold : CommandMode.Sequence;
            selectedButton.HoldTime = (char)(NumHoldTime.Value + 48);
            selectedButton.DelayTime = (char)(NumDelayTime.Value + 48);
            selectedButton.Ctrl = ChkCtrl.Checked;
            selectedButton.Alt = ChkAlt.Checked;
            selectedButton.Shift = chkShift.Checked;
            selectedButton.Gui = ChkGui.Checked;
            if (service.SetCommand(selectedButton))
            {
                MessageBox.Show("Saved", APP_NAME);
            }
            else
            {
                throw new Exception("Error saving.");
            }
        }

        private void Minimize()
        {
            WindowState = FormWindowState.Minimized;
            TrayIcon.Visible = true;
            ShowInTaskbar = false;
            Hide();
        }

        private void Maximize()
        {
            WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
            ShowInTaskbar = true;
            Show();
        }

        private bool CloseQuestion()
        {
            if (MessageBox.Show("Minimize to tray?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Minimize();
                return true;
            }
            return false;
        }

        private void ClearDevice()
        {
            if (MessageBox.Show("Do you really want to clear te device memory?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                service.ClearMemory();
                commands = service.ReadMemory();
                SelectButton(1);
                MessageBox.Show("Memory cleared", APP_NAME);
            }
        }

        private void Addespecial(int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                selectedButton.Keys[selectedButton.Keys.IndexOf('\0')] = especialKeys[CmbEspecial.SelectedItem.ToString()];
                CmbEspecial.SelectedIndex = -1;
                UpdateCommand();
                TxtCommand.Focus();
            }
        }

        private void AddKey(char keyChar)
        {
            if (keyChar != 0 && !char.IsControl(keyChar))
            {
                selectedButton.Keys[selectedButton.Keys.IndexOf('\0')] = keyChar;
            }
            else if ((keyChar == 127 || keyChar == 8) && selectedButton.Keys.IndexOf('\0') - 1 >= 0)
            {
                selectedButton.Keys[selectedButton.Keys.IndexOf('\0') - 1] = '\0';
            }
            UpdateCommand();
        }

        private void UpdateCommand()
        {
            var value =
                string.Join("' + '", selectedButton.Keys
                        .Where(k => k != 0)
                        .Select(k =>
                            especialKeys.Values.Contains(k)
                            ? $"<{especialKeys.First(v => v.Value == k).Key}>"
                            : k.ToString()));
            TxtCommand.Text = !string.IsNullOrEmpty(value) ? $"'{value}'" : string.Empty;
        }
    }
}