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
				    "&r" +
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
