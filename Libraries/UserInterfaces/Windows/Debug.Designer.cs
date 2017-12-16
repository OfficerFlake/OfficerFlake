using System;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public partial class _Debug
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Debug));
			this.SuspendLayout();
			// 
			// debugOutput
			//
			this.debugOutput = new DebugOutput();
			this.debugOutput.BackColor = System.Drawing.Color.Black;
			this.debugOutput.ForeColor = System.Drawing.Color.White;
			this.debugOutput.Location = new System.Drawing.Point(0, 0);
			this.debugOutput.Margin = new System.Windows.Forms.Padding(0);
			this.debugOutput.Name = "debugOutput";
			this.debugOutput.Size = new System.Drawing.Size(640, 480);
			this.debugOutput.TabIndex = 0;
			// 
			// _Debug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.debugOutput);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "_Debug";
			this.Text = "Debug";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this._Console_FormClosing);
			this.Load += new System.EventHandler(this._Console_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public DebugOutput debugOutput;
	}
}