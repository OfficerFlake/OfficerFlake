using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.IO
{
    internal class ConsoleInterface : IConsole
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
			    System.Diagnostics.Debug.WriteLine(user.UserName.ToSystemString() + ": " + message);
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
		private static readonly ConsoleInterface console = new ConsoleInterface();

		public static void LinkConsole(IConsole _console) => console.LinkConsole(_console);

		public static void AddUserMessage(IUser user, string message) => console.AddUserMessage(user, message);
		public static void AddInformationMessage(string message) => console.AddInformationMessage(message);
	}
}
