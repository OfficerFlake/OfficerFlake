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
		IUnitOfMeasurement Datestamp { get; }
		IUnitOfMeasurement Timestamp { get; }
		IUser User { get; }
		IRichTextString Message { get; }
	}
}
