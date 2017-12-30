using System;
using System.Threading;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public partial class _Console : Form, IConsole
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

		public void AddUserMessage(IUser user, string message)
		{
			consoleOutput.AddMessage(ObjectFactory.CreateConsoleUserMessage(user, message.AsRichTextString()));
		}

		public void AddInformationMessage(string message)
		{
			consoleOutput.AddMessage(ObjectFactory.CreateConsoleInformationMessage((message).AsRichTextString()));
		}

	}

	public static class ConsoleUI
	{
		private static _Console _console = new _Console();
		public static void LinkConsole()
		{
			Logger.Console.LinkConsole(_console);
		}

		private static bool WaitForLoad() => _console.WaitForLoad();
		public static bool WaitForClose() => _console.WaitForClose();

		static ConsoleUI()
		{
			Thread consoleThread = _console.NewWindowThread();
			WaitForLoad();
		}

		public static void Show()
		{
			_console.Invoke((MethodInvoker) delegate()
			{
				_console._Show();
			});
		}
		public static void Hide()
		{
			_console.Invoke((MethodInvoker) delegate()
			{
				_console._Hide();
			});
		}

		public static void Close()
		{
			_console.Invoke((MethodInvoker)delegate ()
			{
				_console.Close();
			});
		}

		#region Messages
		public static void AddConsoleInformationMessage(string input) => _console.AddInformationMessage(input);
		public static void AddUserMessage(IUser user, string input) => _console.AddUserMessage(user, input);
		#endregion
	}

}
