using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Color;
using static Com.OfficerFlake.Libraries.Database;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.RichText
{
    public abstract class RichTextMessage
    {
		#region Properties
		public DateTime Created { get; set; }
		public User UserObject { get; set; }
	    public RichTextString String { get; set; }
		#endregion

	    public RichTextMessage(RichTextString input)
	    {
		    Created = DateTime.Now;
			UserObject = Users.Unknown;
		    String = input;
		}
	    public RichTextMessage(string input)
	    {
		    RichTextString _string = input.AsRichTextString();

			Created = DateTime.Now;
		    UserObject = Users.Unknown;
		    String = _string;
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

		#region RichTextMessage => Formatted System String
		/// <summary>
		/// Converts the RichTextMessage to a System String, preserving ALL internal formatting (Also preserves the formatting of the message elements!
		/// </summary>
		/// <returns>An internally formatted System String.</returns>
		public string ToFormattedString()
        {
			StringBuilder output = new StringBuilder();
	        output.Append(Created.InStandardForm().YYYYMMDD);
	        output.Append(" ");
	        output.Append(Created.InStandardForm().hhmmss);
	        output.Append(" ");
	        output.Append(UserObject);
	        output.Append(" ");
	        output.Append(String.ToUnformattedString());
	        return output.ToString();
		}
		#endregion
		#region RichTextMessage => Unformatted System String
	    public string ToUnformattedString()
	    {
			StringBuilder output = new StringBuilder();
		    output.Append("&" + MinecraftColor.DarkGray.Character);
			output.Append(Created.InStandardForm().YYYYMMDD);
		    output.Append(" ");
		    output.Append("&" + MinecraftColor.Gray.Character);
			output.Append(Created.InStandardForm().hhmmss);
		    output.Append(" ");
		    output.Append("&" + MinecraftColor.Teal.Character);
			output.Append(UserObject);
		    output.Append(" ");
		    output.Append("&" + MinecraftColor.White.Character);
			output.Append(String.ToFormattedString());
		    return output.ToString();
	    }
		#endregion

	    public override string ToString()
	    {
		    return String.ToUnformattedString();
	    }
    }

	public class UserMessage : RichTextMessage
	{
		public UserMessage(User userObject, string input) : base(input)
		{
			Type = MessageType.User;
			UserObject = userObject;
		}
	}

	public class DebugMessage : RichTextMessage
	{
		public DebugMessage(string input) : base("&9&o" + input)
		{
			Type = MessageType.Debug;
			UserObject = Users.Console;
		}
	}
	public class InformationMessage : RichTextMessage
	{
		public InformationMessage(string input) : base("&b&o" + input)
		{
			Type = MessageType.Information;
			UserObject = Users.Console;
		}
	}
	public class WarningMessage : RichTextMessage
	{
		public WarningMessage(string input) : base("&e&o" + input)
		{
			Type = MessageType.Warning;
			UserObject = Users.Console;
		}
	}
	public class ErrorMessage : RichTextMessage
	{
		public ErrorMessage(string input) : base("&4&n" + input)
		{
			Type = MessageType.Error;
			UserObject = Users.Console;
		}
	}
	public class CrashMessage : RichTextMessage
	{
		public CrashMessage(string input) : base("&c&l&n" + input)
		{
			Type = MessageType.Crash;
			UserObject = Users.Console;
		}
	}
}
