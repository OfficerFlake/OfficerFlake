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
	    private static readonly IFormattingDescriptor defaultFormattingDescriptor =
			ObjectFactory.CreateFormattingDescriptor(
				backColor: ObjectFactory.CreateColor(16, 16, 16),
				foreColor: SimpleColors.White.Color,
				isBold: false,
				isItallic: false,
				isUnderlined: false,
				isStrikeout: false,
				isObfuscated: false);

	    private readonly IFormattingDescriptor FormattingDescriptor = defaultFormattingDescriptor;

		#region Message Elements
		public class MessageElement : IRichTextElement
	    {
			#region Properties
		    public string Message { get; set; } = "";
		    public IColor ForeColor { get; set; } = defaultFormattingDescriptor.ForeColor;
			public IColor BackColor { get; set; } = defaultFormattingDescriptor.BackColor;
			public bool IsBold { get; set; } = defaultFormattingDescriptor.IsBold;
			public bool IsItallic { get; set; } = defaultFormattingDescriptor.IsItallic;
			public bool IsUnderlined { get; set; } = defaultFormattingDescriptor.IsUnderlined;
			public bool IsStrikeout { get; set; } = defaultFormattingDescriptor.IsStrikeout;
			public bool IsObfuscated { get; set; } = defaultFormattingDescriptor.IsObfuscated;
			#endregion
			#region Constructors
			public MessageElement()
		    {
		    }
		    public MessageElement(IFormattingDescriptor preFormattingDescriptor)
		    {
			    ForeColor = preFormattingDescriptor.ForeColor;
			    BackColor = preFormattingDescriptor.BackColor;
				IsBold = preFormattingDescriptor.IsBold;
			    IsItallic = preFormattingDescriptor.IsItallic;
			    IsUnderlined = preFormattingDescriptor.IsUnderlined;
				IsStrikeout = preFormattingDescriptor.IsStrikeout;
			    IsObfuscated = preFormattingDescriptor.IsObfuscated;
			}
			public MessageElement(string message, ISimpleColor simpleColor, bool isBold, bool isItallic, bool isUnderlined,
			    bool isObfuscated, bool isStrikeout)
		    {
			    Message = message;
			    ForeColor = simpleColor.Color;
			    IsBold = isBold;
			    IsItallic = isItallic;
			    IsUnderlined = isUnderlined;
			    IsStrikeout = isStrikeout;
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
		public List<IRichTextElement> Elements { get; set; } = new List<IRichTextElement>() { ObjectFactory.CreateRichTextElement(defaultFormattingDescriptor) };
		#endregion

		public RichTextString(List<IRichTextElement> _Elements)
	    {
		    Elements = _Elements;
	    }

	    public RichTextString(IFormattingDescriptor preformatting)
	    {
		    FormattingDescriptor = preformatting;
			Elements = new List<IRichTextElement>() { ObjectFactory.CreateRichTextElement(FormattingDescriptor) };
	    }
		public RichTextString(string formattedstring)
		{
			AddFormattedString(formattedstring);
		}

	    public void AddFormattedString(string formattedstring)
	    {
		    List<IRichTextElement> thisElements;

		    IFormattingDescriptor currentFormattingDescriptor = ObjectFactory.CreateFormattingDescriptor(
				foreColor: FormattingDescriptor.ForeColor,
				backColor: FormattingDescriptor.BackColor,
				isBold: FormattingDescriptor.IsBold,
				isItallic: FormattingDescriptor.IsItallic,
				isUnderlined: FormattingDescriptor.IsUnderlined,
				isStrikeout: FormattingDescriptor.IsStrikeout,
				isObfuscated: FormattingDescriptor.IsObfuscated
				);

			if (Elements == null)
		    {
			    thisElements = new List<IRichTextElement>();
			}
		    else
		    {
			    thisElements = Elements;
			}

		    if (!thisElements.Any())
		    {
			    thisElements.Add(new MessageElement(FormattingDescriptor));
			    currentFormattingDescriptor.ForeColor = FormattingDescriptor.ForeColor;
			    currentFormattingDescriptor.BackColor = FormattingDescriptor.BackColor;
			    currentFormattingDescriptor.IsBold = FormattingDescriptor.IsBold;
			    currentFormattingDescriptor.IsItallic = FormattingDescriptor.IsItallic;
			    currentFormattingDescriptor.IsUnderlined = FormattingDescriptor.IsUnderlined;
			    currentFormattingDescriptor.IsStrikeout = FormattingDescriptor.IsStrikeout;
			    currentFormattingDescriptor.IsObfuscated = FormattingDescriptor.IsObfuscated;
			}
		    else
		    {
			    currentFormattingDescriptor.ForeColor = Elements.Last().ForeColor;
			    currentFormattingDescriptor.BackColor = Elements.Last().BackColor;
			    currentFormattingDescriptor.IsBold = Elements.Last().IsBold;
			    currentFormattingDescriptor.IsItallic = Elements.Last().IsItallic;
			    currentFormattingDescriptor.IsUnderlined = Elements.Last().IsUnderlined;
			    currentFormattingDescriptor.IsStrikeout = Elements.Last().IsStrikeout;
			    currentFormattingDescriptor.IsObfuscated = Elements.Last().IsObfuscated;
			}

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
							currentFormattingDescriptor.ForeColor = SimpleColors.Color0.Color;
							goto Next;
						case '1':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color1.Color;
							goto Next;
						case '2':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color2.Color;
							goto Next;
						case '3':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color3.Color;
							goto Next;
						case '4':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color4.Color;
							goto Next;
						case '5':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color5.Color;
							goto Next;
						case '6':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color6.Color;
							goto Next;
						case '7':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color7.Color;
							goto Next;
						case '8':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color8.Color;
							goto Next;
						case '9':
							currentFormattingDescriptor.ForeColor = SimpleColors.Color9.Color;
							goto Next;
						case 'A':
							currentFormattingDescriptor.ForeColor = SimpleColors.ColorA.Color;
							goto Next;
						case 'B':
							currentFormattingDescriptor.ForeColor = SimpleColors.ColorB.Color;
							goto Next;
						case 'C':
							currentFormattingDescriptor.ForeColor = SimpleColors.ColorC.Color;
							goto Next;
						case 'D':
							currentFormattingDescriptor.ForeColor = SimpleColors.ColorD.Color;
							goto Next;
						case 'E':
							currentFormattingDescriptor.ForeColor = SimpleColors.ColorE.Color;
							goto Next;
						case 'F':
							currentFormattingDescriptor.ForeColor = SimpleColors.ColorF.Color;
							goto Next;

						case 'L':
							currentFormattingDescriptor.IsBold = true;
							goto Next;
						case 'O':
							currentFormattingDescriptor.IsItallic = true;
							goto Next;
						case 'N':
							currentFormattingDescriptor.IsUnderlined = true;
							goto Next;
						case 'M':
							currentFormattingDescriptor.IsStrikeout = true;
							goto Next;
						case 'K':
							currentFormattingDescriptor.IsObfuscated = true;
							goto Next;

						case 'R':
							currentFormattingDescriptor.ForeColor = SimpleColors.White.Color;
							currentFormattingDescriptor.BackColor = SimpleColors.Black.Color;

							currentFormattingDescriptor.IsBold = false;
							currentFormattingDescriptor.IsItallic = false;
							currentFormattingDescriptor.IsUnderlined = false;
							currentFormattingDescriptor.IsStrikeout = false;
							currentFormattingDescriptor.IsObfuscated = false;
							goto Next;
					}
				}
				else
				{
					currentString.Append(currentChar);
				}


				Next:
				{
					if (thisElements.Last().ForeColor != currentFormattingDescriptor.ForeColor |
						thisElements.Last().BackColor != currentFormattingDescriptor.BackColor |
						thisElements.Last().IsBold != currentFormattingDescriptor.IsBold |
						thisElements.Last().IsItallic != currentFormattingDescriptor.IsItallic |
						thisElements.Last().IsUnderlined != currentFormattingDescriptor.IsUnderlined |
						thisElements.Last().IsStrikeout != currentFormattingDescriptor.IsStrikeout |
						thisElements.Last().IsObfuscated != currentFormattingDescriptor.IsObfuscated)
					{
						var nextElement = new MessageElement(currentFormattingDescriptor);
						nextElement.Message = currentString.ToString();
						thisElements.Add(nextElement);
						currentString.Clear();
					}

					previousChar = currentChar;
				}
			}

			if (previousChar == '&') currentString.Append('&');
		    var finalElement = new MessageElement(currentFormattingDescriptor);
		    finalElement.Message = currentString.ToString();
			thisElements.Add(finalElement);
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
