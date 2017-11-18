using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class String
    {
		#region Byte Array Conversions
		/// <summary>
		/// Converts a string into an ASCII encoded byte array.
		/// </summary>
		/// <param name="input">String to convert</param>
		/// <returns>Array of ASCII bytes</returns>
		public static byte[] ToByteArray(this string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }

		/// <summary>
		/// Converts a multiline string into an ASCII encoded byte array.
		/// </summary>
		/// <param name="input">String to convert.</param>
		/// <returns>Array of ASCII bytes.</returns>
		public static byte[] ToByteArray(this string[] input)
        {
            var joined = System.String.Join("\n", input);
            return Encoding.ASCII.GetBytes(joined);
        }
		#endregion
		#region String Cleaning
		/// <summary>
		/// Splits a string by its spaces, preserving any parts of the string held in quotation marks.
		/// </summary>
		/// <param name="input">A string with spaces in it that needs to be split into an array.</param>
		/// <returns>Array of strings.</returns>
		public static string[] SplitPresevingQuotes(this string input)
        {
            var cleanstr = input
                .Replace("\t", "    ")
                .Replace("\r", "");
            while (cleanstr.Contains("  ")) cleanstr = cleanstr.Replace("  ", " ");
            return Regex.Split(cleanstr, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        }
        
		/// <summary>
		/// Shorthand call that removes trailing comment symbols from a string, and removes surrounding quotation marks if any.
		/// </summary>
		/// <param name="input">String to clean.</param>
		/// <returns>Cleaned string.</returns>
        public static string CleanString(this string input)
        {
            var output = input;

            output = (output.EndsWith(";")) ? output.Substring(0, output.Length - 1) : output;
            output = (output.EndsWith("#")) ? output.Substring(0, output.Length - 1) : output;
            output = (output.StartsWith("\"") && (output.EndsWith("\""))) ? output.Substring(1, output.Length - 2) : output;

            return output;
        }

	    /// <summary>
	    /// Tries to extract just the number component of a string, ready to be parsed by a TryParse command.
	    /// 
	    /// Can work with signed numbers, and numbers with decimals.
	    /// </summary>
	    /// <param name="input">String to extract first number from.</param>
	    /// <returns>A number, potentially signed, and potentially decimal, as a string.</returns>
	    public static string ExtractNumberComponentFromMeasurementString(this string input)
	    {
		    var haveNumber = false;
		    var haveDecimal = false;
		    var haveSign = false;
		    var output = new StringBuilder();
		    foreach (var thisChar in input)
		    {
			    if (!haveNumber)
			    {
				    if (thisChar == '-')
				    {
					    haveNumber = true;
					    haveSign = true;
					    output.Append(thisChar);
					    continue;
				    }
				    if (thisChar == '+')
				    {
					    haveNumber = true;
					    haveSign = true;
					    output.Append(thisChar);
					    continue;
				    }
				    if (thisChar == '.')
				    {
					    haveNumber = true;
					    haveDecimal = true;
					    output.Append(thisChar);
					    continue;
				    }
				    if (char.IsNumber(thisChar))
				    {
					    haveNumber = true;
					    output.Append(thisChar);
					    continue;
				    }
			    }
			    if (thisChar == '-' && !haveSign)
			    {
				    haveSign = true;
				    output.Append(thisChar);
				    continue;
			    }
			    if (thisChar == '+' && !haveSign)
			    {
				    haveSign = true;
				    output.Append(thisChar);
				    continue;
			    }
			    if (thisChar == '.' && !haveDecimal)
			    {
				    haveDecimal = true;
				    output.Append(thisChar);
				    continue;
			    }
			    if (char.IsNumber(thisChar))
			    {
				    output.Append(thisChar);
				    continue;
			    }
			    break;
		    }
		    return output.ToString();

	    }
		#endregion
		#region Searching Shortcuts
		/// <summary>
		/// Returns true if the tested string ends with any part of the substring.
		/// </summary>
		/// <param name="input">String to check.</param>
		/// <param name="comparison">String of characters that, if the string ends with any sequential characters, should return true.</param>
		/// <returns>True if </returns>
		public static bool EndsWithAny(this string input, string comparison)
        {
            for (var i = comparison.Length - 1; i > 0; i--)
            {
                var thisString = comparison.Substring(0, i);
                if (input.ToUpperInvariant().EndsWith(thisString)) return true;
            }
            return false;

        }

		/// <summary>
		/// Returns true if the tested string ends with any of the string from the testing array.
		/// </summary>
		/// <param name="input">String to test.</param>
		/// <param name="endstrings">Array of potential matching end strings.</param>
		/// <returns>True if any matches.</returns>
        public static bool EndsWithAny(this string input, string[] endstrings)
        {
            return endstrings.Any(input.EndsWith);
        }
		#endregion
		#region Replacing Shortcuts
	    /// <summary>
	    /// Searches a string for the occurance of a substring, then returns a new string, from the start of the original string to the location of the matched substring.
	    /// 
	    /// If there is no match, returns the original string.
	    /// </summary>
	    /// <param name="input">Original String</param>
	    /// <param name="expression">String to find and split from.</param>
	    /// <returns>Substring from 0 to index of found string, if the substring is found, or the original string.</returns>
	    public static string TrimAllAfterFirstOccuranceOfString(this string input, string expression)
	    {
		    var index = input.IndexOf(expression, StringComparison.Ordinal);
		    if (index > 0) return input.Substring(0, index);
		    return input;
	    }
		#endregion
		#region Resizing
		/// <summary>
		/// Resizes a string to be the specified size, by adding fill characters to the left or right of the string, or trimming excess length.
		/// </summary>
		/// <param name="originalString">Original string to trim.</param>
		/// <param name="targetSize">New string will be this many characters long.</param>
		/// <param name="fillCharacter">If the Trim needs to add new characters, they will be this character.</param>
		/// <param name="appendToRight">Should we edit the right side of the string? if not, edit the left.</param>
		/// <returns></returns>
		private static string Resize(this string originalString, int targetSize, char fillCharacter = '\0', bool appendToRight = true)
        {
            if (originalString == null) throw new NullReferenceException("originalString is null!");

	        if (originalString.Length >= targetSize) goto OverSize;
	        else goto UnderSize;
            
            UnderSize:
            return appendToRight ?
				originalString + new string(fillCharacter, targetSize - originalString.Length) :
				new string(fillCharacter, targetSize - originalString.Length) + originalString;

            OverSize:
            return appendToRight ?
				originalString.Substring(0, targetSize) :
				originalString.Substring(originalString.Length-targetSize, targetSize);
        }

		/// <summary>
		/// Resizes the input string to be specified length, by adding or cutting characters from the left.
		/// </summary>
		/// <param name="originalString">Original string to resize.</param>
		/// <param name="targetSize">New length to make the string.</param>
		/// <param name="fillCharacter">If need to add characters, they will be this type.</param>
		/// <returns>Resized string.</returns>
        public static string ResizeOnLeft(this string originalString, int targetSize, char fillCharacter = '\0')
        {
            return Resize(originalString, targetSize, fillCharacter, false);
        }

		/// <summary>
		/// Resizes the input string to be specified length, by adding or cutting characters from the right.
		/// </summary>
		/// <param name="originalString">Original string to resize.</param>
		/// <param name="targetSize">New length to make the string.</param>
		/// <param name="fillCharacter">If need to add characters, they will be this type.</param>
		/// <returns>Resized string.</returns>
		public static string ResizeOnRight(this string originalString, int targetSize, char fillCharacter = '\0')
	    {
		    return Resize(originalString, targetSize, fillCharacter, true);
	    }
		#endregion
	}
}
