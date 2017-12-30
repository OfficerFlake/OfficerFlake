using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IRichTextElement
	{
		string Message { get; set; }

		bool IsBold { get; set; }
		bool IsItallic { get; set; }
		bool IsUnderlined { get; set; }
		bool IsObfuscated { get; set; }
		bool IsStrikeout { get; set; }

		IColor ForeColor { get; set; }
		IColor BackColor { get; set; }

		string ToUnformattedSystemString();
		string ToInternallyFormattedSystemString();
	}
	public interface IRichTextString
	{
		List<IRichTextElement> Elements { get; set; }

		string ToUnformattedSystemString();
		string ToInternallyFormattedSystemString();
	}
	public interface IRichTextMessage
	{
		IDate Datestamp { get; set; }
		ITime Timestamp { get; set; }
		IUser User { get; set; }
		IRichTextString String { get; set; }
		MessageType Type { get; set; }
	}
	public enum MessageType
	{
		Unknown,
		User,
		ConsoleInformation,
		DebugSummary,
		DebugDetail,
		DebugWarning,
		DebugError,
		DebugCrash
	}

	public interface IConsoleUserMessage : IRichTextMessage { }
	public interface IConsoleInformationMessage : IRichTextMessage { }

	public interface IDebugSummaryMessage : IRichTextMessage { }
	public interface IDebugDetailMessage : IRichTextMessage { }
	public interface IDebugWarningMessage : IRichTextMessage { }
	public interface IDebugErrorMessage : IRichTextMessage { }
	public interface IDebugCrashMessage : IRichTextMessage { }
}
