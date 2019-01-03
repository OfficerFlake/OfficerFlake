using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_32_ChatMessage : GenericPacket, IPacket_32_ChatMessage
	{
		public Type_32_ChatMessage() : base(32)
		{
		}

		public Type_32_ChatMessage(string fullMessage) : base(32)
		{
			ResizeData(8);
			FullMessage = fullMessage;
		}

		public Type_32_ChatMessage(IUser user) : base(32)
		{
			ResizeData(8);
			User = user;
		}

		public Type_32_ChatMessage(IUser user, string Message) : base(32)
		{
			ResizeData(8);
			User = user;
			FullMessage = "(" + User.UserName.ToUnformattedSystemString() + ")" + Message;
		}

		public IUser User { get; set; } = Users.None;

		public String FullMessage
		{
			get => GetString(8, Data.Length-8).Split('\0')[0];
			set
			{
				if (value == null) value = "";
				ResizeData(8);
				SetString(8, value.Length+1,value+"\0");
			}
		}

		public String Message
		{
			get
			{
				if (User.UserName.ToUnformattedSystemString() == "")
				{
					return FullMessage;
				}
				return FullMessage.Substring(1 + User.UserName.ToUnformattedSystemString().Length + 1);
			}
			set
			{
				if (User.UserName.ToUnformattedSystemString() == "")
				{
					FullMessage = value + "\0";
				}
				FullMessage = FullMessage.Substring(0, 1 + User.UserName.ToUnformattedSystemString().Length + 1) + value + "\0";
			}
		}
	}
}
