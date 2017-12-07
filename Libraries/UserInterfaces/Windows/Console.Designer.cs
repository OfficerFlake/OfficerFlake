using System;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public partial class _Console
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Console));
			this.SuspendLayout();
			// 
			// consoleOutput
			//
			this.consoleOutput = new ConsoleOutput();
			this.consoleOutput.BackColor = System.Drawing.Color.Black;
			this.consoleOutput.ForeColor = System.Drawing.Color.White;
			this.consoleOutput.Location = new System.Drawing.Point(0, 0);
			this.consoleOutput.Margin = new System.Windows.Forms.Padding(0);
			this.consoleOutput.Name = "consoleOutput";
			this.consoleOutput.Size = new System.Drawing.Size(640, 480);
			this.consoleOutput.TabIndex = 0;
			// 
			// _Console
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.consoleOutput);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "_Console";
			this.Text = "Console";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this._Console_FormClosing);
			this.Load += new System.EventHandler(this._Console_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public ConsoleOutput consoleOutput;
	}
}