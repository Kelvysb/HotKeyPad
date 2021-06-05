
namespace HotKeyPad
{
    partial class HotKeyPad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotKeyPad));
            this.label1 = new System.Windows.Forms.Label();
            this.LblDevice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSaveCommand = new System.Windows.Forms.Button();
            this.CmbEspecial = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.NumDelayTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.NumHoldTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.RadSequence = new System.Windows.Forms.RadioButton();
            this.RadHold = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblSelectedButton = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChkGui = new System.Windows.Forms.CheckBox();
            this.chkShift = new System.Windows.Forms.CheckBox();
            this.ChkAlt = new System.Windows.Forms.CheckBox();
            this.ChkCtrl = new System.Windows.Forms.CheckBox();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.BtnClearDevice = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPresetName = new System.Windows.Forms.TextBox();
            this.BtnSavePreset = new System.Windows.Forms.Button();
            this.BtnDeletePreset = new System.Windows.Forms.Button();
            this.BtnApplyPreset = new System.Windows.Forms.Button();
            this.CmbPresets = new System.Windows.Forms.ComboBox();
            this.BtnReload = new System.Windows.Forms.Button();
            this.LnkAbout = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoldTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device:";
            // 
            // LblDevice
            // 
            this.LblDevice.AutoSize = true;
            this.LblDevice.Location = new System.Drawing.Point(63, 9);
            this.LblDevice.Name = "LblDevice";
            this.LblDevice.Size = new System.Drawing.Size(95, 15);
            this.LblDevice.TabIndex = 1;
            this.LblDevice.Text = "No device found";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buttons";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(138, 220);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(60, 60);
            this.button12.TabIndex = 12;
            this.button12.Tag = "12";
            this.button12.Text = "12";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(72, 220);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 60);
            this.button11.TabIndex = 11;
            this.button11.Tag = "11";
            this.button11.Text = "11";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(6, 220);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 60);
            this.button10.TabIndex = 10;
            this.button10.Tag = "10";
            this.button10.Text = "10";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(138, 154);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 60);
            this.button9.TabIndex = 9;
            this.button9.Tag = "9";
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(72, 154);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 60);
            this.button8.TabIndex = 8;
            this.button8.Tag = "8";
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(6, 154);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 60);
            this.button7.TabIndex = 7;
            this.button7.Tag = "7";
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(138, 88);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 60);
            this.button6.TabIndex = 6;
            this.button6.Tag = "6";
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(72, 88);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 60);
            this.button5.TabIndex = 5;
            this.button5.Tag = "5";
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(6, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 60);
            this.button4.TabIndex = 4;
            this.button4.Tag = "4";
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(138, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 3;
            this.button3.Tag = "3";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(72, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 60);
            this.button2.TabIndex = 2;
            this.button2.Tag = "2";
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 1;
            this.button1.Tag = "1";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSaveCommand);
            this.groupBox2.Controls.Add(this.CmbEspecial);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtCommand);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.LblSelectedButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(225, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 291);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command";
            // 
            // BtnSaveCommand
            // 
            this.BtnSaveCommand.BackColor = System.Drawing.Color.White;
            this.BtnSaveCommand.Location = new System.Drawing.Point(7, 260);
            this.BtnSaveCommand.Name = "BtnSaveCommand";
            this.BtnSaveCommand.Size = new System.Drawing.Size(72, 25);
            this.BtnSaveCommand.TabIndex = 25;
            this.BtnSaveCommand.Text = "Save";
            this.BtnSaveCommand.UseVisualStyleBackColor = false;
            this.BtnSaveCommand.Click += new System.EventHandler(this.BtnSaveCommand_Click);
            // 
            // CmbEspecial
            // 
            this.CmbEspecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEspecial.FormattingEnabled = true;
            this.CmbEspecial.Location = new System.Drawing.Point(108, 231);
            this.CmbEspecial.Name = "CmbEspecial";
            this.CmbEspecial.Size = new System.Drawing.Size(224, 23);
            this.CmbEspecial.TabIndex = 24;
            this.CmbEspecial.SelectedIndexChanged += new System.EventHandler(this.CmbEspecial_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Add especial Key:";
            // 
            // TxtCommand
            // 
            this.TxtCommand.Location = new System.Drawing.Point(7, 201);
            this.TxtCommand.Name = "TxtCommand";
            this.TxtCommand.ReadOnly = true;
            this.TxtCommand.Size = new System.Drawing.Size(325, 23);
            this.TxtCommand.TabIndex = 23;
            this.TxtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCommand_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.NumDelayTime);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.NumHoldTime);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.RadSequence);
            this.groupBox4.Controls.Add(this.RadHold);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(7, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 80);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configuration";
            // 
            // NumDelayTime
            // 
            this.NumDelayTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumDelayTime.Location = new System.Drawing.Point(204, 47);
            this.NumDelayTime.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.NumDelayTime.Name = "NumDelayTime";
            this.NumDelayTime.Size = new System.Drawing.Size(45, 23);
            this.NumDelayTime.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Delay Time:";
            // 
            // NumHoldTime
            // 
            this.NumHoldTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumHoldTime.Location = new System.Drawing.Point(78, 47);
            this.NumHoldTime.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.NumHoldTime.Name = "NumHoldTime";
            this.NumHoldTime.Size = new System.Drawing.Size(45, 23);
            this.NumHoldTime.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hold Time:";
            // 
            // RadSequence
            // 
            this.RadSequence.AutoSize = true;
            this.RadSequence.Location = new System.Drawing.Point(111, 24);
            this.RadSequence.Name = "RadSequence";
            this.RadSequence.Size = new System.Drawing.Size(76, 19);
            this.RadSequence.TabIndex = 15;
            this.RadSequence.Text = "Sequence";
            this.RadSequence.UseVisualStyleBackColor = true;
            // 
            // RadHold
            // 
            this.RadHold.AutoSize = true;
            this.RadHold.Checked = true;
            this.RadHold.Location = new System.Drawing.Point(54, 24);
            this.RadHold.Name = "RadHold";
            this.RadHold.Size = new System.Drawing.Size(51, 19);
            this.RadHold.TabIndex = 14;
            this.RadHold.TabStop = true;
            this.RadHold.Text = "Hold";
            this.RadHold.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Command:";
            // 
            // LblSelectedButton
            // 
            this.LblSelectedButton.AutoSize = true;
            this.LblSelectedButton.Location = new System.Drawing.Point(108, 19);
            this.LblSelectedButton.Name = "LblSelectedButton";
            this.LblSelectedButton.Size = new System.Drawing.Size(36, 15);
            this.LblSelectedButton.TabIndex = 2;
            this.LblSelectedButton.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selected Button: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChkGui);
            this.groupBox3.Controls.Add(this.chkShift);
            this.groupBox3.Controls.Add(this.ChkAlt);
            this.groupBox3.Controls.Add(this.ChkCtrl);
            this.groupBox3.Location = new System.Drawing.Point(6, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(326, 53);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modifiers";
            // 
            // ChkGui
            // 
            this.ChkGui.AutoSize = true;
            this.ChkGui.Location = new System.Drawing.Point(173, 23);
            this.ChkGui.Name = "ChkGui";
            this.ChkGui.Size = new System.Drawing.Size(44, 19);
            this.ChkGui.TabIndex = 22;
            this.ChkGui.Text = "Gui";
            this.ChkGui.UseVisualStyleBackColor = true;
            // 
            // chkShift
            // 
            this.chkShift.AutoSize = true;
            this.chkShift.Location = new System.Drawing.Point(117, 23);
            this.chkShift.Name = "chkShift";
            this.chkShift.Size = new System.Drawing.Size(50, 19);
            this.chkShift.TabIndex = 21;
            this.chkShift.Text = "Shift";
            this.chkShift.UseVisualStyleBackColor = true;
            // 
            // ChkAlt
            // 
            this.ChkAlt.AutoSize = true;
            this.ChkAlt.Location = new System.Drawing.Point(66, 23);
            this.ChkAlt.Name = "ChkAlt";
            this.ChkAlt.Size = new System.Drawing.Size(45, 19);
            this.ChkAlt.TabIndex = 20;
            this.ChkAlt.Text = "ALT";
            this.ChkAlt.UseVisualStyleBackColor = true;
            // 
            // ChkCtrl
            // 
            this.ChkCtrl.AutoSize = true;
            this.ChkCtrl.Location = new System.Drawing.Point(7, 23);
            this.ChkCtrl.Name = "ChkCtrl";
            this.ChkCtrl.Size = new System.Drawing.Size(53, 19);
            this.ChkCtrl.TabIndex = 19;
            this.ChkCtrl.Text = "CTRL";
            this.ChkCtrl.UseVisualStyleBackColor = true;
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackColor = System.Drawing.Color.White;
            this.BtnMinimize.Location = new System.Drawing.Point(490, 388);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(72, 25);
            this.BtnMinimize.TabIndex = 26;
            this.BtnMinimize.Text = "Minimize";
            this.BtnMinimize.UseVisualStyleBackColor = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "trayIcon";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // BtnClearDevice
            // 
            this.BtnClearDevice.BackColor = System.Drawing.Color.White;
            this.BtnClearDevice.Location = new System.Drawing.Point(327, 388);
            this.BtnClearDevice.Name = "BtnClearDevice";
            this.BtnClearDevice.Size = new System.Drawing.Size(81, 25);
            this.BtnClearDevice.TabIndex = 28;
            this.BtnClearDevice.Text = "Clear Device";
            this.BtnClearDevice.UseVisualStyleBackColor = false;
            this.BtnClearDevice.Click += new System.EventHandler(this.BtnClearDevice_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.TxtPresetName);
            this.groupBox5.Controls.Add(this.BtnSavePreset);
            this.groupBox5.Controls.Add(this.BtnDeletePreset);
            this.groupBox5.Controls.Add(this.BtnApplyPreset);
            this.groupBox5.Controls.Add(this.CmbPresets);
            this.groupBox5.Location = new System.Drawing.Point(12, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(551, 58);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Presets";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "Name:";
            // 
            // TxtPresetName
            // 
            this.TxtPresetName.Location = new System.Drawing.Point(321, 22);
            this.TxtPresetName.Name = "TxtPresetName";
            this.TxtPresetName.Size = new System.Drawing.Size(153, 23);
            this.TxtPresetName.TabIndex = 4;
            // 
            // BtnSavePreset
            // 
            this.BtnSavePreset.BackColor = System.Drawing.Color.White;
            this.BtnSavePreset.Location = new System.Drawing.Point(479, 21);
            this.BtnSavePreset.Name = "BtnSavePreset";
            this.BtnSavePreset.Size = new System.Drawing.Size(55, 25);
            this.BtnSavePreset.TabIndex = 5;
            this.BtnSavePreset.Text = "Save";
            this.BtnSavePreset.UseVisualStyleBackColor = false;
            this.BtnSavePreset.Click += new System.EventHandler(this.BtnSavePreset_Click);
            // 
            // BtnDeletePreset
            // 
            this.BtnDeletePreset.BackColor = System.Drawing.Color.White;
            this.BtnDeletePreset.Location = new System.Drawing.Point(213, 21);
            this.BtnDeletePreset.Name = "BtnDeletePreset";
            this.BtnDeletePreset.Size = new System.Drawing.Size(55, 25);
            this.BtnDeletePreset.TabIndex = 3;
            this.BtnDeletePreset.Text = "Delete";
            this.BtnDeletePreset.UseVisualStyleBackColor = false;
            this.BtnDeletePreset.Click += new System.EventHandler(this.BtnDeletePreset_Click);
            // 
            // BtnApplyPreset
            // 
            this.BtnApplyPreset.BackColor = System.Drawing.Color.White;
            this.BtnApplyPreset.Location = new System.Drawing.Point(152, 21);
            this.BtnApplyPreset.Name = "BtnApplyPreset";
            this.BtnApplyPreset.Size = new System.Drawing.Size(55, 25);
            this.BtnApplyPreset.TabIndex = 2;
            this.BtnApplyPreset.Text = "Apply";
            this.BtnApplyPreset.UseVisualStyleBackColor = false;
            this.BtnApplyPreset.Click += new System.EventHandler(this.BtnApplyPreset_Click);
            // 
            // CmbPresets
            // 
            this.CmbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPresets.FormattingEnabled = true;
            this.CmbPresets.Location = new System.Drawing.Point(11, 22);
            this.CmbPresets.Name = "CmbPresets";
            this.CmbPresets.Size = new System.Drawing.Size(135, 23);
            this.CmbPresets.TabIndex = 1;
            this.CmbPresets.SelectedIndexChanged += new System.EventHandler(this.CmbPresets_SelectedIndexChanged);
            // 
            // BtnReload
            // 
            this.BtnReload.BackColor = System.Drawing.Color.White;
            this.BtnReload.Location = new System.Drawing.Point(414, 388);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(72, 25);
            this.BtnReload.TabIndex = 27;
            this.BtnReload.Text = "Reload";
            this.BtnReload.UseVisualStyleBackColor = false;
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // LnkAbout
            // 
            this.LnkAbout.AutoSize = true;
            this.LnkAbout.Location = new System.Drawing.Point(522, 9);
            this.LnkAbout.Name = "LnkAbout";
            this.LnkAbout.Size = new System.Drawing.Size(40, 15);
            this.LnkAbout.TabIndex = 29;
            this.LnkAbout.TabStop = true;
            this.LnkAbout.Text = "About";
            this.LnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkAbout_LinkClicked);
            // 
            // HotKeyPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 420);
            this.Controls.Add(this.LnkAbout);
            this.Controls.Add(this.BtnReload);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.BtnClearDevice);
            this.Controls.Add(this.BtnMinimize);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblDevice);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotKeyPad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotKeypad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotKeyPad_FormClosing);
            this.Load += new System.EventHandler(this.HotKeyPad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoldTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LblSelectedButton;
        private System.Windows.Forms.Button BtnSaveCommand;
        private System.Windows.Forms.ComboBox CmbEspecial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtCommand;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown NumDelayTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NumHoldTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RadSequence;
        private System.Windows.Forms.RadioButton RadHold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkGui;
        private System.Windows.Forms.CheckBox chkShift;
        private System.Windows.Forms.CheckBox ChkAlt;
        private System.Windows.Forms.CheckBox ChkCtrl;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.Button BtnClearDevice;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtPresetName;
        private System.Windows.Forms.Button BtnSavePreset;
        private System.Windows.Forms.Button BtnDeletePreset;
        private System.Windows.Forms.Button BtnApplyPreset;
        private System.Windows.Forms.ComboBox CmbPresets;
        private System.Windows.Forms.Button BtnReload;
        private System.Windows.Forms.LinkLabel LnkAbout;
    }
}

