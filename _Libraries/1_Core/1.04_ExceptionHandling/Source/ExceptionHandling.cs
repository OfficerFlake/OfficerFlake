using System;
using System.Diagnostics;
using System.IO;
using Com.OfficerFlake.Libraries.Interfaces;
using Debug = Com.OfficerFlake.Libraries.Logger.Debug;

namespace Com.OfficerFlake.Libraries
{
	internal class DefaultExceptionHandler : IExceptionHandler
	{
		public bool Handle(System.Exception e)
		{
			Debug.AddErrorMessage(e, "Exception handled by default handler.");
			return true;
		}
	}

	public static class ExceptionHandler
    {
	    private static IExceptionHandler _handler = new DefaultExceptionHandler();

	    public static void LinkExceptionHandler(IExceptionHandler handler)
	    {
		    if (handler != null) _handler = handler;
	    }

	    public static bool Handle(System.Exception e) => _handler.Handle(e);

	    public static string ToStackTraceString(this Exception e)
	    {
		    var st = new StackTrace(e, true);
		    var frame = st.GetFrame(0);
			string output = "";
		    output += "&eMESSAGE: &6" + e.Message + "\n";
		    output += "&eSTART TRACE:\n";
		    foreach (StackFrame Frame in st.GetFrames())
		    {
			    output += "&e    Method: &6" + Frame.GetMethod().Name + "\n";
			    output += "&e        Line:   &6" + Frame.GetFileLineNumber() + "&e, Column: &6" + Frame.GetFileColumnNumber() + "\n";
			    output += "&e        File:   &6" + Path.GetFileName(Frame.GetFileName()) + "\n";
			}
		    output += "&eEND TRACE.";
		    return output;
	    }
	}
}
