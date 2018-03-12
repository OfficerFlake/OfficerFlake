using System;
using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_37_ListUser : GenericPacket, IPacket_37_ListUser
	{
		public Type_37_ListUser() : base(37)
		{
		}

		public Packet_37UserType UserType
		{
			get
			{
				Int16 subData = GetInt16(0);
				switch (subData)
				{
					default:
					case 0:
						return Packet_37UserType.ClientIdle;
					case 1:
						return Packet_37UserType.ClientFlying;
					case 2:
						return Packet_37UserType.ServerIdle;
					case 3:
						return Packet_37UserType.ServerFlying;
				}
			}
			set
			{
				switch (value)
				{
					default:
					case Packet_37UserType.ClientIdle:
						SetInt16(0, 0);
						break;
					case Packet_37UserType.ClientFlying:
						SetInt16(0, 1);
						break;
					case Packet_37UserType.ServerIdle:
						SetInt16(0, 2);
						break;
					case Packet_37UserType.ServerFlying:
						SetInt16(0, 3);
						break;
				}
			}
		}
		public UInt16 IFF
		{
			get => GetUInt16(2);
			set => SetUInt16(2, value);
		}
		public UInt32 ID
		{
			get => GetUInt32(4);
			set => SetUInt32(4, value);
		}
		public String Identify
		{
			get => GetString(12, Data.Length - 12);
			set
			{
				ResizeData(12);
				SetString(12, value.Length+1, value+"\0");
			}
		}
	}
}
