using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Color;

namespace Com.OfficerFlake.Libraries.RichTextMessages
{
    public abstract class RichTextMessage
    {
		#region Properties
		public DateTime Created { get; set; }
		public string UserObject { get; set; }
	    public string String { get; set; }
		#endregion

	    public RichTextMessage(string input)
	    {
		    String = input;
		    UserObject = "<UNKNOWN>";
		    Created = DateTime.Now;

		    Elements = String.SplitStringByOwnFormatting();
	    }

		#region MessageTypes
		public enum MessageType
        {
            Unknown, //Not Assigned, don't know what this is.
            Crash, //Crash error message. When the program crashes entirely.
            Error, //Error message - function/method has broken.
            Debug, //A method is being debugged will spit this message. For very verbose output.
            Warning, //A method is acting strange, or some possible problem.
            Information, //system generated message.
            User //user generated message.
        }
        public MessageType Type = MessageType.Unknown;
		
		public string GetHtmlMessageType()
        {
            switch (Type)
            {
                default:
                case RichTextMessage.MessageType.Unknown:
                    return "unknown";
                case RichTextMessage.MessageType.Crash:
                    return "crash";
                case RichTextMessage.MessageType.Error:
                    return "error";
                case RichTextMessage.MessageType.Debug:
                    return "debug";
                case RichTextMessage.MessageType.Warning:
                    return "warning";
                case RichTextMessage.MessageType.Information:
                    return "information";
                case RichTextMessage.MessageType.User:
                    return "user";
            }
        }
		#endregion
		#region Message Elements
		public class MessageElement
        {
            public string Message = "";
            public MinecraftColor Color = MinecraftColor.White;

            public bool IsObfuscated;
            public bool IsBold;
            public bool IsStrikeThrough;
            public bool IsUnderlined;
            public bool IsItalic;

            public MessageElement()
            {
            }

            public MessageElement(string input)
            {
            }

            public MessageElement(string message, MinecraftColor color, bool isbold, bool isitalic, bool isunderlined,
                bool isobfuscated)
            {
                Message = message;
                Color = color;
                IsBold = isbold;
                IsItalic = isitalic;
                IsUnderlined = isunderlined;
                IsObfuscated = isobfuscated;
            }
        }
        public MessageElement[] Elements
        {
	        get;
            set;
        }
		#endregion

        public override string ToString()
        {
            return "<" + Created.ToLongDateString() + "> " + string.Join("", Elements.Select(x => x.Message));
        }
		#region Deprecated
		public string GetFormattedString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("<" + Created.ToLongDateString() + "> ");
            for (int i = 0; i < Elements.Length; i++)
            {
                var thisElement = Elements[i];
                output.Append("&" + thisElement.Color.Character);
                if (thisElement.IsObfuscated) output.Append("&K");
                if (thisElement.IsBold) output.Append("&L");
                if (thisElement.IsStrikeThrough) output.Append("&M");
                if (thisElement.IsUnderlined) output.Append("&N");
                if (thisElement.IsItalic) output.Append("&O");
                output.Append(thisElement.Message);
            }
            return output.ToString();
        }
		#endregion
	}

    public class CrashMessage : RichTextMessage
    {
        public CrashMessage(string input) : base("&e&l" + input)
        {
            Type = MessageType.Crash;
        }
    }
    public class ErrorMessage : RichTextMessage
    {
        public ErrorMessage(string input) : base(input)
        {
            Type = MessageType.Error;
        }
    }
    public class DebugMessage : RichTextMessage
    {
        public DebugMessage(string input) : base(input)
        {
            Type = MessageType.Debug;
        }
    }
    public class WarningMessage : RichTextMessage
    {
        public WarningMessage(string input) : base(input)
        {
            Type = MessageType.Warning;
        }
    }
    public class InformationMessage : RichTextMessage
    {
        public InformationMessage(string input) : base("&b&o" + input)
        {
            Type = MessageType.Information;
        }
    }
    public class UserMessage : RichTextMessage
    {
        public UserMessage(string input) : base(input)
        {
            Type = MessageType.User;
        }
    }
    
    public static class Extensions
    {
        public static RichTextMessage.MessageElement[] SplitStringByOwnFormatting(this string thisString)
        {
            char[] splittablechars = new[]
            {
	            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'K', 'L', 'M', 'N', 'O', 'R'
            };

            List<RichTextMessage.MessageElement> elements = new List<RichTextMessage.MessageElement>();

            RichTextMessage.MessageElement currentMessageElement = new RichTextMessage.MessageElement();

            bool isExpectingSplittableChar = false;
            for (int i = 0; i < thisString.Length; i++)
            {
                char thisCharUpperCase = thisString.ToUpperInvariant()[i];

                if (isExpectingSplittableChar)
                {
                    if (splittablechars.Contains(thisCharUpperCase))
                    {
                        if (currentMessageElement.Message.Length > 0) elements.Add(currentMessageElement);
                        currentMessageElement = new RichTextMessage.MessageElement()
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
                                currentMessageElement.Color = MinecraftColor.Black;
                                break;
                            case '1':
                                currentMessageElement.Color = MinecraftColor.DarkBlue;
                                break;
                            case '2':
                                currentMessageElement.Color = MinecraftColor.DarkGreen;
                                break;
                            case '3':
                                currentMessageElement.Color = MinecraftColor.Teal;
                                break;
                            case '4':
                                currentMessageElement.Color = MinecraftColor.DarkRed;
                                break;
                            case '5':
                                currentMessageElement.Color = MinecraftColor.Purple;
                                break;
                            case '6':
                                currentMessageElement.Color = MinecraftColor.Gold;
                                break;
                            case '7':
                                currentMessageElement.Color = MinecraftColor.Gray;
                                break;
                            case '8':
                                currentMessageElement.Color = MinecraftColor.DarkGray;
                                break;
                            case '9':
                                currentMessageElement.Color = MinecraftColor.Blue;
                                break;
                            case 'A':
                                currentMessageElement.Color = MinecraftColor.Green;
                                break;
                            case 'B':
                                currentMessageElement.Color = MinecraftColor.Aqua;
                                break;
                            case 'C':
                                currentMessageElement.Color = MinecraftColor.Red;
                                break;
                            case 'D':
                                currentMessageElement.Color = MinecraftColor.Magenta;
                                break;
                            case 'E':
                                currentMessageElement.Color = MinecraftColor.Yellow;
                                break;
                            case 'F':
                                currentMessageElement.Color = MinecraftColor.White;
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
                                currentMessageElement.Color = MinecraftColor.White;
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

            return elements.ToArray();
        }
        public static string JoinStringFromMessageElements(this RichTextMessage.MessageElement[] elements)
        {
            StringBuilder output = new StringBuilder();
            RichTextMessage.MessageElement prevElement = new RichTextMessage.MessageElement();
            for (int i = 0; i < elements.Length; i++)
            {
                RichTextMessage.MessageElement thisElement = elements[i];
                bool shouldReset = false;
                if (!thisElement.IsObfuscated && prevElement.IsObfuscated) shouldReset = true;
                if (!thisElement.IsBold && prevElement.IsBold) shouldReset = true;
                if (!thisElement.IsStrikeThrough && prevElement.IsStrikeThrough) shouldReset = true;
                if (!thisElement.IsUnderlined && prevElement.IsUnderlined) shouldReset = true;
                if (!thisElement.IsItalic && prevElement.IsItalic) shouldReset = true;
                if (shouldReset) output.Append("&" + 'R');

                if (thisElement.Color != prevElement.Color) output.Append("&" + thisElement.Color.Character);

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
    }
}
