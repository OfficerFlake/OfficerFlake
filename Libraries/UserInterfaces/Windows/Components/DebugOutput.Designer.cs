namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
    partial class DebugOutput
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusValue = new System.Windows.Forms.ToolStripStatusLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.Black;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusValue});
			this.statusStrip1.Location = new System.Drawing.Point(0, 458);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(640, 22);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(82, 17);
			this.toolStripStatusLabel.Text = "Latest Update:";
			// 
			// toolStripStatusValue
			// 
			this.toolStripStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.toolStripStatusValue.Name = "toolStripStatusValue";
			this.toolStripStatusValue.Size = new System.Drawing.Size(74, 17);
			this.toolStripStatusValue.Text = "<No Action>";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Com.OfficerFlake.Libraries.UserInterfaces.Resources.MenuBar;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(ShowDebugMenu);
			// 
			// DebugOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.richTextBox_ConsoleOutput);
			this.ForeColor = System.Drawing.Color.White;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "DebugOutput";
			this.Size = new System.Drawing.Size(640, 480);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private Components.RichTextBox_FormattedBlack richTextBox_ConsoleOutput;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusValue;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
