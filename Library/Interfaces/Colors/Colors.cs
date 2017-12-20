using System.Collections.Generic;
using System.Drawing;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IColor
	{
		byte Alpha { get; set; }
		byte Red { get; set; }
		byte Green { get; set; }
		byte Blue { get; set; }
	}

	public interface I4BitColor
	{
		IColor FullColor { get; set; }
		char ColorCode { get; set; }

		string ToString();
	}

	public interface I24BitColor
	{
		IColor FullColor { get; set; }
		byte Red { get; }
		byte Green { get; }
		byte Blue { get; }

		string ToHexString();
	}

	public interface I32BitColor : IColor
	{
		string ToHexString();
	}
}
