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

		I24BitColor ForeColor { get; set; }
		I24BitColor BackColor { get; set; }
		char GetClosestColorCode();
		ISimpleColor GetClosestSimpleColor();

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
}
