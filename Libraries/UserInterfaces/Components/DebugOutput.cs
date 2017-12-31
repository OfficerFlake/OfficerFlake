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
	public sealed partial class DebugOutput : AbstractConsoleOutput
    {
	    #region Constructor
	    internal DebugOutput()
	    {
		    LinkMessagesMenu(MessagesMenu);
		    MessagesMenu.MenuItemChanged += OnMenuOptionsChanged;
		    ShowMessage_DebugSummary = true;
		    ShowMessage_DebugDetail = true;
		    ShowMessage_DebugWarning = true;
		    ShowMessage_DebugError = true;
		    ShowMessage_DebugCrash = true;
	    }
	    #endregion
	    #region Variables
	    protected DebugMessagesMenu MessagesMenu { get; set; } = new DebugMessagesMenu();
	    #endregion
	    #region Events
	    private void OnMenuOptionsChanged(object sender, EventArgs e)
	    {
		    ShowDate = MessagesMenu.toolStripMenuItem_ShowDate.Checked;
		    ShowTime = MessagesMenu.toolStripMenuItem_ShowTime.Checked;
		    ShowType = MessagesMenu.toolStripMenuItem_ShowType.Checked;
		    ShowMessage = MessagesMenu.toolStripMenuItem_ShowMessage.Checked;

		    ShowMessage_DebugSummary = MessagesMenu.toolStripMenuItem_ShowMessage_DebugSummary.Checked;
		    ShowMessage_DebugDetail = MessagesMenu.toolStripMenuItem_ShowMessage_DebugDetail.Checked;
		    ShowMessage_DebugWarning = MessagesMenu.toolStripMenuItem_ShowMessage_DebugWarning.Checked;
		    ShowMessage_DebugError = MessagesMenu.toolStripMenuItem_ShowMessage_DebugError.Checked;
		    ShowMessage_DebugCrash = MessagesMenu.toolStripMenuItem_ShowMessage_DebugCrash.Checked;
		    OnMessagesOptionChanged(sender, e);
	    }
	    #endregion
	}
}
