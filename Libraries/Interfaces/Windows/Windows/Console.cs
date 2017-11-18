using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.RichTextMessages;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public partial class Console : Form
	{
		public Console()
		{
			InitializeComponent();
		}

		private void Console_FormClosing(object sender, FormClosingEventArgs e)
		{
			consoleOutput.FormClosing = true;
		}
	}
}
