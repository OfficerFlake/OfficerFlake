namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IColor
	{
		byte Alpha { get; set; }
		byte Red { get; set; }
		byte Green { get; set; }
		byte Blue { get; set; }

		ISimpleColor GetSimpleColor();
		I24BitColor Get24BitColor();
		I32BitColor Get32BitColor();
	}

	public interface ISimpleColor
	{
		IColor Color { get; set; }
		char ColorCode { get; set; }
	}

	public interface I24BitColor
	{
		byte Red { get; set; }
		byte Green { get; set; }
		byte Blue { get; set; }

		string ToHexString();
		IColor GetColor();
	}

	public interface I32BitColor
	{
		byte Alpha { get; set; }
		byte Red { get; set; }
		byte Green { get; set; }
		byte Blue { get; set; }

		string ToHexString();
		IColor GetColor();
	}
}
