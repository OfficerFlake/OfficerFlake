using System;
using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Color
{
	public class XRGBColor : I24BitColor
	{
		public XRGBColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

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

		public string ToHexString()
		{
			return "#" + Red.ToHexString() + Green.ToHexString() + Blue.ToHexString();
		}
	}

	public class SimpleColor : ISimpleColor
	{
		public IColor Color { get; set; }
		public char ColorCode { get; set; }

		public SimpleColor(I24BitColor color, char colorCode)
		{
			Color = color;
			ColorCode = colorCode;
		}

		public override string ToString()
		{
			return "#" + Color.Red.ToHexString() + Color.Green.ToHexString() + Color.Blue.ToHexString();
		}
	}

	public static class SimpleColors
	{
		#region Colors

		public static readonly List<SimpleColor> List = new List<SimpleColor>()
		{
			Color0,
			Color1,
			Color2,
			Color3,
			Color4,
			Color5,
			Color6,
			Color7,
			Color8,
			Color9,
			ColorA,
			ColorB,
			ColorC,
			ColorD,
			ColorE,
			ColorF
		};
		public static SimpleColor Black => Color0;
		public static readonly SimpleColor Color0 =
			new SimpleColor
			(
				new XRGBColor(0, 0, 16),
				'0'
			);

		public static SimpleColor DarkBlue => Color1;
		public static readonly SimpleColor Color1 =
			new SimpleColor
			(
				new XRGBColor(0, 0, 170),
				'1'
			);

		public static SimpleColor DarkGreen => Color2;
		public static readonly SimpleColor Color2 =
			new SimpleColor
			(
				new XRGBColor(0, 170, 0),
				'2'
			);

		public static SimpleColor DarkTeal => Color3;
		public static readonly SimpleColor Color3 =
			new SimpleColor
			(
				new XRGBColor(0, 170, 170),
				'3'
			);

		public static SimpleColor DarkRed => Color4;
		public static readonly SimpleColor Color4 =
			new SimpleColor
			(
				new XRGBColor(170, 0, 0),
				'4'
			);

		public static SimpleColor DarkPurple => Color5;
		public static readonly SimpleColor Color5 =
			new SimpleColor
			(
				new XRGBColor(170, 0, 170),
				'5'
			);

		public static SimpleColor DarkYellow => Color6;
		public static readonly SimpleColor Color6 =
			new SimpleColor
			(
				new XRGBColor(0, 170, 0),
				'6'
			);

		public static SimpleColor Gray => Color7;
		public static readonly SimpleColor Color7 =
			new SimpleColor
			(
				new XRGBColor(170, 170, 170),
				'7'
			);

		public static SimpleColor DarkGray => Color7;
		public static readonly SimpleColor Color8 =
			new SimpleColor
			(
				new XRGBColor(85, 85, 85),
				'8'
			);

		public static SimpleColor Blue => Color9;
		public static readonly SimpleColor Color9 =
			new SimpleColor
			(
				new XRGBColor(85, 85, 255),
				'9'
			);

		public static SimpleColor Green => ColorA;
		public static readonly SimpleColor ColorA =
			new SimpleColor
			(
				new XRGBColor(85, 255, 85),
				'A'
			);

		public static SimpleColor Teal => ColorB;
		public static readonly SimpleColor ColorB =
			new SimpleColor
			(
				new XRGBColor(85, 255, 255),
				'B'
			);

		public static SimpleColor Red => ColorC;
		public static readonly SimpleColor ColorC =
			new SimpleColor
			(
				new XRGBColor(255, 85, 85),
				'C'
			);

		public static SimpleColor Purple => ColorD;
		public static readonly SimpleColor ColorD =
			new SimpleColor
			(
				new XRGBColor(255, 85, 255),
				'D'
			);

		public static SimpleColor Yellow => ColorE;
		public static readonly SimpleColor ColorE =
			new SimpleColor
			(
				new XRGBColor(255, 255, 85),
				'E'
			);

		public static SimpleColor White => ColorF;
		public static readonly SimpleColor ColorF =
			new SimpleColor
			(
				new XRGBColor(255, 255, 255),
				'F'
			);
		#endregion
		#region Extensions
		public static System.Drawing.Color ToSystemDrawingColor(this SimpleColor simpleColor)
		{
			return System.Drawing.Color.FromArgb(
				255,
				simpleColor.Color.Red,
				simpleColor.Color.Green,
				simpleColor.Color.Blue);
		}
		#endregion
	}
}
