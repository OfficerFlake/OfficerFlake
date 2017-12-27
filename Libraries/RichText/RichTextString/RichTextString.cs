﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.RichText
{
    public class RichTextString : IRichTextString
    {
	    #region Message Elements
	    public class MessageElement : IRichTextElement
	    {
			#region Properties
		    public string Message { get; set; } = "";
		    public I24BitColor ForeColor { get; set; } = (I24BitColor)SimpleColors.White.Color;
		    public I24BitColor BackColor { get; set; } = (I24BitColor)SimpleColors.Black.Color;

			public bool IsObfuscated { get; set; }
		    public bool IsBold { get; set; }
			public bool IsStrikeout { get; set; }
			public bool IsUnderlined { get; set; }
			public bool IsItallic { get; set; }
			#endregion
			#region Constructors
			public MessageElement()
		    {
		    }

		    public MessageElement(string message, ISimpleColor color, bool isBold, bool isItallic, bool isUnderlined,
			    bool isObfuscated, bool isStrikeout)
		    {
			    Message = message;
			    ForeColor = GetColor(color.ColorCode).Get24BitColor();
			    IsBold = isBold;
			    IsItallic = isItallic;
			    IsUnderlined = isUnderlined;
			    IsObfuscated = isObfuscated;
		    }
			#endregion

		    public char GetClosestColorCode()
			{
				Dictionary<double, char> charindexes = new Dictionary<double, char>();
				foreach (SimpleColor thiscolor in SimpleColors.List)
				{
					double distance = 
						Math.Pow((thiscolor.Color.Red - ForeColor.Red) * 0.30, 2) +
						Math.Pow((thiscolor.Color.Green - ForeColor.Green) * 0.59, 2) +
						Math.Pow((thiscolor.Color.Blue - ForeColor.Blue) * 0.11, 2);
					charindexes[distance] = thiscolor.ColorCode;
				}
				return charindexes[charindexes.Keys.Min()];
		    }
		    public IColor GetColor(char charCode)
		    {
			    if (SimpleColors.List.All((x => x.ColorCode != charCode))) return SimpleColors.White.Color;
			    return SimpleColors.List.Last(x => x.ColorCode == charCode).Color;
		    }

		    public string ToInternallyFormattedSystemString()
		    {
			    return
				    "&r" +
				    ("&" + GetClosestColorCode()) +
				    (IsBold ? "&l" : "") +
				    (IsItallic ? "&o" : "") +
				    (IsUnderlined ? "&n" : "") +
				    (IsStrikeout ? "&m" : "") +
				    (IsObfuscated ? "&k" : "") +
				    Message;

		    }
		    public string ToUnformattedSystemString()
		    {
			    return Message;
		    }

			public ISimpleColor GetClosestSimpleColor()
			{
				if (SimpleColors.List.All(x => x.ColorCode != GetClosestColorCode())) return SimpleColors.White;
				return SimpleColors.List.First(x => x.ColorCode == GetClosestColorCode());
			}
		}
		public List<IRichTextElement> Elements
	    {
		    get;
		    set;
	    }
		#endregion

		public RichTextString(List<IRichTextElement> _Elements)
	    {
		    Elements = _Elements;
	    }

		#region RichTextString => Formatted System String
		/// <summary>
		/// Converts a RichTextString to a System String, by sperating with own internal formatting.
		/// </summary>
		/// <returns>An interanally formatted System String.</returns>
		public string ToInternallyFormattedSystemString()
	    {
			return string.Join("", Elements.Select(x=>x.ToInternallyFormattedSystemString()));
		}
		#endregion
		#region RichTextString => Unformatted System String
		/// <summary>
		/// Converts a RichTextString to a System String, with no formatting preserved.
		/// </summary>
		/// <returns>A System String with no formatting.</returns>
		public string ToUnformattedSystemString()
	    {
			return string.Join("", Elements.Select(x => x.ToUnformattedSystemString()));
		}
		/// <summary>
		/// Converts a RichTextString to a System String, without preserving formatting.
		/// </summary>
		/// <returns>A System String with no formatting.</returns>
		public override string ToString()
	    {
		    return ToUnformattedSystemString();
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

			List<IRichTextElement> elements = new List<IRichTextElement>();

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
							ForeColor = currentMessageElement.ForeColor,
							IsObfuscated = currentMessageElement.IsObfuscated,
							IsBold = currentMessageElement.IsBold,
							IsStrikeout = currentMessageElement.IsStrikeout,
							IsUnderlined = currentMessageElement.IsUnderlined,
							IsItallic = currentMessageElement.IsItallic,
						};

						#region SWITCH

						switch (thisCharUpperCase)
						{
							#region Cases
							case '0':
								currentMessageElement.ForeColor = SimpleColors.Color0.Color.Get24BitColor();
								break;
							case '1':
								currentMessageElement.ForeColor = SimpleColors.Color1.Color.Get24BitColor();
								break;
							case '2':
								currentMessageElement.ForeColor = SimpleColors.Color2.Color.Get24BitColor();
								break;
							case '3':
								currentMessageElement.ForeColor = SimpleColors.Color3.Color.Get24BitColor();
								break;
							case '4':
								currentMessageElement.ForeColor = SimpleColors.Color4.Color.Get24BitColor();
								break;
							case '5':
								currentMessageElement.ForeColor = SimpleColors.Color5.Color.Get24BitColor();
								break;
							case '6':
								currentMessageElement.ForeColor = SimpleColors.Color6.Color.Get24BitColor();
								break;
							case '7':
								currentMessageElement.ForeColor = SimpleColors.Color7.Color.Get24BitColor();
								break;
							case '8':
								currentMessageElement.ForeColor = SimpleColors.Color8.Color.Get24BitColor();
								break;
							case '9':
								currentMessageElement.ForeColor = SimpleColors.Color9.Color.Get24BitColor();
								break;
							case 'A':
								currentMessageElement.ForeColor = SimpleColors.ColorA.Color.Get24BitColor();
								break;
							case 'B':
								currentMessageElement.ForeColor = SimpleColors.ColorB.Color.Get24BitColor();
								break;
							case 'C':
								currentMessageElement.ForeColor = SimpleColors.ColorC.Color.Get24BitColor();
								break;
							case 'D':
								currentMessageElement.ForeColor = SimpleColors.ColorD.Color.Get24BitColor();
								break;
							case 'E':
								currentMessageElement.ForeColor = SimpleColors.ColorE.Color.Get24BitColor();
								break;
							case 'F':
								currentMessageElement.ForeColor = SimpleColors.ColorF.Color.Get24BitColor();
								break;

							case 'K':
								currentMessageElement.IsObfuscated = true;
								break;
							case 'L':
								currentMessageElement.IsBold = true;
								break;
							case 'M':
								currentMessageElement.IsStrikeout = true;
								break;
							case 'N':
								currentMessageElement.IsUnderlined = true;
								break;
							case 'O':
								currentMessageElement.IsItallic = true;
								break;

							case 'R':
								currentMessageElement.ForeColor = SimpleColors.White.Color.Get24BitColor();
								currentMessageElement.IsObfuscated = false;
								currentMessageElement.IsBold = false;
								currentMessageElement.IsStrikeout = false;
								currentMessageElement.IsItallic = false;
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

			RichTextString output = new RichTextString(elements);

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
				if (!thisElement.IsStrikeout && prevElement.IsStrikeout) shouldReset = true;
				if (!thisElement.IsUnderlined && prevElement.IsUnderlined) shouldReset = true;
				if (!thisElement.IsItallic && prevElement.IsItallic) shouldReset = true;
				if (shouldReset) output.Append("&" + 'R');

				if (thisElement.ForeColor != prevElement.ForeColor) output.Append("&" + thisElement.GetClosestColorCode());

				if (thisElement.IsObfuscated && !prevElement.IsObfuscated) output.Append("&" + 'K');
				if (thisElement.IsBold && !prevElement.IsBold) output.Append("&" + 'L');
				if (thisElement.IsStrikeout && !prevElement.IsStrikeout) output.Append("&" + 'M');
				if (thisElement.IsUnderlined && !prevElement.IsUnderlined) output.Append("&" + 'N');
				if (thisElement.IsItallic && !prevElement.IsItallic) output.Append("&" + 'O');

				output.Append(thisElement.Message);

				prevElement = thisElement;
			}
			return output.ToString();
		}
		#endregion
	}
}
