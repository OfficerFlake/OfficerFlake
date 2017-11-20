using System;
using System.Text;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class Byte
    {
		/// <summary>
		/// Converts a Bytes into it's hexadecimal string representation.
		/// </summary>
		/// <param name="input">the byte to convert</param>
		/// <returns>Hexadecimal representation as string</returns>
        public static string ToHexString(this byte input)
        {
            return BitConverter.ToString(new[] { input });
        }

		/// <summary>
		/// Converts an array of bytes into it's equivilent string, by joining each bytes ASCII character equivilent.
		/// </summary>
		/// <param name="input">Byte array to convert</param>
		/// <returns>String of ASCII characters</returns>
        public static string ToSystemString(this byte[] input)
        {
            return Encoding.ASCII.GetString(input);
        }

		/// <summary>
		/// Converts and array of Bytes into its hexadecimal string representation, seperated by hyphens.
		/// </summary>
		/// <param name="input">The byte array to convert.</param>
		/// <returns>Hexadecimal represtation as string</returns>
        public static string ToHexString(this byte[] input)
        {
            return BitConverter.ToString(input);
        }
    }
}
