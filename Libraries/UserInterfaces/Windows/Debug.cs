using System;
using System.Threading;
using System.Windows.Forms;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public partial class _Debug : Form, IDebug
	{
		#region Loading
		private void _Console_Load(object sender, EventArgs e)
		{
			this.debugOutput.FormClosing.Reset();
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
		public _Debug()
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
			this.debugOutput.FormClosing.Set();
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

		public void AddSummaryMessage(string message)
		{
			debugOutput.AddMessage(ObjectFactory.CreateDebugSummaryMessage(message.AsRichTextString()));
		}
		public void AddDetailMessage(string message)
		{
			debugOutput.AddMessage(ObjectFactory.CreateDebugDetailMessage(message.AsRichTextString()));
		}
		public void AddWarningMessage(string message)
		{
			debugOutput.AddMessage(ObjectFactory.CreateDebugWarningMessage(message.AsRichTextString()));
		}
		public void AddErrorMessage(Exception e, string message)
		{
			debugOutput.AddMessage(ObjectFactory.CreateDebugErrorMessage(e, message.AsRichTextString()));
		}
		public void AddCrashMessage(Exception e, string message)
		{
			debugOutput.AddMessage(ObjectFactory.CreateDebugCrashMessage(e, message.AsRichTextString()));
		}
	}

	public static class DebugUI
	{
		private static _Debug _Debug = new _Debug();

		public static void LinkDebug()
		{
			Logger.Debug.LinkDebug(_Debug);
		}
		private static bool WaitForLoad() => _Debug.WaitForLoad();
		public static bool WaitForClose() => _Debug.WaitForClose();

		static DebugUI()
		{
			Thread debugThread = _Debug.NewWindowThread();
			WaitForLoad();
		}

		public static void Show()
		{
			_Debug.Invoke((MethodInvoker) delegate()
			{
				_Debug._Show();
			});
		}
		public static void Hide()
		{
			_Debug.Invoke((MethodInvoker) delegate()
			{
				_Debug._Hide();
			});
		}

		#region Messages
		private static void AddMessage(IRichTextMessage thisRichTextMessage)
		{
			_Debug.debugOutput.AddMessage(thisRichTextMessage);
		}
		
		public static void AddSummaryMessage(string input) => AddMessage(ObjectFactory.CreateDebugSummaryMessage(input.AsRichTextString()));
		public static void AddDetailMessage(string input) => AddMessage(ObjectFactory.CreateDebugDetailMessage(input.AsRichTextString()));
		public static void AddWarningMessage(string input) => AddMessage(ObjectFactory.CreateDebugWarningMessage(input.AsRichTextString()));
		public static void AddErrorMessage(Exception e, string input) => AddMessage(ObjectFactory.CreateDebugErrorMessage(e, input.AsRichTextString()));
		public static void AddCrashMessage(Exception e, string input) => AddMessage(ObjectFactory.CreateDebugCrashMessage(e, input.AsRichTextString()));
		#endregion
	}

}
