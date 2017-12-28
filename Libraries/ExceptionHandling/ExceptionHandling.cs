using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

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
	}
}
