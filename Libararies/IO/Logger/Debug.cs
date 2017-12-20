using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.IO
{
    internal class DebugInterface : IDebug
    {
	    private IDebug debug = null;

	    internal void LinkDebug(IDebug debug)
	    {
		    this.debug = debug;
	    }

	    public void AddDetailMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("DebugDetail: " + message);
			    return;
		    }
		    debug.AddDetailMessage(message);
		}
	    public void AddSummaryMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("DebugSummary: " + message);
			    return;
		    }
		    debug.AddSummaryMessage(message);
		}
	    public void AddWarningMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("DebugWarning: " + message);
			    return;
		    }
		    debug.AddWarningMessage(message);
		}
	    public void AddErrorMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("DebugError: " + message);
			    return;
		    }
		    debug.AddErrorMessage(message);
		}
	    public void AddCrashMessage(string message)
	    {
			if (debug == null)
		    {
			    System.Diagnostics.Debug.WriteLine("DebugCrash: " + message);
			    return;
		    }
		    debug.AddCrashMessage(message);
		}
    }
	public static class Debug
	{
		private static readonly DebugInterface debug = new DebugInterface();

		public static void LinkDebug(IDebug _Debug) => debug.LinkDebug(_Debug);

		public static void AddDetailMessage(string message) => debug.AddDetailMessage(message);
		public static void AddSummaryMessage(string message) => debug.AddSummaryMessage(message);
		public static void AddWarningMessage(string message) => debug.AddWarningMessage(message);
		public static void AddErrorMessage(string message) => debug.AddErrorMessage(message);
		public static void AddCrashMessage(string message) => debug.AddCrashMessage(message);
	}
}
