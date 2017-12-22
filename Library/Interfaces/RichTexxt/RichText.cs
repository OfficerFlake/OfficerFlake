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
		char ClosestColorCode { get; }

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
		IRichTextString Message { get; set; }
		MessageType Type { get; set; }
	}

	public enum MessageType
	{
		User,
		ConsoleInformation,
		DebugSummary,
		DebugDetail,
		DebugWarning,
		DebugError,
		DebugCrash
	}
}
