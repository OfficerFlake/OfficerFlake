using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Com.OfficerFlake.Libraries.UserInterfaces.Windows
{
	public static class Extensions
	{
		/// <summary>
		/// Tries to create a new window application on a new Thread, and returns the new thread ID if successful.
		/// </summary>
		/// <param name="inputForm">The form to create as it's own application window.</param>
		/// <returns>Thread ID or null.</returns>
		public static Thread NewWindowThread(Form inputForm)
		{
			Thread newThread;
			try
			{
				newThread = new Thread(() => Application.Run(inputForm));
				newThread.Start();
			}
			catch (ThreadStartException)
			{
				//Could not start the thread.
				return null;
			}
			return newThread;
		}
	}
}
