namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	partial class ClickableMenu
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
			this.contextMenuStrip_ClickableMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_default = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip_ClickableMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip_ClickableMenu
			// 
			this.contextMenuStrip_ClickableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_default});
			this.contextMenuStrip_ClickableMenu.Name = "contextMenuStrip_UserObject";
			this.contextMenuStrip_ClickableMenu.Size = new System.Drawing.Size(231, 48);
			// 
			// toolStripMenuItem_default
			// 
			this.toolStripMenuItem_default.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.toolStripMenuItem_default.Name = "toolStripMenuItem_default";
			this.toolStripMenuItem_default.Size = new System.Drawing.Size(230, 22);
			this.toolStripMenuItem_default.Text = "<No Menu Chosen To Show!>";
			// 
			// ClickableMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ClickableMenu";
			this.Size = new System.Drawing.Size(189, 130);
			this.contextMenuStrip_ClickableMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ContextMenuStrip contextMenuStrip_ClickableMenu;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_default;
	}
}
