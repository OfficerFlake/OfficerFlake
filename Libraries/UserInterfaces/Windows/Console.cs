using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Com.OfficerFlake.Libraries.RichText;
using static Com.OfficerFlake.Libraries.RichText.RichTextMessage;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public partial class _Console : Form
	{
		#region Loading
		private void _Console_Load(object sender, EventArgs e)
		{
			this.consoleOutput.FormClosing.Reset();
			IsClosed = false;
			IsLoaded = true;
			_Hide();
		}
		private ManualResetEvent _IsLoaded = new ManualResetEvent(false);
		public bool IsLoaded
		{
			get
			{
				bool output = _IsLoaded.WaitOne(0);
				return output;
			}
			set
			{
				if (value) _IsLoaded.Set();
				else _IsLoaded.Reset();
			}
		}
		public bool WaitForLoad() => IsHandleCreated | _IsLoaded.WaitOne();
		#endregion
		public _Console()
		{
			InitializeComponent();
			CreateControl();
			//WaitForLoad();
			Hide();
			//this.WindowState = FormWindowState.Minimized;
			//this.ShowInTaskbar = false;
		}

		#region Closing
		private void _Console_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.consoleOutput.FormClosing.Set();
			IsClosed = true;
			IsLoaded = false;
		}
		private ManualResetEvent _IsClosed = new ManualResetEvent(true);
		public bool IsClosed
		{
			get => _IsClosed.WaitOne(0);
			set
			{
				if (value) _IsClosed.Set();
				else _IsClosed.Reset();
			}
		}
		public bool WaitForClose() => _IsClosed.WaitOne();
		#endregion

		internal void _Show()
		{
			Visible = true;
			ShowInTaskbar = true;
			Show();
			Refresh();
		}
		internal void _Hide()
		{
			Visible = false;
			ShowInTaskbar = false;
			Hide();
			Refresh();
		}
	}

	public static class Console
	{
		private static _Console _Console = new _Console();
		private static bool WaitForLoad() => _Console.WaitForLoad();
		public static bool WaitForClose() => _Console.WaitForClose();

		static Console()
		{
			Thread consoleThread = _Console.NewWindowThread();
			WaitForLoad();
		}

		public static void Show()
		{
			_Console.Invoke((MethodInvoker) delegate()
			{
				_Console._Show();
			});
		}
		public static void Hide()
		{
			_Console.Invoke((MethodInvoker) delegate()
			{
				_Console._Hide();
			});
		}

		#region Messages
		private static void AddMessage(RichTextMessage thisRichTextMessage)
		{
			_Console.consoleOutput.AddMessage(thisRichTextMessage);
		}
		public static void AddCrashMessage(string input) => AddMessage(new CrashMessage(input));
		public static void AddErrorMessage(string input) => AddMessage(new ErrorMessage(input));
		public static void AddWarningMessage(string input) => AddMessage(new WarningMessage(input));
		public static void AddDebugMessage(string input) => AddMessage(new DebugMessage(input));
		public static void AddInformationMessage(string input) => AddMessage(new InformationMessage(input));
		public static void AddUserMessage(Database.User thisUser, string input) => AddMessage(new UserMessage(thisUser, input));
		#endregion
	}

}
