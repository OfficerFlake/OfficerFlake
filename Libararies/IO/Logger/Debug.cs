using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Logger
{
    internal class DefaultDebug : IDebug
    {
	    public void AddSummaryMessage(string message)
	    {
			System.Diagnostics.Debug.WriteLine("Debug> Summary: " + message);
			return;
	    }
		public void AddDetailMessage(string message)
	    {
			System.Diagnostics.Debug.WriteLine("Debug> Detail: " + message);
			return;
		}
	    public void AddWarningMessage(string message)
	    {
			System.Diagnostics.Debug.WriteLine("Debug> Warning: " + message);
			return;
		}
	    public void AddErrorMessage(Exception e, string message)
	    {
			System.Diagnostics.Debug.WriteLine("Debug> Error: " + message);
			return;
		}
	    public void AddCrashMessage(Exception e, string message)
	    {
			System.Diagnostics.Debug.WriteLine("Debug> Crash: " + message);
			return;
		}
    }
	public static class Debug
	{
		private static IDebug _debug = new DefaultDebug();

		public static void LinkDebug(IDebug debug)
		{
			if (debug != null) _debug = debug;
		}

		public static void AddDetailMessage(string message) => _debug.AddDetailMessage(message);
		public static void AddSummaryMessage(string message) => _debug.AddSummaryMessage(message);
		public static void AddWarningMessage(string message) => _debug.AddWarningMessage(message);
		public static void AddErrorMessage(Exception e, string message) => _debug.AddErrorMessage(e, message);
		public static void AddCrashMessage(Exception e, string message) => _debug.AddCrashMessage(e, message);
	}
}
