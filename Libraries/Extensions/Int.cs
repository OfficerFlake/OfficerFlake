using System;
using System.Text;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class IntegerExtensions
	{
		#region Hexadecimal Conversions
		/// <summary>
		/// Returns the hexadecimal digit in the specified column from the right, if the integer was expressed as a hexadecimal number.
		/// </summary>
		/// <param name="input">Integer to convert to hexadecimal</param>
		/// <param name="column">Column number to check. Default 0.</param>
		/// <returns>A character between 0 and F</returns>
		public static char HexDigitAtColumn(this int input, int column = 0)
        {
            var exponent = ((int) (Math.Pow(16, column + 1)));
            var divided = input % exponent;
            var modulated = (divided / (exponent/16));
            switch (modulated)
            {
                case  0: return '0';
                case  1: return '1';
                case  2: return '2';
                case  3: return '3';
                case  4: return '4';
                case  5: return '5';
                case  6: return '6';
                case  7: return '7';
                case  8: return '8';
                case  9: return '9';
                case 10: return 'A';
                case 11: return 'B';
                case 12: return 'C';
                case 13: return 'D';
                case 14: return 'E';
                case 15: return 'F';
                default: return '?';
            }
        }

		/// <summary>
		/// Shorthand call to HexDigitAtColumn, checking column 1.
		/// </summary>
		/// <param name="input">Integer to convert to hexadecimal</param>
		/// <returns>A character between 0 and F</returns>
		public static char HexUnits(this int input)
        {
            return HexDigitAtColumn(input, 0);
        }

		/// <summary>
		/// Shorrthand call to HexDigitAtColumn, checking column 0.
		/// </summary>
		/// <param name="input">Integer to convert to hexadecimal</param>
		/// <returns>A character beteen 0 and F</returns>
		public static char HexTens(this int input)
        {
            return HexDigitAtColumn(input, 1);
        }
		#endregion
	}
}