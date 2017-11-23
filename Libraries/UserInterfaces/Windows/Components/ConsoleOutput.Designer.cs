namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
    partial class ConsoleOutput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.checkBox_ShowDate = new System.Windows.Forms.CheckBox();
			this.checkBox_ShowTime = new System.Windows.Forms.CheckBox();
			this.checkBox_ShowUsername = new System.Windows.Forms.CheckBox();
			this.checkBox_ShowMessage = new System.Windows.Forms.CheckBox();
			this.button_TestOutput = new System.Windows.Forms.Button();
			this.richTextBox_ConsoleOutput = new Com.OfficerFlake.Libraries.UserInterfaces.Windows.Components.RichTextBox_FormattedBlack();
			this.SuspendLayout();
			// 
			// checkBox_ShowDate
			// 
			this.checkBox_ShowDate.AutoSize = true;
			this.checkBox_ShowDate.Location = new System.Drawing.Point(0, 0);
			this.checkBox_ShowDate.Name = "checkBox_ShowDate";
			this.checkBox_ShowDate.Size = new System.Drawing.Size(115, 17);
			this.checkBox_ShowDate.TabIndex = 5;
			this.checkBox_ShowDate.Text = "Show DateStamp?";
			this.checkBox_ShowDate.UseVisualStyleBackColor = true;
			this.checkBox_ShowDate.CheckedChanged += new System.EventHandler(this.CheckBox_ShowDate_CheckedChanged);
			// 
			// checkBox_ShowTime
			// 
			this.checkBox_ShowTime.AutoSize = true;
			this.checkBox_ShowTime.Checked = true;
			this.checkBox_ShowTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_ShowTime.Location = new System.Drawing.Point(121, 0);
			this.checkBox_ShowTime.Name = "checkBox_ShowTime";
			this.checkBox_ShowTime.Size = new System.Drawing.Size(115, 17);
			this.checkBox_ShowTime.TabIndex = 1;
			this.checkBox_ShowTime.Text = "Show TimeStamp?";
			this.checkBox_ShowTime.UseVisualStyleBackColor = true;
			this.checkBox_ShowTime.CheckedChanged += new System.EventHandler(this.CheckBox_ShowTime_CheckedChanged);
			// 
			// checkBox_ShowUsername
			// 
			this.checkBox_ShowUsername.AutoSize = true;
			this.checkBox_ShowUsername.Checked = true;
			this.checkBox_ShowUsername.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_ShowUsername.Location = new System.Drawing.Point(242, 0);
			this.checkBox_ShowUsername.Name = "checkBox_ShowUsername";
			this.checkBox_ShowUsername.Size = new System.Drawing.Size(112, 17);
			this.checkBox_ShowUsername.TabIndex = 2;
			this.checkBox_ShowUsername.Text = "Show UserName?";
			this.checkBox_ShowUsername.UseVisualStyleBackColor = true;
			this.checkBox_ShowUsername.CheckedChanged += new System.EventHandler(this.CheckBox_ShowUsername_CheckedChanged);
			// 
			// checkBox_ShowMessage
			// 
			this.checkBox_ShowMessage.AutoSize = true;
			this.checkBox_ShowMessage.Checked = true;
			this.checkBox_ShowMessage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_ShowMessage.Location = new System.Drawing.Point(360, 0);
			this.checkBox_ShowMessage.Name = "checkBox_ShowMessage";
			this.checkBox_ShowMessage.Size = new System.Drawing.Size(105, 17);
			this.checkBox_ShowMessage.TabIndex = 3;
			this.checkBox_ShowMessage.Text = "Show Message?";
			this.checkBox_ShowMessage.UseVisualStyleBackColor = true;
			this.checkBox_ShowMessage.CheckedChanged += new System.EventHandler(this.CheckBox_ShowMessage_CheckedChanged);
			// 
			// button_TestOutput
			// 
			this.button_TestOutput.BackColor = System.Drawing.Color.Black;
			this.button_TestOutput.Location = new System.Drawing.Point(565, 0);
			this.button_TestOutput.Margin = new System.Windows.Forms.Padding(0);
			this.button_TestOutput.Name = "button_TestOutput";
			this.button_TestOutput.Size = new System.Drawing.Size(75, 23);
			this.button_TestOutput.TabIndex = 4;
			this.button_TestOutput.Text = "Test Output";
			this.button_TestOutput.UseVisualStyleBackColor = false;
			this.button_TestOutput.Click += new System.EventHandler(this.Button_TestOutput_Click);
			// 
			// richTextBox_ConsoleOutput
			// 
			this.richTextBox_ConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_ConsoleOutput.BackColor = System.Drawing.Color.Black;
			this.richTextBox_ConsoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox_ConsoleOutput.ForeColor = System.Drawing.Color.White;
			this.richTextBox_ConsoleOutput.Location = new System.Drawing.Point(0, 25);
			this.richTextBox_ConsoleOutput.Margin = new System.Windows.Forms.Padding(0);
			this.richTextBox_ConsoleOutput.Name = "richTextBox_ConsoleOutput";
			this.richTextBox_ConsoleOutput.ReadOnly = true;
			this.richTextBox_ConsoleOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBox_ConsoleOutput.Size = new System.Drawing.Size(640, 430);
			this.richTextBox_ConsoleOutput.TabIndex = 7;
			this.richTextBox_ConsoleOutput.Text = "";
			this.richTextBox_ConsoleOutput.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox_ConsoleOutput_MouseUp);
			// 
			// ConsoleOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.richTextBox_ConsoleOutput);
			this.Controls.Add(this.checkBox_ShowDate);
			this.Controls.Add(this.checkBox_ShowTime);
			this.Controls.Add(this.checkBox_ShowUsername);
			this.Controls.Add(this.checkBox_ShowMessage);
			this.Controls.Add(this.button_TestOutput);
			this.ForeColor = System.Drawing.Color.White;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ConsoleOutput";
			this.Size = new System.Drawing.Size(640, 480);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
	    private System.Windows.Forms.CheckBox checkBox_ShowDate;
		private System.Windows.Forms.CheckBox checkBox_ShowTime;
		private System.Windows.Forms.CheckBox checkBox_ShowUsername;
		private System.Windows.Forms.CheckBox checkBox_ShowMessage;
		private System.Windows.Forms.Button button_TestOutput;
		private Components.RichTextBox_FormattedBlack richTextBox_ConsoleOutput;
	}
}
