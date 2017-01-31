namespace CSGO_SmartCross
{
    partial class TrexConfigure
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mapBox = new System.Windows.Forms.ComboBox();
            this.teamBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(141, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(60, 70);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Map:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enemy Team:";
            // 
            // mapBox
            // 
            this.mapBox.FormattingEnabled = true;
            this.mapBox.Items.AddRange(new object[] {
            "dust2"});
            this.mapBox.Location = new System.Drawing.Point(90, 12);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(121, 21);
            this.mapBox.TabIndex = 4;
            this.mapBox.SelectedIndexChanged += new System.EventHandler(this.mapBox_SelectedIndexChanged);
            // 
            // teamBox
            // 
            this.teamBox.FormattingEnabled = true;
            this.teamBox.Items.AddRange(new object[] {
            "CT"});
            this.teamBox.Location = new System.Drawing.Point(90, 43);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(121, 21);
            this.teamBox.TabIndex = 5;
            this.teamBox.SelectedIndexChanged += new System.EventHandler(this.teamBox_SelectedIndexChanged);
            // 
            // TrexConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 105);
            this.Controls.Add(this.teamBox);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "TrexConfigure";
            this.Text = "TrexConfigure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mapBox;
        private System.Windows.Forms.ComboBox teamBox;
    }
}