using System;
using System.Text;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class ByteExtensions
    {
		/// <summary>
		/// Converts a Byte into its binary string representation
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
	    public static string ToBinaryString(this byte input)
	    {
		    StringBuilder output = new StringBuilder();
		    for (int i = 7; i >= 0; i--)
		    {
			    output.Append((input & 1 << i) == 1 << i ? "1" : "0");
		    }
		    return output.ToString();
	    }


		/// <summary>
		/// Converts a Byte into its hexadecimal string representation.
		/// </summary>
		/// <param name="input">the byte to convert</param>
		/// <returns>Hexadecimal representation as string</returns>
        public static string ToHexString(this byte input)
        {
            return BitConverter.ToString(new[] { input });
        }

		/// <summary>
		/// Converts an array of bytes into it's equivilent string, by joining each bytes UTF8 character equivilent.
		/// </summary>
		/// <param name="input">Byte array to convert</param>
		/// <returns>String of UTF8 characters</returns>
        public static string ToSystemString(this byte[] input, Encoding encoding = null)
		{
			if (input == null) return null;
			if (encoding == null) encoding = Encoding.UTF8;

			if (encoding == Encoding.ASCII) return Encoding.ASCII.GetString(input);
			if (encoding == Encoding.Unicode) return Encoding.Unicode.GetString(input);
			if (encoding == Encoding.BigEndianUnicode) return Encoding.BigEndianUnicode.GetString(input);
			if (encoding == Encoding.UTF7) return Encoding.UTF7.GetString(input);
			if (encoding == Encoding.UTF8) return Encoding.UTF8.GetString(input);
			if (encoding == Encoding.UTF32) return Encoding.UTF32.GetString(input);
			return Encoding.Default.GetString(input);
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

	    public static bool GetBit(this byte input, int index)
	    {
		    if (index > 7) index = 7;
			if (index < 0) index = 0;
		    return ((input & (1 << index)) > 0);
	    }

	    public static byte SetBit(this byte input, int index)
	    {
		    if (index > 7) index = 7;
		    if (index < 0) index = 0;
		    return ((byte)(input | ((byte)(1 << index))));
		}
	    public static byte UnsetBit(this byte input, int index)
	    {
		    if (index > 7) index = 7;
		    if (index < 0) index = 0;
		    return ((byte)(input & ~((byte)(1 << index))));
	    }
	}
}
