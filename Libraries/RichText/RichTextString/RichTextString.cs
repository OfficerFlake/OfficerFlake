using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.RichText
{
    public class RichTextString : IRichTextString
    {
	    #region Message Elements
	    public class MessageElement : IRichTextElement
	    {
			#region Properties
		    public string Message { get; set; } = "";
		    public IColor ForeColor { get; set; } = SimpleColors.White.Color;
		    public IColor BackColor { get; set; } = SimpleColors.Black.Color;

		    public bool IsBold { get; set; }
		    public bool IsItallic { get; set; }
		    public bool IsUnderlined { get; set; }
			public bool IsStrikeout { get; set; }
		    public bool IsObfuscated { get; set; }
			#endregion
			#region Constructors
			public MessageElement()
		    {
		    }

		    public MessageElement(string message, ISimpleColor simpleColor, bool isBold, bool isItallic, bool isUnderlined,
			    bool isObfuscated, bool isStrikeout)
		    {
			    Message = message;
			    ForeColor = simpleColor.Color;
			    IsBold = isBold;
			    IsItallic = isItallic;
			    IsUnderlined = isUnderlined;
			    IsObfuscated = isObfuscated;
		    }
			#endregion

		    public IColor GetColor(char charCode)
		    {
			    if (SimpleColors.List.All((x => x.ColorCode != charCode))) return SimpleColors.White.Color;
			    return SimpleColors.List.Last(x => x.ColorCode == charCode).Color;
		    }

		    public string ToInternallyFormattedSystemString()
		    {
			    return
					("&" + ForeColor.GetSimpleColor().ColorCode) +
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

	    public RichTextString(string formattedstring)
	    {
		    List<IRichTextElement> thisElements = new List<IRichTextElement>();
			thisElements.Add(new MessageElement());

		    IColor foreColor = SimpleColors.White.Color;
		    IColor backColor = SimpleColors.Black.Color;
		    Boolean isBold = false;
		    Boolean isItallic = false;
		    Boolean isUnderlined = false;
		    Boolean isStrikeout = false;
		    Boolean isObfuscated = false;

		    char previousChar = ' ';
		    char currentChar = ' ';
			StringBuilder currentString = new StringBuilder();
		    for (int i = 0; i < formattedstring.Length; i++)
		    {
			    previousChar = i > 0 ? formattedstring[i - 1] : ' ';
			    currentChar = formattedstring[i];

			    if (previousChar == '&' & currentChar == '&')
				{
					currentString.Append('&');
				}

			    if (currentChar == '&')
			    {
				    goto Next;
			    }

			    if (previousChar == '&')
			    {
				    switch (currentChar)
				    {
						case '0':
							foreColor = SimpleColors.Color0.Color;
							goto Next;
					    case '1':
						    foreColor = SimpleColors.Color1.Color;
						    goto Next;
					    case '2':
						    foreColor = SimpleColors.Color2.Color;
						    goto Next;
					    case '3':
						    foreColor = SimpleColors.Color3.Color;
						    goto Next;
					    case '4':
						    foreColor = SimpleColors.Color4.Color;
						    goto Next;
					    case '5':
						    foreColor = SimpleColors.Color5.Color;
						    goto Next;
					    case '6':
						    foreColor = SimpleColors.Color6.Color;
						    goto Next;
					    case '7':
						    foreColor = SimpleColors.Color7.Color;
						    goto Next;
					    case '8':
						    foreColor = SimpleColors.Color8.Color;
						    goto Next;
					    case '9':
						    foreColor = SimpleColors.Color9.Color;
						    goto Next;
					    case 'A':
						    foreColor = SimpleColors.ColorA.Color;
						    goto Next;
					    case 'B':
						    foreColor = SimpleColors.ColorB.Color;
						    goto Next;
					    case 'C':
						    foreColor = SimpleColors.ColorC.Color;
						    goto Next;
					    case 'D':
						    foreColor = SimpleColors.ColorD.Color;
						    goto Next;
					    case 'E':
						    foreColor = SimpleColors.ColorE.Color;
						    goto Next;
					    case 'F':
						    foreColor = SimpleColors.ColorF.Color;
						    goto Next;

						case 'L':
							isBold = true;
							goto Next;
					    case 'O':
						    isItallic = true;
						    goto Next;
					    case 'N':
						    isUnderlined = true;
						    goto Next;
					    case 'M':
						    isStrikeout = true;
						    goto Next;
					    case 'K':
						    isObfuscated = true;
						    goto Next;

					    case 'R':
						    foreColor = SimpleColors.White.Color;
						    backColor = SimpleColors.Black.Color;

							isBold = false;
						    isItallic = false;
						    isUnderlined = false;
						    isBold = false;
						    isStrikeout = false;
							goto Next;
					}
			    }
			    else
			    {
				    currentString.Append(currentChar);
			    }


			    Next:
			    {
				    if (thisElements.Last().ForeColor != foreColor |
				        thisElements.Last().BackColor != backColor |
				        thisElements.Last().IsBold != isBold |
				        thisElements.Last().IsItallic != isItallic |
				        thisElements.Last().IsUnderlined != isUnderlined |
				        thisElements.Last().IsStrikeout != isStrikeout |
				        thisElements.Last().IsObfuscated != isObfuscated)
				    {
					    thisElements.Add(new MessageElement(currentString.ToString(), foreColor.GetSimpleColor(), isBold, isItallic, isUnderlined, isObfuscated, isStrikeout));
					    currentString.Clear();
				    }

				    previousChar = currentChar;
					}
		    }

		    if (previousChar == '&') currentString.Append('&');
		    thisElements.Add(new MessageElement(currentString.ToString(), foreColor.GetSimpleColor(), isBold, isItallic, isUnderlined, isObfuscated, isStrikeout));
		    currentString.Clear();
		    thisElements.RemoveAll(x => x.Message == "");
			Elements = thisElements;

	    }

		#region RichTextString => Formatted System String
		/// <summary>
		/// Converts a RichTextString to a System String, by sperating with own internal formatting.
		/// </summary>
		/// <returns>An interanally formatted System String.</returns>
		public string ToInternallyFormattedSystemString()
	    {
			StringBuilder output = new StringBuilder();

		    IColor foreColor = SimpleColors.White.Color;
		    Boolean isBold = false;
		    Boolean isItallic = false;
		    Boolean isUnderlined = false;
		    Boolean isStrikeout = false;
		    Boolean isObfuscated = false;

			for (int i = 0; i < Elements.Count; i++)
		    {
				IRichTextElement currentElement = Elements[i];

			    if (isBold & !currentElement.IsBold |
			        isItallic & !currentElement.IsItallic |
			        isUnderlined & !currentElement.IsUnderlined |
			        isStrikeout & !currentElement.IsUnderlined |
			        isObfuscated & !currentElement.IsObfuscated)
			    {
				    output.Append("&r");
				    isBold = false;
				    isItallic = false;
				    isUnderlined = false;
				    isStrikeout = false;
				    isObfuscated = false;
			    }

			    if (foreColor != currentElement.ForeColor) output.Append("&" + currentElement.ForeColor.GetSimpleColor().ColorCode);
			    if (currentElement.IsBold) output.Append("&l");
			    if (currentElement.IsItallic) output.Append("&o");
			    if (currentElement.IsUnderlined) output.Append("&n");
			    if (currentElement.IsStrikeout) output.Append("&m");
			    if (currentElement.IsObfuscated) output.Append("&k");

			    output.Append(currentElement.Message);
		    }
		    return output.ToString();


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

				if (thisElement.ForeColor != prevElement.ForeColor) output.Append("&" + thisElement.ForeColor.GetSimpleColor().ColorCode);

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
