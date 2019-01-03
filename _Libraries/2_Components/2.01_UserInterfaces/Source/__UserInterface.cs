using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace Com.OfficerFlake.Libraries.UserInterfaces
{
	public class OYS_Window : Window
	{
		protected OYS_Window() => Hide();

		#region Create
		protected void OnCreated(object sender, RoutedEventArgs e) => CreatedSignal.Set();
		private ManualResetEvent CreatedSignal { get; } = new ManualResetEvent(false);
		private Boolean IsCreated => CreatedSignal.WaitOne(0);
		#endregion
		#region Close
		protected void OnClosed(object sender, EventArgs e) => ClosedSignal.Set();
		private readonly ManualResetEvent ClosedSignal = new ManualResetEvent(false);
		private Boolean IsClosed => ClosedSignal.WaitOne(0);
		#endregion
		#region WaitForCreation/Close
		public Boolean WaitForCreation(Int32 Timeout = Int32.MaxValue) => CreatedSignal.WaitOne(Timeout);
		public Boolean WaitForClose(Int32 Timeout = Int32.MaxValue) => ClosedSignal.WaitOne(Timeout);
		#endregion
		#region Show/Hide
		public new void Show()
		{
			ShowInTaskbar = true;
			Visibility = Visibility.Visible;
			base.Show();
		}
		public new void Hide()
		{
			ShowInTaskbar = false;
			Visibility = Visibility.Hidden;
			base.Hide();
		}
		#endregion
	}
	public class UserInterfaceSingleton : IDisposable
	{
		public static UserInterfaceSingleton Instance { get; private set; } = null;
		public static UserInterfaceSingleton Instantiate()
		{
			if (Instantiated && Instance != null) return Instance;
			else return new UserInterfaceSingleton();
		}
		public static bool Instantiated => (Instance != null);
		public static bool Shutdown()
		{
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				foreach (Window thisWindow in Windows)
				{

					try
					{
						thisWindow.Close();
					}
					catch (Exception e)
					{
						Logger.Debug.AddErrorMessage(e, "Error shutting down");
					}
				}
			});
			Instance.Dispose();
			return true;
		}

		public static List<Window> Windows = new List<Window>();

		#region Create/Dispose
		private UserInterfaceSingleton()
		{
			Instance = this;
			Thread = new Thread(() =>
			{
				Application = new Application();
				Loaded.Set();
				Application.Run();
			});
			Thread.SetApartmentState(ApartmentState.STA);
			Thread.Start();
			Loaded.WaitOne();
		}
		public void Dispose()
		{
			Instance = null;
			Loaded.Dispose();
			Thread.Abort();
			return;
		}
		#endregion
		#region Properties
		public Thread Thread { get; set; }
		public Application Application { get; set; }
		public ManualResetEvent Loaded { get; } = new ManualResetEvent(false);
		public bool IsLoaded => Loaded.WaitOne(0);
		#endregion
		#region Methods
		public static T CreateWindow<T>() where T : OYS_Window, new()
		{
			T output = null;
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				output = new T();
			});
			Windows.Add(output);
			return output;
		}
		public static bool CloseWindow(OYS_Window window)
		{
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				window.Close();
			});
			Windows.Remove(window);
			return true;
		}
		public static bool WaitForWindowCreation(OYS_Window window, Int32 Timeout = Int32.MaxValue)
		{
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				window.WaitForCreation(Timeout);
			});
			return true;
		}
		public static bool WaitForWindowClose(OYS_Window window, Int32 Timeout = Int32.MaxValue)
		{
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				window.WaitForClose(Timeout);
			});
			return true;
		}
		public static bool ShowWindow(OYS_Window window)
		{
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				window.Show();
			});
			return true;
		}
		public static bool HideWindow(OYS_Window window)
		{
			Instance?.Application.Dispatcher.Invoke(() =>
			{
				window.Hide();
			});
			return true;
		}
		#endregion
	}

	public static class UserInterface
	{
		public static UserInterfaceSingleton Instance => UserInterfaceSingleton.Instance;
		public static UserInterfaceSingleton Initialise() => UserInterfaceSingleton.Instantiate();
		public static bool Shutdown() => UserInterfaceSingleton.Shutdown();

		public static T CreateWindow<T>() where T : OYS_Window, new() => UserInterfaceSingleton.CreateWindow<T>();
		public static bool CloseWindow(OYS_Window window) => UserInterfaceSingleton.CloseWindow(window);
		public static bool WaitForWindowLoad(OYS_Window window) => UserInterfaceSingleton.WaitForWindowCreation(window);
		public static bool WaitForWindowClose(OYS_Window window) => UserInterfaceSingleton.WaitForWindowClose(window);
		public static bool ShowWindow(OYS_Window window) => UserInterfaceSingleton.ShowWindow(window);
		public static bool HideWindow(OYS_Window window) => UserInterfaceSingleton.HideWindow(window);
	}
}
