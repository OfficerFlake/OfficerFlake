﻿using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_64_UserPacket : GenericPacket, IPacket_64_UserPacket
	{
		public Type_64_UserPacket() : base(64)
		{
			ResizeData(0);
		}

		public UInt32 UserPacketHeader
		{
			get { return GetUInt32(0); }
			set { SetUInt32(0, value); }
		}
	}
}
