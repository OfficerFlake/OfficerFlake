using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IFormattingDescriptor
	{
		IColor BackColor { get; set; }
		IColor ForeColor { get; set; }
		Boolean IsBold { get; set; }
		Boolean IsItallic { get; set; }
		Boolean IsUnderlined { get; set; }
		Boolean IsStrikeout { get; set; }
		Boolean IsObfuscated { get; set; }
	}
}
