using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.Color
{
	#region Colors
	/// <summary>
	/// A simple class to represent a 24bit RGB color (without alpha). Contains some extension methods to manipulate the color.
	/// </summary>
	public class XRGBColor
    {
        public byte Red;
        public byte Green;
        public byte Blue;

        public XRGBColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

	    public ARGBColor ToARGBColor()
	    {
		    return new ARGBColor(255, Red, Green, Blue);
	    }

        public override string ToString()
        {
            return "#" +
                   Red.ToHexString() +
                   Green.ToHexString() +
                   Blue.ToHexString();
        }

		/// <summary>
		/// Converts the 24bit RGB string to 12 bit CSS string. Loses quality.
		/// </summary>
		/// <returns>Lower quality CSS String.</returns>
        public string ToCssWebString()
        {
            return "#"
                   + ((int) Red).HexTens()
                   + ((int) Green).HexTens()
                   + ((int) Blue).HexTens();
                ;
        }
    }

	/// <summary>
	/// A simple class to represent a 32bit ARGB color (with alpha). Contains some extension methods to manipulate the color.
	/// </summary>
    public class ARGBColor : XRGBColor
    {
        public byte Alpha;
        public ARGBColor(byte alpha, byte red, byte green, byte blue) : base(red, green, blue)
        {
            Alpha = alpha;
        }

        public override string ToString()
        {
            return "#" +
                   Alpha.ToHexString() +
                   Red.ToHexString() +
                   Green.ToHexString() +
                   Blue.ToHexString();
        }

	    /// <summary>
	    /// Converts the 32bit ARGB string to CSS Web Format.
	    /// </summary>
	    /// <returns>CSS String.</returns>
		public string ToCssRgbaString()
        {
			return "rgba(" + (Red) + "," + (Green) + "," + (Blue) + "," + ((255-Alpha)/255f) + ")";
        }
    }
	#endregion
	#region Minecraft Colors
	/// <summary>
	/// A simple class to index Minecraft Color names to XRGB Colors.
	/// </summary>
	internal class MinecraftColorAsXRGB
    {
	    public static XRGBColor Black = new XRGBColor(0, 0, 0);
	    public static XRGBColor DarkBlue = new XRGBColor(0, 0, 170);
	    public static XRGBColor DarkGreen = new XRGBColor(0, 170, 0);
	    public static XRGBColor Teal = new XRGBColor(0, 170, 170);
	    public static XRGBColor DarkRed = new XRGBColor(170, 0, 0);
	    public static XRGBColor Purple = new XRGBColor(170, 0, 170);
	    public static XRGBColor Gold = new XRGBColor(255, 170, 0);
	    public static XRGBColor Gray = new XRGBColor(170, 170, 170);
	    public static XRGBColor DarkGray = new XRGBColor(85, 85, 85);
	    public static XRGBColor Blue = new XRGBColor(85, 85, 255);
	    public static XRGBColor Green = new XRGBColor(85, 255, 85);
	    public static XRGBColor Aqua = new XRGBColor(85, 255, 255);
	    public static XRGBColor Red = new XRGBColor(255, 85, 85);
	    public static XRGBColor Magenta = new XRGBColor(255, 85, 255);
	    public static XRGBColor Yellow = new XRGBColor(255, 255, 85);
	    public static XRGBColor White = new XRGBColor(255, 255, 255);
    }

	/// <summary>
	/// A simple class to match color characters to XRGB colors, and identify by name. A few conversion extensions.
	/// </summary>
    public class MinecraftColor
    {
        public static MinecraftColor Black = new MinecraftColor('0', MinecraftColorAsXRGB.Black);
        public static MinecraftColor DarkBlue = new MinecraftColor('1', MinecraftColorAsXRGB.DarkBlue);
        public static MinecraftColor DarkGreen = new MinecraftColor('2', MinecraftColorAsXRGB.DarkGreen);
        public static MinecraftColor Teal = new MinecraftColor('3', MinecraftColorAsXRGB.Teal);
        public static MinecraftColor DarkRed = new MinecraftColor('4', MinecraftColorAsXRGB.DarkRed);
        public static MinecraftColor Purple = new MinecraftColor('5', MinecraftColorAsXRGB.Purple);
        public static MinecraftColor Gold = new MinecraftColor('6', MinecraftColorAsXRGB.Gold);
        public static MinecraftColor Gray = new MinecraftColor('7', MinecraftColorAsXRGB.Gray);
        public static MinecraftColor DarkGray = new MinecraftColor('8', MinecraftColorAsXRGB.DarkGray);
        public static MinecraftColor Blue = new MinecraftColor('9', MinecraftColorAsXRGB.Blue);
        public static MinecraftColor Green = new MinecraftColor('A', MinecraftColorAsXRGB.Green);
        public static MinecraftColor Aqua = new MinecraftColor('B', MinecraftColorAsXRGB.Aqua);
        public static MinecraftColor Red = new MinecraftColor('C', MinecraftColorAsXRGB.Red);
        public static MinecraftColor Magenta = new MinecraftColor('D', MinecraftColorAsXRGB.Magenta);
        public static MinecraftColor Yellow = new MinecraftColor('E', MinecraftColorAsXRGB.Yellow);
        public static MinecraftColor White = new MinecraftColor('F', MinecraftColorAsXRGB.White);

        public char Character = 'F';
        public XRGBColor Color = MinecraftColorAsXRGB.White;

        public MinecraftColor(char charater, XRGBColor color)
        {
            Character = charater;
            Color = color;
        }

		/// <summary>
		/// Converts the Minecraft Color representation to a System Drawing Color.
		/// </summary>
		/// <returns>A System Drawing color</returns>
	    public System.Drawing.Color AsSystemDrawingColor()
	    {
		    return System.Drawing.Color.FromArgb(255, Color.Red, Color.Green, Color.Blue);
	    }

        public override string ToString()
        {
            switch (Character)
            {
                case '0':
                    return "Black";
                case '1':
                    return "DarkBlue";
                case '2':
                    return "DarkGreen";
                case '3':
                    return "Teal";
                case '4':
                    return "DarkRed";
                case '5':
                    return "Purple";
                case '6':
                    return "Gold";
                case '7':
                    return "Gray";
                case '8':
                    return "DarkGray";
                case '9':
                    return "Blue";
                case 'A':
                    return "Green";
                case 'B':
                    return "Aqua";
                case 'C':
                    return "Red";
                case 'D':
                    return "Magenta";
                case 'E':
                    return "Yellow";
                case 'F':
                    return "White";

                default:
                    return base.ToString();
            }
        }
    }

    public static class MinecraftColors
    {
        public static MinecraftColor[] List = new[]
        {
            MinecraftColor.Black,
            MinecraftColor.DarkBlue,
            MinecraftColor.DarkGreen,
            MinecraftColor.Teal,
            MinecraftColor.DarkRed,
            MinecraftColor.Purple,
            MinecraftColor.Gold,
            MinecraftColor.Gray,
            MinecraftColor.DarkGray,
            MinecraftColor.Blue,
            MinecraftColor.Red,
            MinecraftColor.Aqua,
            MinecraftColor.Green,
            MinecraftColor.Magenta,
            MinecraftColor.Yellow,
            MinecraftColor.White,
        };

		/// <summary>
		/// If the colors index has a color that matches the character code, return that color, otherwise return null.
		/// </summary>
		/// <param name="thisChar">Character to test.</param>
		/// <returns>MinecraftColor or null.</returns>
        public static MinecraftColor GetColorFromCharOrNull(this char thisChar)
        {
            switch (thisChar)
            {
                case '0':
                    return MinecraftColor.Black;
                case '1':
                    return MinecraftColor.DarkBlue;
                case '2':
                    return MinecraftColor.DarkGreen;
                case '3':
                    return MinecraftColor.Teal;
                case '4':
                    return MinecraftColor.DarkRed;
                case '5':
                    return MinecraftColor.Purple;
                case '6':
                    return MinecraftColor.Gold;
                case '7':
                    return MinecraftColor.Gray;
                case '8':
                    return MinecraftColor.DarkGray;
                case '9':
                    return MinecraftColor.Blue;
                case 'A':
                    return MinecraftColor.Red;
                case 'B':
                    return MinecraftColor.Aqua;
                case 'C':
                    return MinecraftColor.Green;
                case 'D':
                    return MinecraftColor.Magenta;
                case 'E':
                    return MinecraftColor.Yellow;
                case 'F':
                    return MinecraftColor.White;

                default:
                    return null;
            }
        }
    }
	#endregion
}
