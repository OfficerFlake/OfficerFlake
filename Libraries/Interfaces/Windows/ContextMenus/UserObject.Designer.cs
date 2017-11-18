namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	partial class UserObject
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
			this.components = new System.ComponentModel.Container();
			this.contextMenuStrip_UserObject = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.administrativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.banToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip_UserObject.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip_UserObject
			// 
			this.contextMenuStrip_UserObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.administrativeToolStripMenuItem});
			this.contextMenuStrip_UserObject.Name = "contextMenuStrip_UserObject";
			this.contextMenuStrip_UserObject.Size = new System.Drawing.Size(153, 70);
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.infoToolStripMenuItem.Text = "Info";
			this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
			// 
			// administrativeToolStripMenuItem
			// 
			this.administrativeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freezeToolStripMenuItem,
            this.kickToolStripMenuItem,
            this.banToolStripMenuItem});
			this.administrativeToolStripMenuItem.Name = "administrativeToolStripMenuItem";
			this.administrativeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.administrativeToolStripMenuItem.Text = "Administrative";
			// 
			// freezeToolStripMenuItem
			// 
			this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
			this.freezeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.freezeToolStripMenuItem.Text = "Freeze";
			this.freezeToolStripMenuItem.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
			// 
			// kickToolStripMenuItem
			// 
			this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
			this.kickToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.kickToolStripMenuItem.Text = "Kick";
			this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
			// 
			// banToolStripMenuItem
			// 
			this.banToolStripMenuItem.Name = "banToolStripMenuItem";
			this.banToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.banToolStripMenuItem.Text = "Ban";
			this.banToolStripMenuItem.Click += new System.EventHandler(this.banToolStripMenuItem_Click);
			// 
			// UserObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "UserObject";
			this.Size = new System.Drawing.Size(189, 130);
			this.contextMenuStrip_UserObject.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_UserObject;
		private System.Windows.Forms.ToolStripMenuItem administrativeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem banToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
	}
}
