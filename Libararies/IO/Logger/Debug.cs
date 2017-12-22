using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Logger
{
    internal class DefaultDebug : IDebug
    {
	    private IDebug debug = null;

	    internal void LinkDebug(IDebug debug)
	    {
		    this.debug = debug;
	    }

	    public void AddSummaryMessage(string message)
	    {
		    if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("Debug> Summary: " + message);
			    return;
		    }
		    debug.AddSummaryMessage(message);
	    }
		public void AddDetailMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("Debug> Detail: " + message);
			    return;
		    }
		    debug.AddDetailMessage(message);
		}
	    public void AddWarningMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("Debug> Warning: " + message);
			    return;
		    }
		    debug.AddWarningMessage(message);
		}
	    public void AddErrorMessage(Exception e, string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("Debug> Error: " + message);
			    return;
		    }
		    debug.AddErrorMessage(e, message);
		}
	    public void AddCrashMessage(Exception e, string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("Debug> Crash: " + message);
			    return;
		    }
		    debug.AddCrashMessage(e, message);
		}
    }
	public static class Debug
	{
		private static IDebug _debug = new DefaultDebug();

		public static void LinkDebug(IDebug debug) => _debug = debug;

		public static void AddDetailMessage(string message) => _debug.AddDetailMessage(message);
		public static void AddSummaryMessage(string message) => _debug.AddSummaryMessage(message);
		public static void AddWarningMessage(string message) => _debug.AddWarningMessage(message);
		public static void AddErrorMessage(Exception e, string message) => _debug.AddErrorMessage(e, message);
		public static void AddCrashMessage(Exception e, string message) => _debug.AddCrashMessage(e, message);
	}
}
