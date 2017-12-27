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
}
