using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDebug
	{
		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used during the start and end of methods.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddSummaryMessage(string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used during the middle of methods.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddDetailMessage(string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when a safe (expected) exception occurs in a method.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddWarningMessage(string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when an exception occurs in a method.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddErrorMessage(Exception e, string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when an exception crashes the entire program into an unrecoverable state.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddCrashMessage(Exception e, string message);
	}

	public static class Debug
	{
		private static IDebug debug;

		/// <summary>
		/// Links an an instance of IDebug to the Debug static class.
		/// 
		/// All new Debug messages will be sent to the new debugger.
		/// </summary>
		/// <param name="newDebug">An instance of IDebug to write to.</param>
		public static void LinkDebug(IDebug newDebug)
		{
			debug = newDebug;
		}

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used during the start and end of methods.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		public static void AddSummaryMessage(string message)
		{
			if (message == null) return;
			if (debug == null)
			{
				System.Diagnostics.Debug.WriteLine("Debug> Summary: " + message);
				return;
			}
			debug.AddSummaryMessage(message);
		}
		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used during the middle of methods.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		public static void AddDetailMessage(string message)
		{
			if (message == null) return;
			if (debug == null)
			{
				System.Diagnostics.Debug.WriteLine("Debug> Detail: " + message);
				return;
			}
			debug.AddDetailMessage(message);
		}
		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when a safe (expected) error occurs in a method.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		public static void AddWarningMessage(string message)
		{
			if (message == null) return;
			if (debug == null)
			{
				System.Diagnostics.Debug.WriteLine("Debug> Warning: " + message);
				return;
			}
			debug.AddWarningMessage(message);
		}
		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when an exception occurs in a method.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		public static void AddErrorMessage(Exception e, string message)
		{
			if (message == null) return;
			if (debug == null)
			{
				System.Diagnostics.Debug.WriteLine("Debug> Error: " + message);
				System.Diagnostics.Debug.WriteLine("Debug> Error Details: " + e.ToString());
				System.Diagnostics.Debug.WriteLine("Debug> Error StackTrace: " + e.StackTrace);
				if (BuildEnvironment.Debug) throw e;
				return;
			}
			debug.AddErrorMessage(e, message);
		}
		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when an exception crashes the entire program into an unrecoverable state.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		public static void AddCrashMessage(Exception e, string message)
		{
			if (message == null) return;
			if (debug == null)
			{
				System.Diagnostics.Debug.WriteLine("Debug> Crash: " + message);
				System.Diagnostics.Debug.WriteLine("Debug> Crash Details: " + e.ToString());
				System.Diagnostics.Debug.WriteLine("Debug> Crash StackTrace: " + e.StackTrace);
				if (BuildEnvironment.Debug) throw e;
				return;
			}
			debug.AddCrashMessage(e, message);
		}
	}
}
