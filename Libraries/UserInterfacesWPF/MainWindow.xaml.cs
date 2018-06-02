using System;
using System.Threading;
using System.Windows;
using System.Windows.Media.TextFormatting;
using System.Windows.Threading;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class ServerModeUserInterface : OYS_Window
	{
		public ServerModeUserInterface()
		{
			InitializeComponent();
		}

		#region Properties
		public Boolean ShowConsoleMessages { get; set; } = true;
		public Boolean ShowDebugMessages { get; set; } = true;
		#endregion
		#region Methods
		public void LinkConsole()
		{
			Logger.Console.LinkConsole(ConsoleOutputView);
		}
		public void LinkDebug()
		{
			Logger.Debug.LinkDebug(ConsoleOutputView);
		}

		public void ClearAllMessages()
		{
			ConsoleOutputView.ClearAllMessages();
		}
		public void ClearConsoleMessages()
		{
			ConsoleOutputView.ClearConsoleMessages();
		}
		public void ClearDebugMessages()
		{
			ConsoleOutputView.ClearDebugMessages();
		}
		#endregion
	}

	/// <summary>
	/// UI Window for the Server Program. All Console/Debug Messages come through here.
	/// </summary>
	public static class OpenYSServerModeUserInterface
	{
		private static ServerModeUserInterface consoleWindow;

		#region Create/Close
		public static void CreateWindow() => consoleWindow = UserInterface.CreateWindow<ServerModeUserInterface>();
		public static void CloseWindow() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.Close());
		#endregion
		#region Show/Hide
		public static void Show() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.Show());
		public static void Hide() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.Hide());
		#endregion
		#region Wait Load/Close
		public static bool WaitForCreation(int timeout = Int32.MaxValue) => consoleWindow.Dispatcher.Invoke(() => consoleWindow.WaitForCreation(timeout));
		public static bool WaitForClose(int timeout = Int32.MaxValue) => consoleWindow.WaitForClose(timeout);
		#endregion

		public static void LinkConsole() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.LinkConsole());
		public static void LinkDebug() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.LinkDebug());

		public static void ClearAllMessages() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.ClearAllMessages());
		public static void ClearConsoleMessages() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.ClearConsoleMessages());
		public static void ClearDebugMessages() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.ClearDebugMessages());
	}
}
