using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Color;

namespace Com.OfficerFlake.Libraries.RichText
{
    public class RichTextString
    {
	    #region Message Elements
	    public class MessageElement
	    {
			#region Properties
			public string Message = "";
		    public SimpleColor Color = SimpleColors.ColorF;

		    public bool IsObfuscated;
		    public bool IsBold;
		    public bool IsStrikeThrough;
		    public bool IsUnderlined;
		    public bool IsItalic;
			#endregion
			#region Constructors
			public MessageElement()
		    {
		    }

			public MessageElement(string message, SimpleColor color, bool isbold, bool isitalic, bool isunderlined,
			    bool isobfuscated)
		    {
			    Message = message;
			    Color = color;
			    IsBold = isbold;
			    IsItalic = isitalic;
			    IsUnderlined = isunderlined;
			    IsObfuscated = isobfuscated;
		    }
		    #endregion
		}
		public MessageElement[] Elements
	    {
		    get;
		    set;
	    }
		#endregion

	    public RichTextString(MessageElement[] _Elements)
	    {
		    Elements = _Elements;
	    }

		#region RichTextString => Formatted System String
		/// <summary>
		/// Converts a RichTextString to a System String, by sperating with own internal formatting.
		/// </summary>
		/// <returns>An interanally formatted System String.</returns>
		public string ToFormattedString()
	    {
			return Elements.ToSystemString();
		}
		#endregion
		#region RichTextString => Unformatted System String
		/// <summary>
		/// Converts a RichTextString to a System String, with no formatting preserved.
		/// </summary>
		/// <returns>A System String with no formatting.</returns>
		public string ToUnformattedString()
	    {
		    return string.Join("", Elements.Select(x => x.Message));
	    }
		/// <summary>
		/// Converts a RichTextString to a System String, without preserving formatting.
		/// </summary>
		/// <returns>A System String with no formatting.</returns>
		public override string ToString()
	    {
		    return ToUnformattedString();
	    }
		#endregion
	    
	}

