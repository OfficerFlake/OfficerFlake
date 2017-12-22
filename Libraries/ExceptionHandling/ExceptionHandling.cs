using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries
{
	internal class DefaultExceptionHandler : IExceptionHandler
	{
		public bool Handle<T>(T e) where T : System.Exception
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
		    _handler = handler;
	    }

	    public static bool Handle<T>(T e) where T : System.Exception
	    {
		    if (_handler == null)
		    {
			    System.Diagnostics.Debug.WriteLine("Exception> " + e.ToString());
			    System.Diagnostics.Debug.WriteLine("Exception StackTrace> " + e.StackTrace);
			    return false;
		    }
		    return _handler.Handle(e);
	    }
	}
}
