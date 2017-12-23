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

	public interface ISimpleColor
	{
		I24BitColor Color { get; set; }
		char ColorCode { get; set; }
	}

	public interface I24BitColor
	{
		byte Red { get; set; }
		byte Green { get; set; }
		byte Blue { get; set; }

		string ToHexString();
	}

	public interface I32BitColor
	{
		byte Alpha { get; set; }
		byte Red { get; set; }
		byte Green { get; set; }
		byte Blue { get; set; }

		string ToHexString();
	}
}
