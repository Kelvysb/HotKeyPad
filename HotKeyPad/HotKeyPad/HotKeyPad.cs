using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotKeyPad
{
    public partial class HotKeyPad : Form
    {
        private const string APP_NAME = "HotKeyPad";
        private HotKeyPadService service;
        private List<Command> commands = new List<Command>();
        private List<Preset> presets = new List<Preset>();
        private Dictionary<string, byte> especialKeys;
        private Command selectedButton = null;
        private Preset selectedPreset = null;

        public HotKeyPad()
        {
            InitializeComponent();
            service = new HotKeyPadService();
        }

        #region Events

        private void HotKeyPad_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDevice();
                InitializeEspecialKeys();
                LoadCommands();
                LoadPresets();
                SelectButton(1);
                MarkButton(button1);
                Minimize(true);
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

        private void BtnReload_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCommands();
                LoadPresets();
                SelectButton(1);
                MarkButton(button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSavePreset_Click(object sender, EventArgs e)
        {
            try
            {
                SavePreset();
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
                MarkButton((Button)sender);
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

        private void BtnApplyPreset_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyPreset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectPreset(CmbPresets.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletePreset_Click(object sender, EventArgs e)
        {
            try
            {
                DeletePreset();
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

        private void LnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenAbout();
            }
            catch (Exception)
            {
            }
        }

        #endregion Events

        private void InitializeDevice()
        {
            LblDevice.Text = service.SearchDevice();
        }

        private void InitializeEspecialKeys()
        {
            especialKeys = new Dictionary<string, byte>
            {
                { "LEFT CTRL", 128 },
                { "LEFT SHIFT", 129 },
                { "LEFT ALT", 130 },
                { "LEFT GUI", 131 },
                { "RIGHT CTRL", 132 },
                { "RIGHT SHIFT", 133 },
                { "RIGHT ALT", 134 },
                { "RIGHT GUI", 135 },
                { "UP ARROW", 218 },
                { "DOWN ARROW", 217 },
                { "LEFT ARROW", 216 },
                { "RIGHT ARROW", 215 },
                { "BACKSPACE", 178 },
                { "TAB", 179 },
                { "RETURN", 176 },
                { "ESC", 177 },
                { "INSERT", 209 },
                { "DELETE", 212 },
                { "PAGE UP", 211 },
                { "PAGE DOWN", 214 },
                { "HOME", 210 },
                { "END", 213 },
                { "CAPS LOCK", 193 },
                { "F1", 194 },
                { "F2", 195 },
                { "F3", 196 },
                { "F4", 197 },
                { "F5", 198 },
                { "F6", 199 },
                { "F7", 200 },
                { "F8", 201 },
                { "F9", 202 },
                { "F10", 203 },
                { "F11", 204 },
                { "F12", 205 },
                { "F13", 240 },
                { "F14", 241 },
                { "F15", 242 },
                { "F16", 243 },
                { "F17", 244 },
                { "F18", 245 },
                { "F19", 246 },
                { "F20", 247 },
                { "F21", 248 },
                { "F22", 249 },
                { "F23", 250 },
                { "F24", 251 }
            };
            CmbEspecial.Items.Clear();
            CmbEspecial.Items.AddRange(especialKeys.Keys.ToArray());
            CmbEspecial.SelectedIndex = -1;
        }

        private void LoadCommands()
        {
            commands = service.ReadMemory();
        }

        private void LoadPresets()
        {
            presets = service.LoadPresets();
            CmbPresets.Items.Clear();
            CmbPresets.Items.AddRange(presets.Select(p => p.Name).ToArray());
            CmbPresets.SelectedIndex = -1;
            TxtPresetName.Text = string.Empty;
            selectedPreset = null;
        }

        private void SavePreset()
        {
            if (string.IsNullOrEmpty(TxtPresetName.Text.Trim()))
            {
                MessageBox.Show("Preset must have a name", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var preset = new Preset
            {
                Name = TxtPresetName.Text,
                Commands = commands
            };
            service.SavePereset(preset);
            LoadPresets();
            MessageBox.Show("Preset saved", APP_NAME, MessageBoxButtons.OK);
        }

        private void SelectPreset(int index)
        {
            if (index == -1) return;
            var preset = presets[index];
            TxtPresetName.Text = preset.Name;
            selectedPreset = preset;
        }

        private void DeletePreset()
        {
            if (selectedPreset == null) return;
            if (MessageBox.Show("Do you want to delete this preset? ", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                service.DeletePereset(selectedPreset.Name);
                LoadPresets();
                MessageBox.Show("Preset deleted", APP_NAME, MessageBoxButtons.OK);
            }
        }

        private void ApplyPreset()
        {
            if (MessageBox.Show("This will override the current commands, do you want to continue?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("This will take a while, please wait.", APP_NAME, MessageBoxButtons.OK);
                if (selectedPreset == null) return;
                commands = selectedPreset.Commands;
                SelectButton(1);
                MarkButton(button1);
                service.ClearMemory();
                foreach (var command in commands)
                {
                    service.SetCommand(command);
                }
                MessageBox.Show("Preset applied", APP_NAME, MessageBoxButtons.OK);
            }
        }

        private void SelectButton(int button)
        {
            selectedButton = null;
            if (button > 0 && button <= 12)
            {
                selectedButton = commands[button - 1];
                LblSelectedButton.Text = (selectedButton.Position + 1).ToString();
                RadHold.Checked = selectedButton.Mode == CommandMode.Hold;
                NumHoldTime.Value = selectedButton.HoldTime - 48;
                NumDelayTime.Value = selectedButton.DelayTime - 48;
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
            selectedButton.HoldTime = (byte)(NumHoldTime.Value + 48);
            selectedButton.DelayTime = (byte)(NumDelayTime.Value + 48);
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

        private void Minimize(bool first = false)
        {
            WindowState = FormWindowState.Minimized;
            TrayIcon.Visible = true;
            ShowInTaskbar = false;
            Hide();
            if (first)
            {
                TrayIcon.ShowBalloonTip(3, APP_NAME, "Double click on tray icon to open.", ToolTipIcon.Info);
            }
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
                selectedButton.Keys[selectedButton.Keys.IndexOf(0)] = especialKeys[CmbEspecial.SelectedItem.ToString()];
                CmbEspecial.SelectedIndex = -1;
                UpdateCommand();
                TxtCommand.Focus();
            }
        }

        private void AddKey(char keyChar)
        {
            if (keyChar != 0 && !char.IsControl(keyChar))
            {
                selectedButton.Keys[selectedButton.Keys.IndexOf(0)] = (byte)keyChar;
            }
            else if ((keyChar == 127 || keyChar == 8) && selectedButton.Keys.IndexOf(0) - 1 >= 0)
            {
                selectedButton.Keys[selectedButton.Keys.IndexOf(0) - 1] = 0;
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
                            : ((char)k).ToString()));
            TxtCommand.Text = !string.IsNullOrEmpty(value) ? $"'{value}'" : string.Empty;
        }

        private void MarkButton(Button button)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button.BackColor = Color.Cyan;
        }

        private static void OpenAbout()
        {
            var uri = "https://github.com/Kelvysb/HotKeyPad";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);
        }
    }
}