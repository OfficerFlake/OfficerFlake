namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	partial class ConsoleMessagesMenu
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
			this.contextMenuStrip_ConsoleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_ShowDate = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_ShowTime = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_ShowType = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_ShowMessage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_ShowMessage_ConsoleUser = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_ShowMessage_ConsoleInformation = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip_ConsoleMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip_ConsoleMenu
			// 
			this.contextMenuStrip_ConsoleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowDate,
            this.toolStripMenuItem_ShowTime,
            this.toolStripMenuItem_ShowType,
            this.toolStripMenuItem_ShowMessage});
			this.contextMenuStrip_ConsoleMenu.Name = "contextMenuStrip_UserObject";
			this.contextMenuStrip_ConsoleMenu.Size = new System.Drawing.Size(158, 114);
			// 
			// toolStripMenuItem_ShowDate
			// 
			this.toolStripMenuItem_ShowDate.Checked = true;
			this.toolStripMenuItem_ShowDate.CheckOnClick = true;
			this.toolStripMenuItem_ShowDate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ShowDate.Name = "toolStripMenuItem_ShowDate";
			this.toolStripMenuItem_ShowDate.Size = new System.Drawing.Size(157, 22);
			this.toolStripMenuItem_ShowDate.Text = "Show Date";
			this.toolStripMenuItem_ShowDate.Click += new System.EventHandler(this.OnMenuItemChanged);
			// 
			// toolStripMenuItem_ShowTime
			// 
			this.toolStripMenuItem_ShowTime.Checked = true;
			this.toolStripMenuItem_ShowTime.CheckOnClick = true;
			this.toolStripMenuItem_ShowTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ShowTime.Name = "toolStripMenuItem_ShowTime";
			this.toolStripMenuItem_ShowTime.Size = new System.Drawing.Size(157, 22);
			this.toolStripMenuItem_ShowTime.Text = "Show Time";
			this.toolStripMenuItem_ShowTime.Click += new System.EventHandler(this.OnMenuItemChanged);
			// 
			// toolStripMenuItem_ShowType
			// 
			this.toolStripMenuItem_ShowType.Checked = true;
			this.toolStripMenuItem_ShowType.CheckOnClick = true;
			this.toolStripMenuItem_ShowType.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ShowType.Name = "toolStripMenuItem_ShowType";
			this.toolStripMenuItem_ShowType.Size = new System.Drawing.Size(157, 22);
			this.toolStripMenuItem_ShowType.Text = "Show Type";
			this.toolStripMenuItem_ShowType.Click += new System.EventHandler(this.OnMenuItemChanged);
			// 
			// toolStripMenuItem_ShowMessage
			// 
			this.toolStripMenuItem_ShowMessage.Checked = true;
			this.toolStripMenuItem_ShowMessage.CheckOnClick = true;
			this.toolStripMenuItem_ShowMessage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ShowMessage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowMessage_ConsoleUser,
            this.toolStripMenuItem_ShowMessage_ConsoleInformation});
			this.toolStripMenuItem_ShowMessage.Name = "toolStripMenuItem_ShowMessage";
			this.toolStripMenuItem_ShowMessage.Size = new System.Drawing.Size(157, 22);
			this.toolStripMenuItem_ShowMessage.Text = "Show Messages";
			this.toolStripMenuItem_ShowMessage.Click += new System.EventHandler(this.OnMenuItemChanged);
			// 
			// toolStripMenuItem_ShowMessage_ConsoleUser
			// 
			this.toolStripMenuItem_ShowMessage_ConsoleUser.Checked = true;
			this.toolStripMenuItem_ShowMessage_ConsoleUser.CheckOnClick = true;
			this.toolStripMenuItem_ShowMessage_ConsoleUser.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ShowMessage_ConsoleUser.Name = "toolStripMenuItem_ShowMessage_ConsoleUser";
			this.toolStripMenuItem_ShowMessage_ConsoleUser.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem_ShowMessage_ConsoleUser.Text = "User";
			this.toolStripMenuItem_ShowMessage_ConsoleUser.Click += new System.EventHandler(this.OnMenuItemChanged);
			// 
			// toolStripMenuItem_ShowMessage_ConsoleInformation
			// 
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.Checked = true;
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.CheckOnClick = true;
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.Name = "toolStripMenuItem_ShowMessage_ConsoleInformation";
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.Text = "Information";
			this.toolStripMenuItem_ShowMessage_ConsoleInformation.Click += new System.EventHandler(this.OnMenuItemChanged);
			// 
			// ConsoleMessagesMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ConsoleMessagesMenu";
			this.contextMenuStrip_ConsoleMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ContextMenuStrip contextMenuStrip_ConsoleMenu;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDate;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowTime;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowType;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowMessage;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowMessage_ConsoleUser;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowMessage_ConsoleInformation;
	}
}
