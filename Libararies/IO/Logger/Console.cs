using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Logger
{
    internal class DefaultConsole : IConsole
    {
	    private IConsole console = null;

	    internal void LinkConsole(IConsole console)
	    {
		    this.console = console;
	    }

	    public void AddUserMessage(IUser user, string message)
	    {
		    if (console == null)
		    {
			    System.Diagnostics.Debug.WriteLine(user.UserName.ToUnformattedSystemString() + ": " + message);
			    return;
		    }
		    console.AddUserMessage(user, message);
	    }
	    public void AddInformationMessage(string message)
	    {
			if (console == null)
		    {
			    System.Diagnostics.Debug.WriteLine("OpenYS: " + message);
			    return;
		    }
		    console.AddInformationMessage(message);
		}
    }
	public static class Console
	{
		private static IConsole _console = new DefaultConsole();

		public static void LinkConsole(IConsole console) => _console = console;

		public static void AddUserMessage(IUser user, string message) => _console.AddUserMessage(user, message);
		public static void AddInformationMessage(string message) => _console.AddInformationMessage(message);
	}
}
