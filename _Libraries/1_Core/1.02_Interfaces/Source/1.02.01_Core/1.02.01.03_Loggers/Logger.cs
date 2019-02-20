namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface ILogger
    {
        /// <summary>
		/// Adds a general information message to the Debug Log.
		/// </summary>
		/// <param name="message">The message to add to the debug log.</param>
		void AddDebugMessage(string message);
	}
}
