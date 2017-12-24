using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Color;
using static Com.OfficerFlake.Libraries.Database;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.RichText
{
    public abstract class RichTextMessage : IRichTextMessage
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
			Datestamp = (OYSDate)DateTime.Now;
			Timestamp = (OYSTime)DateTime.Now;
			User = Users.Unknown;
		    String = input;
			Type = MessageType.Unknown;
		}
	    public RichTextMessage(string input)
	    {
		    Datestamp = (OYSDate)DateTime.Now;
		    Timestamp = (OYSTime)DateTime.Now;
		    User = Users.Unknown;
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
			User = Users.Unknown;
		}
	}

	public class UserMessage : RichTextMessage
	{
		public UserMessage(IUser userObject, string input) : base(input)
		{
			Type = MessageType.User;
			User = userObject;
		}
	}
	public class ConsoleInformationMessage : RichTextMessage
	{
		public ConsoleInformationMessage(string input) : base("&3&o" + input)
		{
			Type = MessageType.ConsoleInformation;
			User = Users.Console;
		}
	}

	public class DebugSummaryMessage : RichTextMessage
	{
		public DebugSummaryMessage(string input) : base("&b&o" + input)
		{
			Type = MessageType.DebugSummary;
			User = Users.Console;
		}
	}
	public class DebugDetailMessage : RichTextMessage
	{
		public DebugDetailMessage(string input) : base("&9&o" + input)
		{
			Type = MessageType.DebugDetail;
			User = Users.Console;
		}
	}
	public class DebugWarningMessage : RichTextMessage
	{
		public DebugWarningMessage(string input) : base("&e&o" + input)
		{
			Type = MessageType.DebugWarning;
			User = Users.Console;
		}
	}
	public class DebugErrorMessage : RichTextMessage
	{
		public DebugErrorMessage(Exception e, string input) : base("&c&o" + input + "\n" + "&c&o" + e.StackTrace)
		{
			Type = MessageType.DebugError;
			User = Users.Console;
		}
	}
	public class DebugCrashMessage : RichTextMessage
	{
		public DebugCrashMessage(Exception e, string input) : base("&c&o" + input + "\n" + "&c&o" + e.StackTrace)
		{
			Type = MessageType.DebugCrash;
			User = Users.Console;
			foreach (var thisElement in String.Elements)
			{
				thisElement.BackColor = new XRGBColor(240, 120, 120);
				thisElement.ForeColor = new XRGBColor(255, 255, 255);
			}
		}
	}
}
