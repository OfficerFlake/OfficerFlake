using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IConsole
	{
		/// <summary>
		/// Adds a Chat Message from a User to the Console.
		/// </summary>
		/// <param name="user">User who sent the message.</param>
		/// <param name="message">The message they sent.</param>
		void AddUserMessage(IUser user, string message);

		/// <summary>
		/// Adds a general information message to the Console.
		/// </summary>
		/// <param name="message">The message to add to the console.</param>
		void AddInformationMessage(string message);
	}

	public static class Console
	{
		private static IConsole console;

		/// <summary>
		/// Links an an instance of IConsole to the Console static class.
		/// 
		/// All new Console messages will be sent to the new console.
		/// </summary>
		/// <param name="newDebug">An instance of IConsole to write to.</param>
		public static void LinkConsle(IConsole newConsole)
		{
			console = newConsole;
		}

		/// <summary>
		/// Adds a Chat Message from a User to the Console.
		/// </summary>
		/// <param name="user">User who sent the message.</param>
		/// <param name="message">The message they sent.</param>
		public static void AddInformationMessage(string message)
		{
			if (message == null) return;
			if (console == null)
			{
				System.Diagnostics.Debug.WriteLine(message);
				return;
			}
			console.AddInformationMessage(message);
		}
		/// <summary>
		/// Adds a general information message to the Console.
		/// </summary>
		/// <param name="message">The message to add to the console.</param>
		public static void AddUserMessage(IUser user, string message)
		{
			if (user == null)
			{
				Debug.AddErrorMessage(new NullReferenceException(), "Console.AddUserMessage was called with Null User!");
				return;
			}
			if (message == null)
			{
				Debug.AddErrorMessage(new NullReferenceException(), "Console.AddUserMessage was called with Null Message!");
				if (BuildEnvironment.Debug) throw new NullReferenceException();
				return;
			}
			if (console == null)
			{
				System.Diagnostics.Debug.WriteLine(message);
				return;
			}
			console.AddUserMessage(user, message);
		}
	}
}
