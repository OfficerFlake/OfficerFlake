using System;
using System.Windows.Forms;

namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	public partial class DebugMessagesMenu : ClickableMenu
	{
		public DebugMessagesMenu()
		{
			InitializeComponent();
			base.MenuToShow = contextMenuStrip_DebugMenu;
		}

		public event EventHandler MenuItemChanged;
		public void OnMenuItemChanged(object sender, EventArgs e)
		{
			MenuItemChanged?.Invoke(sender, e);
		}
	}
}
