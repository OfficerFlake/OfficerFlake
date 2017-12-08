using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_32_ChatMessage : GenericPacket
	{
		public Type_32_ChatMessage() : base(32)
		{
		}

		public Type_32_ChatMessage(string fullMessage) : base(32)
		{
			FullMessage = fullMessage;
		}

		public Type_32_ChatMessage(string username, string message) : base(32)
		{
			_Username = username;
			Message = message;
		}

		private string _Username = "";

		public bool SetUsername(string username)
		{
			_Username = username;
			return true;
		}

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
				if (_Username == "")
				{
					return FullMessage;
				}
				return FullMessage.Substring(1 + _Username.Length + 1);
			}
			set
			{
				if (_Username == "")
				{
					FullMessage = value + "\0";
				}
				FullMessage = FullMessage.Substring(0, 1 + _Username.Length + 1) + value + "\0";
			}
		}
	}
}
