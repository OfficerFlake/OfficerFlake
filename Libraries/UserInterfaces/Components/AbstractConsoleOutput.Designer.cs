namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
    partial class AbstractConsoleOutput
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
			this.richTextBox_ConsoleOutput = new Com.OfficerFlake.Libraries.UserInterfaces.Windows.Components.RichTextBox_FormattedBlack();
			this.statusStrip_StatusBar = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel_LastUpdate_Label = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_LastUpdate_Value = new System.Windows.Forms.ToolStripStatusLabel();
			this.pictureBox_MessagesMenu = new System.Windows.Forms.PictureBox();
			this.statusStrip_StatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_MessagesMenu)).BeginInit();
			this.SuspendLayout();
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
			// statusStrip_StatusBar
			// 
			this.statusStrip_StatusBar.BackColor = System.Drawing.Color.Black;
			this.statusStrip_StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_LastUpdate_Label,
            this.toolStripStatusLabel_LastUpdate_Value});
			this.statusStrip_StatusBar.Location = new System.Drawing.Point(0, 458);
			this.statusStrip_StatusBar.Name = "statusStrip_StatusBar";
			this.statusStrip_StatusBar.Size = new System.Drawing.Size(640, 22);
			this.statusStrip_StatusBar.SizingGrip = false;
			this.statusStrip_StatusBar.TabIndex = 8;
			this.statusStrip_StatusBar.Text = "statusStrip1";
			// 
			// toolStripStatusLabel_LastUpdate_Label
			// 
			this.toolStripStatusLabel_LastUpdate_Label.Name = "toolStripStatusLabel_LastUpdate_Label";
			this.toolStripStatusLabel_LastUpdate_Label.Size = new System.Drawing.Size(82, 17);
			this.toolStripStatusLabel_LastUpdate_Label.Text = "Latest Update:";
			// 
			// toolStripStatusLabel_LastUpdate_Value
			// 
			this.toolStripStatusLabel_LastUpdate_Value.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.toolStripStatusLabel_LastUpdate_Value.Name = "toolStripStatusLabel_LastUpdate_Value";
			this.toolStripStatusLabel_LastUpdate_Value.Size = new System.Drawing.Size(74, 17);
			this.toolStripStatusLabel_LastUpdate_Value.Text = "<No Action>";
			// 
			// pictureBox_MessagesMenu
			// 
			this.pictureBox_MessagesMenu.Image = global::Com.OfficerFlake.Libraries.UserInterfaces.Resources.MenuBar;
			this.pictureBox_MessagesMenu.Location = new System.Drawing.Point(0, 0);
			this.pictureBox_MessagesMenu.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox_MessagesMenu.Name = "pictureBox_MessagesMenu";
			this.pictureBox_MessagesMenu.Size = new System.Drawing.Size(24, 24);
			this.pictureBox_MessagesMenu.TabIndex = 9;
			this.pictureBox_MessagesMenu.TabStop = false;
			this.pictureBox_MessagesMenu.Click += new System.EventHandler(this.ShowMessageControlMenu);
			// 
			// _ConsoleOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.pictureBox_MessagesMenu);
			this.Controls.Add(this.statusStrip_StatusBar);
			this.Controls.Add(this.richTextBox_ConsoleOutput);
			this.ForeColor = System.Drawing.Color.White;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "_ConsoleOutput";
			this.Size = new System.Drawing.Size(640, 480);
			this.statusStrip_StatusBar.ResumeLayout(false);
			this.statusStrip_StatusBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_MessagesMenu)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private Components.RichTextBox_FormattedBlack richTextBox_ConsoleOutput;
		private System.Windows.Forms.StatusStrip statusStrip_StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LastUpdate_Label;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LastUpdate_Value;
		private System.Windows.Forms.PictureBox pictureBox_MessagesMenu;
	}
}
