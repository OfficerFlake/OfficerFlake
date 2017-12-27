namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IFormattingController
	{
		char DelimiterForeColor { get; set; }
		char DelimiterBackColor { get; set; }

		char DelimiterFormatting { get; set; }
		char Bold { get; set; }
		char Itallic { get; set; }
		char Underline { get; set; }
		char Strikeout { get; set; }
		char Obfuscated { get; set; }
	}
}
