using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDebug
	{
		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used during the start and end of methods.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddSummaryMessage(string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used during the middle of methods.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddDetailMessage(string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when a safe (expected) exception occurs in a method.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddWarningMessage(string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when an exception occurs in a method.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddErrorMessage(Exception e, string message);

		/// <summary>
		/// Adds a message to the Debug Console.
		/// 
		/// To be used when an exception crashes the entire program into an unrecoverable state.
		/// </summary>
		/// <param name="message">The message to add to the debug console.</param>
		void AddCrashMessage(Exception e, string message);
	}
}
