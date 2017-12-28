using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Logger
{
    internal class DefaultConsole : IConsole
    {
	    public void AddUserMessage(IUser user, string message)
	    {
			System.Diagnostics.Debug.WriteLine(user.UserName.ToUnformattedSystemString() + ": " + message);
			return;
	    }
	    public void AddInformationMessage(string message)
	    {
			System.Diagnostics.Debug.WriteLine("OpenYS: " + message);
			return;
		}
    }
	public static class Console
	{
		private static IConsole _console = new DefaultConsole();

		public static void LinkConsole(IConsole console)
		{
			if (console != null) _console = console;
		}

		public static void AddUserMessage(IUser user, string message) => _console.AddUserMessage(user, message);
		public static void AddInformationMessage(string message) => _console.AddInformationMessage(message);
	}
}