	public static class Extensions
	{
		#region Formatted System String => RichTextString
		/// <summary>
		/// Converts the formatted System String into a RichTextString object, preserving internal formatting.
		/// </summary>
		/// <param name="thisString">An internally formatted System String.</param>
		/// <returns>A RichTextString.</returns>
		public static RichTextString AsRichTextString(this string thisString)
		{
			char[] splittablechars = new[]
			{
				'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'K', 'L', 'M', 'N', 'O', 'R'
			};

			List<RichTextString.MessageElement> elements = new List<RichTextString.MessageElement>();

			RichTextString.MessageElement currentMessageElement = new RichTextString.MessageElement();

			bool isExpectingSplittableChar = false;
			for (int i = 0; i < thisString.Length; i++)
			{
				char thisCharUpperCase = thisString.ToUpperInvariant()[i];

				if (isExpectingSplittableChar)
				{
					if (splittablechars.Contains(thisCharUpperCase))
					{
						if (currentMessageElement.Message.Length > 0) elements.Add(currentMessageElement);
						currentMessageElement = new RichTextString.MessageElement()
						{
							Message = "",
							Color = currentMessageElement.Color,
							IsObfuscated = currentMessageElement.IsObfuscated,
							IsBold = currentMessageElement.IsBold,
							IsStrikeThrough = currentMessageElement.IsStrikeThrough,
							IsUnderlined = currentMessageElement.IsUnderlined,
							IsItalic = currentMessageElement.IsItalic,
						};

						#region SWITCH

						switch (thisCharUpperCase)
						{
							#region Cases
							case '0':
								currentMessageElement.Color = SimpleColors.Color0;
								break;
							case '1':
								currentMessageElement.Color = SimpleColors.Color1;
								break;
							case '2':
								currentMessageElement.Color = SimpleColors.Color2;
								break;
							case '3':
								currentMessageElement.Color = SimpleColors.Color3;
								break;
							case '4':
								currentMessageElement.Color = SimpleColors.Color4;
								break;
							case '5':
								currentMessageElement.Color = SimpleColors.Color5;
								break;
							case '6':
								currentMessageElement.Color = SimpleColors.Color6;
								break;
							case '7':
								currentMessageElement.Color = SimpleColors.Color7;
								break;
							case '8':
								currentMessageElement.Color = SimpleColors.Color8;
								break;
							case '9':
								currentMessageElement.Color = SimpleColors.Color9;
								break;
							case 'A':
								currentMessageElement.Color = SimpleColors.ColorA;
								break;
							case 'B':
								currentMessageElement.Color = SimpleColors.ColorB;
								break;
							case 'C':
								currentMessageElement.Color = SimpleColors.ColorC;
								break;
							case 'D':
								currentMessageElement.Color = SimpleColors.ColorD;
								break;
							case 'E':
								currentMessageElement.Color = SimpleColors.ColorE;
								break;
							case 'F':
								currentMessageElement.Color = SimpleColors.ColorF;
								break;

							case 'K':
								currentMessageElement.IsObfuscated = true;
								break;
							case 'L':
								currentMessageElement.IsBold = true;
								break;
							case 'M':
								currentMessageElement.IsStrikeThrough = true;
								break;
							case 'N':
								currentMessageElement.IsUnderlined = true;
								break;
							case 'O':
								currentMessageElement.IsItalic = true;
								break;

							case 'R':
								currentMessageElement.Color = SimpleColors.White;
								currentMessageElement.IsObfuscated = false;
								currentMessageElement.IsBold = false;
								currentMessageElement.IsStrikeThrough = false;
								currentMessageElement.IsItalic = false;
								currentMessageElement.IsUnderlined = false;
								break;

							#endregion

							default:
								currentMessageElement.Message += "&";
								goto End;
						}
						isExpectingSplittableChar = (thisCharUpperCase == '&');
						continue;
						#endregion
					}

					else
					{
						goto End;
					}
				}
				End:
				isExpectingSplittableChar = (thisCharUpperCase == '&');
				if (isExpectingSplittableChar) continue;
				currentMessageElement.Message += thisString[i];
			}
			if (currentMessageElement.Message.Length > 0) elements.Add(currentMessageElement);

			RichTextString output = new RichTextString(elements.ToArray());

			return output;
		}
		#endregion
		#region MessageElements => Formatted System String
		/// <summary>
		/// Converts an array of MessageElements to a System String.
		/// </summary>
		/// <param name="elements">Array of MessageElements to convert.</param>
		/// <returns>An internally formatted System String.</returns>
		public static string ToSystemString(this RichTextString.MessageElement[] elements)
		{
			StringBuilder output = new StringBuilder();
			RichTextString.MessageElement prevElement = new RichTextString.MessageElement();
			for (int i = 0; i < elements.Length; i++)
			{
				RichTextString.MessageElement thisElement = elements[i];
				bool shouldReset = false;
				if (!thisElement.IsObfuscated && prevElement.IsObfuscated) shouldReset = true;
				if (!thisElement.IsBold && prevElement.IsBold) shouldReset = true;
				if (!thisElement.IsStrikeThrough && prevElement.IsStrikeThrough) shouldReset = true;
				if (!thisElement.IsUnderlined && prevElement.IsUnderlined) shouldReset = true;
				if (!thisElement.IsItalic && prevElement.IsItalic) shouldReset = true;
				if (shouldReset) output.Append("&" + 'R');

				if (thisElement.Color != prevElement.Color) output.Append("&" + thisElement.Color.ColorCode);

				if (thisElement.IsObfuscated && !prevElement.IsObfuscated) output.Append("&" + 'K');
				if (thisElement.IsBold && !prevElement.IsBold) output.Append("&" + 'L');
				if (thisElement.IsStrikeThrough && !prevElement.IsStrikeThrough) output.Append("&" + 'M');
				if (thisElement.IsUnderlined && !prevElement.IsUnderlined) output.Append("&" + 'N');
				if (thisElement.IsItalic && !prevElement.IsItalic) output.Append("&" + 'O');

				output.Append(thisElement.Message);

				prevElement = thisElement;
			}
			return output.ToString();
		}
		#endregion
	}
}
