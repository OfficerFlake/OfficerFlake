using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Com.OfficerFlake.Libraries.UserInterfaces.ContextMenus
{
	public partial class DebugMenu : UserControl
	{
		public DebugMenu()
		{
			InitializeComponent();
		}

		public new void Show()
		{
			base.Show();
			contextMenuStrip_DebugMenu.Show(MousePosition);
		}

			
		public event EventHandler UpdateRequired;

		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateRequired?.Invoke(this, e);
		}
	}
}
