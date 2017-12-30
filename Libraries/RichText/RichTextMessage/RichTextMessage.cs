using System;
using System.Text;

using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.RichText
{
    public class RichTextMessage : IRichTextMessage
    {
		#region Properties
		public IDate Datestamp { get; set; }
	    public ITime Timestamp { get; set; }
		public IUser User { get; set; }
	    public IRichTextString String { get; set; }
		public MessageType Type { get; set; }
		#endregion

		public RichTextMessage(IRichTextString input)
		{
			Datestamp = DateTime.Now.ToDate();
			Timestamp = DateTime.Now.ToTime();
			User = Users.None;
		    String = input;
			Type = MessageType.Unknown;
		}
	    public RichTextMessage(string input)
	    {
			Datestamp = DateTime.Now.ToDate();
		    Timestamp = DateTime.Now.ToTime();
		    User = Users.None;
			String = input.AsRichTextString();
			Type = MessageType.Unknown;
		}

		#region MessageTypes
		public string GetHtmlMessageType()
        {
            switch (Type)
            {
				default:
                case MessageType.Unknown:
                    return "unknown";
                case MessageType.User:
                    return "user";
                case MessageType.ConsoleInformation:
                    return "consoleinformation";
                case MessageType.DebugSummary:
                    return "debugsummary";
                case MessageType.DebugDetail:
                    return "debugdetail";
                case MessageType.DebugWarning:
                    return "debugwarning";
                case MessageType.DebugError:
                    return "debugerror";
	            case MessageType.DebugCrash:
		            return "debugcrash";
		}
        }
		#endregion

		#region RichTextMessage => Formatted System String
		/// <summary>
		/// Converts the RichTextMessage to a System String, preserving ALL internal formatting (Also preserves the formatting of the message elements!
		/// </summary>
		/// <returns>An internally formatted System String.</returns>
		public string ToFormattedString()
        {
			StringBuilder output = new StringBuilder();
	        output.Append(Datestamp.ToSystemString());
	        output.Append(" ");
	        output.Append(Timestamp.ToSystemString());
	        output.Append(" ");
	        output.Append(User.UserName.ToUnformattedSystemString());
	        output.Append(" ");
	        output.Append(String.ToUnformattedSystemString());
	        return output.ToString();
		}
		#endregion
		#region RichTextMessage => Unformatted System String
	    public string ToUnformattedString()
	    {
			StringBuilder output = new StringBuilder();
		    output.Append("&" + SimpleColors.DarkGray.ColorCode);
			output.Append(Datestamp);
		    output.Append(" ");
		    output.Append("&" + SimpleColors.Gray.ColorCode);
			output.Append(Timestamp);
		    output.Append(" ");
		    output.Append("&" + SimpleColors.Teal.ColorCode);
			output.Append(User.UserName.ToInternallyFormattedSystemString());
		    output.Append(" ");
		    output.Append("&" + SimpleColors.White.ColorCode);
			output.Append(String.ToInternallyFormattedSystemString());
		    return output.ToString();
	    }
		#endregion

	    public override string ToString()
	    {
		    return String.ToUnformattedSystemString();
	    }
    }

	public class UnknownMessage : RichTextMessage
	{
		public UnknownMessage(string input) : base(input)
		{
			Type = MessageType.Unknown;
			User = Users.None;
		}
	}

	public class ConsoleUserMessage : RichTextMessage, IConsoleUserMessage
	{
		public ConsoleUserMessage(IUser userObject, IRichTextString input) : base(input)
		{
			Type = MessageType.User;
			User = userObject;
		}
	}
	public class ConsoleInformationMessage : RichTextMessage, IConsoleInformationMessage
	{
		public ConsoleInformationMessage(IRichTextString input) : base(input.ToInternallyFormattedSystemString())
		{
			Type = MessageType.ConsoleInformation;
			User = Users.Console;
		}
	}

	public class DebugSummaryMessage : RichTextMessage, IDebugSummaryMessage
	{
		public DebugSummaryMessage(IRichTextString input) : base(input.ToInternallyFormattedSystemString())
		{
			Type = MessageType.DebugSummary;
			User = Users.Console;
		}
	}
	public class DebugDetailMessage : RichTextMessage, IDebugDetailMessage
	{
		public DebugDetailMessage(IRichTextString input) : base("&9&o" + input.ToInternallyFormattedSystemString())
		{
			Type = MessageType.DebugDetail;
			User = Users.Console;
		}
	}
	public class DebugWarningMessage : RichTextMessage, IDebugWarningMessage
	{
		public DebugWarningMessage(IRichTextString input) : base("&e&o" + input.ToInternallyFormattedSystemString())
		{
			Type = MessageType.DebugWarning;
			User = Users.Console;
		}
	}
	public class DebugErrorMessage : RichTextMessage, IDebugErrorMessage
	{
		public DebugErrorMessage(Exception e, IRichTextString input) : base("&c&o" + input.ToInternallyFormattedSystemString() + "\n" + "&c&o" + e.StackTrace)
		{
			Type = MessageType.DebugError;
			User = Users.Console;
		}
	}
	public class DebugCrashMessage : RichTextMessage, IDebugCrashMessage
	{
		public DebugCrashMessage(Exception e, IRichTextString input) : base("&c&o" + input.ToInternallyFormattedSystemString() + "\n" + "&c&o" + e.StackTrace)
		{
			Type = MessageType.DebugCrash;
			User = Users.Console;
		}
	}
}
