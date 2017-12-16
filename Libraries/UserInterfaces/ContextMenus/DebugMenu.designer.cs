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
			this.showDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showCrashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.showDebugToolStripMenuItem,
            this.showInformationToolStripMenuItem,
            this.showWarningToolStripMenuItem,
            this.showErrorToolStripMenuItem,
            this.showCrashToolStripMenuItem});
			this.showMessageToolStripMenuItem.Name = "showMessageToolStripMenuItem";
			this.showMessageToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.showMessageToolStripMenuItem.Text = "Show Messages";
			this.showMessageToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showDebugToolStripMenuItem
			// 
			this.showDebugToolStripMenuItem.Checked = true;
			this.showDebugToolStripMenuItem.CheckOnClick = true;
			this.showDebugToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDebugToolStripMenuItem.Name = "showDebugToolStripMenuItem";
			this.showDebugToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showDebugToolStripMenuItem.Text = "Debug";
			this.showDebugToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showInformationToolStripMenuItem
			// 
			this.showInformationToolStripMenuItem.Checked = true;
			this.showInformationToolStripMenuItem.CheckOnClick = true;
			this.showInformationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showInformationToolStripMenuItem.Name = "showInformationToolStripMenuItem";
			this.showInformationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showInformationToolStripMenuItem.Text = "Information";
			this.showInformationToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showWarningToolStripMenuItem
			// 
			this.showWarningToolStripMenuItem.Checked = true;
			this.showWarningToolStripMenuItem.CheckOnClick = true;
			this.showWarningToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showWarningToolStripMenuItem.Name = "showWarningToolStripMenuItem";
			this.showWarningToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showWarningToolStripMenuItem.Text = "Warning";
			this.showWarningToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showErrorToolStripMenuItem
			// 
			this.showErrorToolStripMenuItem.Checked = true;
			this.showErrorToolStripMenuItem.CheckOnClick = true;
			this.showErrorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showErrorToolStripMenuItem.Name = "showErrorToolStripMenuItem";
			this.showErrorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showErrorToolStripMenuItem.Text = "Error";
			this.showErrorToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// showCrashToolStripMenuItem
			// 
			this.showCrashToolStripMenuItem.Checked = true;
			this.showCrashToolStripMenuItem.CheckOnClick = true;
			this.showCrashToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showCrashToolStripMenuItem.Name = "showCrashToolStripMenuItem";
			this.showCrashToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showCrashToolStripMenuItem.Text = "Crash";
			this.showCrashToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
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
		public System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showDebugToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showWarningToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showErrorToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showCrashToolStripMenuItem;
	}
}
