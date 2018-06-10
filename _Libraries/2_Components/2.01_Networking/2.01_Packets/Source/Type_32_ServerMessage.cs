using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_32_ServerMessage : GenericPacket, IPacket_32_ServerMessage
	{
		public Type_32_ServerMessage() : base(32)
		{
		}

		public Type_32_ServerMessage(string message) : base(32)
		{
			Message = message;
		}

		public String Message
		{
			get => GetString(8, Data.Length-8).Split('\0')[0];
			set
			{
				if (value == null) value = "";
				ResizeData(8);
				SetString(8, value.Length+1,value+"\0");
			}
		}
	}
}
