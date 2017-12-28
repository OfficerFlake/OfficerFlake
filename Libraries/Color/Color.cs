using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Color
{
	public class FullColor : IColor
	{
		public byte Alpha { get; set; }
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

		public ISimpleColor GetSimpleColor()
		{
			Dictionary<double, SimpleColor> charindexes = new Dictionary<double, SimpleColor>();
			foreach (SimpleColor thiscolor in SimpleColors.List)
			{
				double distance =
					System.Math.Pow((thiscolor.Color.Red - Red) * 0.30, 2) +
					System.Math.Pow((thiscolor.Color.Green - Green) * 0.59, 2) +
					System.Math.Pow((thiscolor.Color.Blue - Blue) * 0.11, 2);
				charindexes[distance] = thiscolor;
			}
			return charindexes[charindexes.Keys.Min()];
		}
		public I24BitColor Get24BitColor()
		{
			return new XRGBColor(Red, Green, Blue);
		}
		public I32BitColor Get32BitColor()
		{
			return new ARGBColor(Alpha, Red, Green, Blue);
		}
	}
	public class XRGBColor : I24BitColor
	{
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

		public XRGBColor(byte red, byte green, byte blue)
		{
			Red = red;
			Green = green;
			Blue = blue;
		}

		public IColor GetColor()
		{
			return new FullColor() {Red = Red, Green = Green, Blue = Blue};
		}

		public string ToHexString()
		{
			return "#" + Red.ToHexString() + Green.ToHexString() + Blue.ToHexString();
		}
	}
	public class ARGBColor : I32BitColor
	{
		public byte Alpha { get; set; }
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

		public ARGBColor(byte alpha, byte red, byte green, byte blue)
		{
			Alpha = alpha;
			Red = red;
			Green = green;
			Blue = blue;
		}

		public IColor GetColor()
		{
			return new FullColor() { Alpha = Alpha, Red = Red, Green = Green, Blue = Blue };
		}

		public string ToHexString()
		{
			return "#" + Red.ToHexString() + Green.ToHexString() + Blue.ToHexString();
		}
	}

	public class SimpleColor : ISimpleColor
	{
		public SimpleColor(IColor color, char colorCode)
		{
			Color = color;
			ColorCode = colorCode;
		}

		public IColor Color { get; } = new XRGBColor(255,255,255).GetColor();
		public char ColorCode { get; } = '?';

		public IColor GetColor()
		{
			return new FullColor() { Alpha = Color.Alpha, Red = Color.Red, Green = Color.Green, Blue = Color.Blue };
		}

		public override string ToString()
		{
			return "#" + Color.Red.ToHexString() + Color.Green.ToHexString() + Color.Blue.ToHexString();
		}
	}
}
