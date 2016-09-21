namespace CSGO_SmartCross
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.primaryGunLabel = new System.Windows.Forms.Label();
            this.secondaryGunLabel = new System.Windows.Forms.Label();
            this.primaryBox = new System.Windows.Forms.TextBox();
            this.secondaryBox = new System.Windows.Forms.TextBox();
            this.alwaysBox = new System.Windows.Forms.CheckBox();
            this.crosshairButton = new System.Windows.Forms.Button();
            this.triggerKeyBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rcsKeyBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.secondaryKeyBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.primaryKeyBox = new System.Windows.Forms.ComboBox();
            this.primaryLabel = new System.Windows.Forms.Label();
            this.secondaryLabel = new System.Windows.Forms.Label();
            this.triggerToggleButton = new System.Windows.Forms.RadioButton();
            this.triggerHoldButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rcsHoldButton = new System.Windows.Forms.RadioButton();
            this.rcsToggleButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rapidHoldButton = new System.Windows.Forms.RadioButton();
            this.rapidToggleButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.rapidKeyBox = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bHopHoldButton = new System.Windows.Forms.RadioButton();
            this.bHopToggleButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bHopKeyBox = new System.Windows.Forms.ComboBox();
            this.crosshairBox = new System.Windows.Forms.PictureBox();
            this.crosshairLabel = new System.Windows.Forms.Label();
            this.crosshairImageButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // primaryGunLabel
            // 
            this.primaryGunLabel.AutoSize = true;
            this.primaryGunLabel.Location = new System.Drawing.Point(12, 49);
            this.primaryGunLabel.Name = "primaryGunLabel";
            this.primaryGunLabel.Size = new System.Drawing.Size(44, 13);
            this.primaryGunLabel.TabIndex = 13;
            this.primaryGunLabel.Text = "Primary:";
            // 
            // secondaryGunLabel
            // 
            this.secondaryGunLabel.AutoSize = true;
            this.secondaryGunLabel.Location = new System.Drawing.Point(12, 88);
            this.secondaryGunLabel.Name = "secondaryGunLabel";
            this.secondaryGunLabel.Size = new System.Drawing.Size(61, 13);
            this.secondaryGunLabel.TabIndex = 14;
            this.secondaryGunLabel.Text = "Secondary:";
            // 
            // primaryBox
            // 
            this.primaryBox.BackColor = System.Drawing.Color.PaleGreen;
            this.primaryBox.Location = new System.Drawing.Point(79, 46);
            this.primaryBox.Name = "primaryBox";
            this.primaryBox.Size = new System.Drawing.Size(77, 20);
            this.primaryBox.TabIndex = 0;
            this.primaryBox.Text = "AK-47";
            this.primaryBox.TextChanged += new System.EventHandler(this.primaryBox_TextChanged);
            // 
            // secondaryBox
            // 
            this.secondaryBox.BackColor = System.Drawing.Color.PaleGreen;
            this.secondaryBox.Location = new System.Drawing.Point(79, 85);
            this.secondaryBox.Name = "secondaryBox";
            this.secondaryBox.Size = new System.Drawing.Size(77, 20);
            this.secondaryBox.TabIndex = 1;
            this.secondaryBox.Text = "Glock-18";
            this.secondaryBox.TextChanged += new System.EventHandler(this.secondaryBox_TextChanged);
            // 
            // alwaysBox
            // 
            this.alwaysBox.AutoSize = true;
            this.alwaysBox.Location = new System.Drawing.Point(86, 368);
            this.alwaysBox.Name = "alwaysBox";
            this.alwaysBox.Size = new System.Drawing.Size(129, 17);
            this.alwaysBox.TabIndex = 17;
            this.alwaysBox.Text = "Show stable crosshair";
            this.alwaysBox.UseVisualStyleBackColor = true;
            this.alwaysBox.CheckedChanged += new System.EventHandler(this.alwaysBox_CheckedChanged);
            // 
            // crosshairButton
            // 
            this.crosshairButton.Location = new System.Drawing.Point(12, 340);
            this.crosshairButton.Name = "crosshairButton";
            this.crosshairButton.Size = new System.Drawing.Size(265, 22);
            this.crosshairButton.TabIndex = 18;
            this.crosshairButton.Text = "Disable Crosshair";
            this.crosshairButton.UseVisualStyleBackColor = true;
            this.crosshairButton.Click += new System.EventHandler(this.crosshairButton_Click);
            // 
            // triggerKeyBox
            // 
            this.triggerKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.triggerKeyBox.FormattingEnabled = true;
            this.triggerKeyBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            ";",
            "\\",
            " ",
            "\"",
            ".",
            "|",
            "-",
            ",",
            "?",
            "+",
            "[",
            "]",
            "MB1",
            "MB2",
            "MB3"});
            this.triggerKeyBox.Location = new System.Drawing.Point(97, 190);
            this.triggerKeyBox.Name = "triggerKeyBox";
            this.triggerKeyBox.Size = new System.Drawing.Size(51, 21);
            this.triggerKeyBox.TabIndex = 19;
            this.triggerKeyBox.SelectedIndexChanged += new System.EventHandler(this.triggerKeyBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Triggerbot Key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "RCS Key:";
            // 
            // rcsKeyBox
            // 
            this.rcsKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rcsKeyBox.FormattingEnabled = true;
            this.rcsKeyBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            ";",
            "\\",
            " ",
            "\"",
            ".",
            "|",
            "-",
            ",",
            "?",
            "+",
            "[",
            "]",
            "MB1",
            "MB2",
            "MB3"});
            this.rcsKeyBox.Location = new System.Drawing.Point(97, 218);
            this.rcsKeyBox.Name = "rcsKeyBox";
            this.rcsKeyBox.Size = new System.Drawing.Size(51, 21);
            this.rcsKeyBox.TabIndex = 21;
            this.rcsKeyBox.SelectedIndexChanged += new System.EventHandler(this.rcsKeyBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Select Key:";
            // 
            // secondaryKeyBox
            // 
            this.secondaryKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondaryKeyBox.FormattingEnabled = true;
            this.secondaryKeyBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            ";",
            "\\",
            " ",
            "\"",
            ".",
            "|",
            "-",
            ",",
            "?",
            "+",
            "[",
            "]",
            "MB1",
            "MB2",
            "MB3"});
            this.secondaryKeyBox.Location = new System.Drawing.Point(229, 85);
            this.secondaryKeyBox.Name = "secondaryKeyBox";
            this.secondaryKeyBox.Size = new System.Drawing.Size(51, 21);
            this.secondaryKeyBox.TabIndex = 25;
            this.secondaryKeyBox.SelectedIndexChanged += new System.EventHandler(this.secondaryKeyBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Select Key:";
            // 
            // primaryKeyBox
            // 
            this.primaryKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.primaryKeyBox.FormattingEnabled = true;
            this.primaryKeyBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            ";",
            "\\",
            " ",
            "\"",
            ".",
            "|",
            "-",
            ",",
            "?",
            "+",
            "[",
            "]",
            "MB1",
            "MB2",
            "MB3"});
            this.primaryKeyBox.Location = new System.Drawing.Point(229, 46);
            this.primaryKeyBox.Name = "primaryKeyBox";
            this.primaryKeyBox.Size = new System.Drawing.Size(51, 21);
            this.primaryKeyBox.TabIndex = 23;
            this.primaryKeyBox.SelectedIndexChanged += new System.EventHandler(this.primaryKeyBox_SelectedIndexChanged);
            // 
            // primaryLabel
            // 
            this.primaryLabel.AutoSize = true;
            this.primaryLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.primaryLabel.Location = new System.Drawing.Point(76, 69);
            this.primaryLabel.Name = "primaryLabel";
            this.primaryLabel.Size = new System.Drawing.Size(75, 13);
            this.primaryLabel.TabIndex = 27;
            this.primaryLabel.Text = "AK-47 Loaded";
            this.primaryLabel.Click += new System.EventHandler(this.primaryLabel_Click);
            // 
            // secondaryLabel
            // 
            this.secondaryLabel.AutoSize = true;
            this.secondaryLabel.Location = new System.Drawing.Point(76, 108);
            this.secondaryLabel.Name = "secondaryLabel";
            this.secondaryLabel.Size = new System.Drawing.Size(97, 13);
            this.secondaryLabel.TabIndex = 28;
            this.secondaryLabel.Text = "GLOCK-18 Loaded";
            this.secondaryLabel.Click += new System.EventHandler(this.secondaryLabel_Click);
            // 
            // triggerToggleButton
            // 
            this.triggerToggleButton.AutoSize = true;
            this.triggerToggleButton.Location = new System.Drawing.Point(3, 3);
            this.triggerToggleButton.Name = "triggerToggleButton";
            this.triggerToggleButton.Size = new System.Drawing.Size(58, 17);
            this.triggerToggleButton.TabIndex = 0;
            this.triggerToggleButton.TabStop = true;
            this.triggerToggleButton.Text = "Toggle";
            this.triggerToggleButton.UseVisualStyleBackColor = true;
            this.triggerToggleButton.CheckedChanged += new System.EventHandler(this.triggerToggleButton_CheckedChanged);
            // 
            // triggerHoldButton
            // 
            this.triggerHoldButton.AutoSize = true;
            this.triggerHoldButton.Location = new System.Drawing.Point(67, 3);
            this.triggerHoldButton.Name = "triggerHoldButton";
            this.triggerHoldButton.Size = new System.Drawing.Size(47, 17);
            this.triggerHoldButton.TabIndex = 1;
            this.triggerHoldButton.TabStop = true;
            this.triggerHoldButton.Text = "Hold";
            this.triggerHoldButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.triggerHoldButton);
            this.panel1.Controls.Add(this.triggerToggleButton);
            this.panel1.Location = new System.Drawing.Point(154, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 25);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rcsHoldButton);
            this.panel2.Controls.Add(this.rcsToggleButton);
            this.panel2.Location = new System.Drawing.Point(154, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 25);
            this.panel2.TabIndex = 30;
            // 
            // rcsHoldButton
            // 
            this.rcsHoldButton.AutoSize = true;
            this.rcsHoldButton.Location = new System.Drawing.Point(67, 2);
            this.rcsHoldButton.Name = "rcsHoldButton";
            this.rcsHoldButton.Size = new System.Drawing.Size(47, 17);
            this.rcsHoldButton.TabIndex = 1;
            this.rcsHoldButton.TabStop = true;
            this.rcsHoldButton.Text = "Hold";
            this.rcsHoldButton.UseVisualStyleBackColor = true;
            // 
            // rcsToggleButton
            // 
            this.rcsToggleButton.AutoSize = true;
            this.rcsToggleButton.Location = new System.Drawing.Point(3, 3);
            this.rcsToggleButton.Name = "rcsToggleButton";
            this.rcsToggleButton.Size = new System.Drawing.Size(58, 17);
            this.rcsToggleButton.TabIndex = 0;
            this.rcsToggleButton.TabStop = true;
            this.rcsToggleButton.Text = "Toggle";
            this.rcsToggleButton.UseVisualStyleBackColor = true;
            this.rcsToggleButton.CheckedChanged += new System.EventHandler(this.rcsToggleButton_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rapidHoldButton);
            this.panel3.Controls.Add(this.rapidToggleButton);
            this.panel3.Location = new System.Drawing.Point(154, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(126, 25);
            this.panel3.TabIndex = 32;
            // 
            // rapidHoldButton
            // 
            this.rapidHoldButton.AutoSize = true;
            this.rapidHoldButton.Location = new System.Drawing.Point(67, 3);
            this.rapidHoldButton.Name = "rapidHoldButton";
            this.rapidHoldButton.Size = new System.Drawing.Size(47, 17);
            this.rapidHoldButton.TabIndex = 1;
            this.rapidHoldButton.TabStop = true;
            this.rapidHoldButton.Text = "Hold";
            this.rapidHoldButton.UseVisualStyleBackColor = true;
            // 
            // rapidToggleButton
            // 
            this.rapidToggleButton.AutoSize = true;
            this.rapidToggleButton.Location = new System.Drawing.Point(3, 3);
            this.rapidToggleButton.Name = "rapidToggleButton";
            this.rapidToggleButton.Size = new System.Drawing.Size(58, 17);
            this.rapidToggleButton.TabIndex = 0;
            this.rapidToggleButton.TabStop = true;
            this.rapidToggleButton.Text = "Toggle";
            this.rapidToggleButton.UseVisualStyleBackColor = true;
            this.rapidToggleButton.CheckedChanged += new System.EventHandler(this.rapidToggleButton_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Rapidfire Key:";
            // 
            // rapidKeyBox
            // 
            this.rapidKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rapidKeyBox.FormattingEnabled = true;
            this.rapidKeyBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            ";",
            "\\",
            " ",
            "\"",
            ".",
            "|",
            "-",
            ",",
            "?",
            "+",
            "[",
            "]",
            "MB1",
            "MB2",
            "MB3"});
            this.rapidKeyBox.Location = new System.Drawing.Point(97, 162);
            this.rapidKeyBox.Name = "rapidKeyBox";
            this.rapidKeyBox.Size = new System.Drawing.Size(51, 21);
            this.rapidKeyBox.TabIndex = 30;
            this.rapidKeyBox.SelectedIndexChanged += new System.EventHandler(this.rapidKeyBox_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bHopHoldButton);
            this.panel4.Controls.Add(this.bHopToggleButton);
            this.panel4.Location = new System.Drawing.Point(154, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(126, 25);
            this.panel4.TabIndex = 35;
            // 
            // bHopHoldButton
            // 
            this.bHopHoldButton.AutoSize = true;
            this.bHopHoldButton.Location = new System.Drawing.Point(67, 3);
            this.bHopHoldButton.Name = "bHopHoldButton";
            this.bHopHoldButton.Size = new System.Drawing.Size(47, 17);
            this.bHopHoldButton.TabIndex = 1;
            this.bHopHoldButton.TabStop = true;
            this.bHopHoldButton.Text = "Hold";
            this.bHopHoldButton.UseVisualStyleBackColor = true;
            // 
            // bHopToggleButton
            // 
            this.bHopToggleButton.AutoSize = true;
            this.bHopToggleButton.Location = new System.Drawing.Point(3, 3);
            this.bHopToggleButton.Name = "bHopToggleButton";
            this.bHopToggleButton.Size = new System.Drawing.Size(58, 17);
            this.bHopToggleButton.TabIndex = 0;
            this.bHopToggleButton.TabStop = true;
            this.bHopToggleButton.Text = "Toggle";
            this.bHopToggleButton.UseVisualStyleBackColor = true;
            this.bHopToggleButton.CheckedChanged += new System.EventHandler(this.bHopToggleButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Bunnyhop Key:";
            // 
            // bHopKeyBox
            // 
            this.bHopKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bHopKeyBox.FormattingEnabled = true;
            this.bHopKeyBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            ";",
            "\\",
            " ",
            "\"",
            ".",
            "|",
            "-",
            ",",
            "?",
            "+",
            "[",
            "]",
            "MB1",
            "MB2",
            "MB3"});
            this.bHopKeyBox.Location = new System.Drawing.Point(97, 134);
            this.bHopKeyBox.Name = "bHopKeyBox";
            this.bHopKeyBox.Size = new System.Drawing.Size(51, 21);
            this.bHopKeyBox.TabIndex = 33;
            this.bHopKeyBox.SelectedIndexChanged += new System.EventHandler(this.bHopKeyBox_SelectedIndexChanged);
            // 
            // crosshairBox
            // 
            this.crosshairBox.ImageLocation = "crosshair.bmp";
            this.crosshairBox.Location = new System.Drawing.Point(101, 255);
            this.crosshairBox.Name = "crosshairBox";
            this.crosshairBox.Size = new System.Drawing.Size(50, 50);
            this.crosshairBox.TabIndex = 36;
            this.crosshairBox.TabStop = false;
            this.crosshairBox.Click += new System.EventHandler(this.crosshairBox_Click);
            // 
            // crosshairLabel
            // 
            this.crosshairLabel.AutoSize = true;
            this.crosshairLabel.Location = new System.Drawing.Point(12, 251);
            this.crosshairLabel.Name = "crosshairLabel";
            this.crosshairLabel.Size = new System.Drawing.Size(85, 13);
            this.crosshairLabel.TabIndex = 37;
            this.crosshairLabel.Text = "Crosshair Image:";
            // 
            // crosshairImageButton
            // 
            this.crosshairImageButton.Location = new System.Drawing.Point(12, 311);
            this.crosshairImageButton.Name = "crosshairImageButton";
            this.crosshairImageButton.Size = new System.Drawing.Size(108, 23);
            this.crosshairImageButton.TabIndex = 38;
            this.crosshairImageButton.Text = "Change Crosshair";
            this.crosshairImageButton.UseVisualStyleBackColor = true;
            this.crosshairImageButton.Click += new System.EventHandler(this.crosshairImageButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(299, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.loadSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.advancedToolStripMenuItem_Click);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveSettingsToolStripMenuItem.Text = "Save Settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // loadSettingsToolStripMenuItem
            // 
            this.loadSettingsToolStripMenuItem.Name = "loadSettingsToolStripMenuItem";
            this.loadSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadSettingsToolStripMenuItem.Text = "Load Settings";
            this.loadSettingsToolStripMenuItem.Click += new System.EventHandler(this.loadSettingsToolStripMenuItem_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 393);
            this.Controls.Add(this.crosshairImageButton);
            this.Controls.Add(this.crosshairLabel);
            this.Controls.Add(this.crosshairBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bHopKeyBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rapidKeyBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.secondaryLabel);
            this.Controls.Add(this.primaryLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.secondaryKeyBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.primaryKeyBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rcsKeyBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.triggerKeyBox);
            this.Controls.Add(this.crosshairButton);
            this.Controls.Add(this.alwaysBox);
            this.Controls.Add(this.secondaryBox);
            this.Controls.Add(this.primaryBox);
            this.Controls.Add(this.secondaryGunLabel);
            this.Controls.Add(this.primaryGunLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "SmartCross";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crosshairBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label primaryGunLabel;
        private System.Windows.Forms.Label secondaryGunLabel;
        private System.Windows.Forms.TextBox primaryBox;
        private System.Windows.Forms.TextBox secondaryBox;
        private System.Windows.Forms.CheckBox alwaysBox;
        private System.Windows.Forms.Button crosshairButton;
        private System.Windows.Forms.ComboBox triggerKeyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox rcsKeyBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox secondaryKeyBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox primaryKeyBox;
        private System.Windows.Forms.Label primaryLabel;
        private System.Windows.Forms.Label secondaryLabel;
        private System.Windows.Forms.RadioButton triggerToggleButton;
        private System.Windows.Forms.RadioButton triggerHoldButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rcsHoldButton;
        private System.Windows.Forms.RadioButton rcsToggleButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rapidHoldButton;
        private System.Windows.Forms.RadioButton rapidToggleButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox rapidKeyBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton bHopHoldButton;
        private System.Windows.Forms.RadioButton bHopToggleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bHopKeyBox;
        private System.Windows.Forms.PictureBox crosshairBox;
        private System.Windows.Forms.Label crosshairLabel;
        private System.Windows.Forms.Button crosshairImageButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSettingsToolStripMenuItem;
    }
}

