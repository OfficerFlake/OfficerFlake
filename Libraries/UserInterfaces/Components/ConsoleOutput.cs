using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public sealed partial class ConsoleOutput : AbstractConsoleOutput
    {
		#region Constructor
		internal ConsoleOutput()
		{
			LinkMessagesMenu(MessagesMenu);
			MessagesMenu.MenuItemChanged += OnMenuOptionsChanged;
			ShowMessage_ConsoleInformation = true;
			ShowMessage_ConsoleUser = true;
		}
		#endregion
		#region Variables
		protected ConsoleMessagesMenu MessagesMenu { get; set; } = new ConsoleMessagesMenu();
		#endregion
		#region Events
		private void OnMenuOptionsChanged(object sender, EventArgs e)
		{
			ShowDate = MessagesMenu.toolStripMenuItem_ShowDate.Checked;
			ShowTime = MessagesMenu.toolStripMenuItem_ShowTime.Checked;
			ShowType = MessagesMenu.toolStripMenuItem_ShowType.Checked;
			ShowMessage = MessagesMenu.toolStripMenuItem_ShowMessage.Checked;

			ShowMessage_ConsoleUser = MessagesMenu.toolStripMenuItem_ShowMessage_ConsoleUser.Checked;
			ShowMessage_ConsoleInformation = MessagesMenu.toolStripMenuItem_ShowMessage_ConsoleInformation.Checked;
			OnMessagesOptionChanged(sender, e);
		}
		#endregion
    }
}
