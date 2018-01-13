using System;
using System.Threading;
using System.Windows;
using System.Windows.Media.TextFormatting;
using System.Windows.Threading;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UserInterfacesWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class ConsoleWindow : Window
	{
		#region Creation
		public ConsoleWindow()
		{
			Visibility = Visibility.Hidden;
			ShowInTaskbar = false;
			InitializeComponent();
		}
		public void LinkConsole()
		{
			Logger.Console.LinkConsole(ConsoleOutput);
		}
		public void LinkDebug()
		{
			Logger.Debug.LinkDebug(ConsoleOutput);
		}
		#endregion
		#region Load/Close
		#region Load
		private void OnLoaded(object sender, EventArgs e)
		{
			LoadedSignal.Set();
		}
		public readonly ManualResetEvent LoadedSignal = new ManualResetEvent(false);
		public Boolean IsLoadd => LoadedSignal.WaitOne(0);
		public Boolean WaitForLoad(int timeout = Int32.MaxValue) => LoadedSignal.WaitOne(timeout);
		#endregion
		#region Close
		private void OnClosed(object sender, EventArgs e)
		{
			ClosedSignal.Set();
		}
		public readonly ManualResetEvent ClosedSignal = new ManualResetEvent(false);
		public Boolean IsClosed => ClosedSignal.WaitOne(0);
		public Boolean WaitForClose(int timeout = Int32.MaxValue) => ClosedSignal.WaitOne(timeout);
		#endregion
		#endregion

		#region Properties

		#endregion
	}

	/// <summary>
	/// UI Window for the Server Program. All Console/Debug Messages come through here.
	/// </summary>
	public static class OpenYSServerModeUserInterface
	{
		public static ConsoleWindow consoleWindow;

		#region Creation
		public static void CreateWindow()
		{
			ManualResetEvent ready = new ManualResetEvent(false);
			Thread newThread = new Thread(() =>
			{
				Application newApp = new Application();
				consoleWindow = new ConsoleWindow();
				ready.Set();
				newApp.Run();
			});
			newThread.SetApartmentState(ApartmentState.STA);
			newThread.Start();
			ready.WaitOne();
			ready.Dispose();
		}
		public static void LinkConsole() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.LinkConsole());
		public static void LinkDebug() => consoleWindow.Dispatcher.Invoke(() => consoleWindow.LinkDebug());
		#endregion
		#region Show/Hide
		public static void Show() => consoleWindow.Dispatcher.Invoke(() =>
		{
			consoleWindow.ShowInTaskbar = true;
			consoleWindow.Visibility = Visibility.Visible;
			consoleWindow.Show();
		});
		public static void Hide() => consoleWindow.Dispatcher.Invoke(() =>
		{
			consoleWindow.ShowInTaskbar = false;
			consoleWindow.Visibility = Visibility.Hidden;
			consoleWindow.Hide();
		});
		#endregion
		#region Wait Load/Close
		public static bool WaitForLoad(int timeout = Int32.MaxValue) => consoleWindow.Dispatcher.Invoke(() => (consoleWindow.IsVisible) || consoleWindow.WaitForLoad(timeout));
		public static bool WaitForClose(int timeout = Int32.MaxValue) => (!consoleWindow.IsVisible) || consoleWindow.WaitForClose(timeout);
		#endregion
	}
}
