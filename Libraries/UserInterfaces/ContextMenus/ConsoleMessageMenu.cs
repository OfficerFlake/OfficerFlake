using System;
using System.Windows.Forms;

namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	public partial class ConsoleMessagesMenu : ClickableMenu
	{
		public ConsoleMessagesMenu()
		{
			InitializeComponent();
			base.MenuToShow = contextMenuStrip_ConsoleMenu;
		}

		public event EventHandler MenuItemChanged;
		public void OnMenuItemChanged(object sender, EventArgs e)
		{
			MenuItemChanged?.Invoke(sender,e);
		}
	}
}
