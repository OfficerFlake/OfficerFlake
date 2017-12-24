namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	partial class DebugMenu
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
			this.contextMenuStrip_DebugMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDebugSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDebugDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDebugWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDebugErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showDebugCrashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip_DebugMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip_DebugMenu
			// 
			this.contextMenuStrip_DebugMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDateToolStripMenuItem,
            this.showTimeToolStripMenuItem,
            this.showTypeToolStripMenuItem,
            this.showMessageToolStripMenuItem});
			this.contextMenuStrip_DebugMenu.Name = "contextMenuStrip_UserObject";
			this.contextMenuStrip_DebugMenu.Size = new System.Drawing.Size(158, 92);
			// 
			// showDateToolStripMenuItem
			// 
			this.showDateToolStripMenuItem.Checked = true;
			this.showDateToolStripMenuItem.CheckOnClick = true;
			this.showDateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDateToolStripMenuItem.Name = "showDateToolStripMenuItem";
			this.showDateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.showDateToolStripMenuItem.Text = "Show Date";
			this.showDateToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showTimeToolStripMenuItem
			// 
			this.showTimeToolStripMenuItem.Checked = true;
			this.showTimeToolStripMenuItem.CheckOnClick = true;
			this.showTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showTimeToolStripMenuItem.Name = "showTimeToolStripMenuItem";
			this.showTimeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.showTimeToolStripMenuItem.Text = "Show Time";
			this.showTimeToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showTypeToolStripMenuItem
			// 
			this.showTypeToolStripMenuItem.Checked = true;
			this.showTypeToolStripMenuItem.CheckOnClick = true;
			this.showTypeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showTypeToolStripMenuItem.Name = "showTypeToolStripMenuItem";
			this.showTypeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.showTypeToolStripMenuItem.Text = "Show Type";
			this.showTypeToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showMessageToolStripMenuItem
			// 
			this.showMessageToolStripMenuItem.Checked = true;
			this.showMessageToolStripMenuItem.CheckOnClick = true;
			this.showMessageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showMessageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDebugSummaryToolStripMenuItem,
            this.showDebugDetailToolStripMenuItem,
            this.showDebugWarningToolStripMenuItem,
            this.showDebugErrorToolStripMenuItem,
            this.showDebugCrashToolStripMenuItem});
			this.showMessageToolStripMenuItem.Name = "showMessageToolStripMenuItem";
			this.showMessageToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.showMessageToolStripMenuItem.Text = "Show Messages";
			this.showMessageToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showDebugSummaryToolStripMenuItem
			// 
			this.showDebugSummaryToolStripMenuItem.Checked = true;
			this.showDebugSummaryToolStripMenuItem.CheckOnClick = true;
			this.showDebugSummaryToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDebugSummaryToolStripMenuItem.Name = "showDebugSummaryToolStripMenuItem";
			this.showDebugSummaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showDebugSummaryToolStripMenuItem.Text = "Summary";
			this.showDebugSummaryToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showDebugDetailToolStripMenuItem
			// 
			this.showDebugDetailToolStripMenuItem.Checked = true;
			this.showDebugDetailToolStripMenuItem.CheckOnClick = true;
			this.showDebugDetailToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDebugDetailToolStripMenuItem.Name = "showDebugDetailToolStripMenuItem";
			this.showDebugDetailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showDebugDetailToolStripMenuItem.Text = "Detail";
			this.showDebugDetailToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showDebugWarningToolStripMenuItem
			// 
			this.showDebugWarningToolStripMenuItem.Checked = true;
			this.showDebugWarningToolStripMenuItem.CheckOnClick = true;
			this.showDebugWarningToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDebugWarningToolStripMenuItem.Name = "showDebugWarningToolStripMenuItem";
			this.showDebugWarningToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showDebugWarningToolStripMenuItem.Text = "Warning";
			this.showDebugWarningToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showDebugErrorToolStripMenuItem
			// 
			this.showDebugErrorToolStripMenuItem.Checked = true;
			this.showDebugErrorToolStripMenuItem.CheckOnClick = true;
			this.showDebugErrorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDebugErrorToolStripMenuItem.Name = "showDebugErrorToolStripMenuItem";
			this.showDebugErrorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showDebugErrorToolStripMenuItem.Text = "Error";
			this.showDebugErrorToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showDebugCrashToolStripMenuItem
			// 
			this.showDebugCrashToolStripMenuItem.Checked = true;
			this.showDebugCrashToolStripMenuItem.CheckOnClick = true;
			this.showDebugCrashToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDebugCrashToolStripMenuItem.Name = "showDebugCrashToolStripMenuItem";
			this.showDebugCrashToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showDebugCrashToolStripMenuItem.Text = "Crash";
			this.showDebugCrashToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// DebugMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "DebugMenu";
			this.Size = new System.Drawing.Size(189, 130);
			this.contextMenuStrip_DebugMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ContextMenuStrip contextMenuStrip_DebugMenu;
		public System.Windows.Forms.ToolStripMenuItem showDateToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showTimeToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showTypeToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showMessageToolStripMenuItem;

		public System.Windows.Forms.ToolStripMenuItem showDebugSummaryToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showDebugDetailToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showDebugWarningToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showDebugErrorToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showDebugCrashToolStripMenuItem;
	}
}
