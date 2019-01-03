using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_64_00_Null : GenericPacket, IPacket_64_00_Null
	{
		public Type_64_00_Null() : base(64)
		{
			ResizeData(4);
			UserPacketHeader = 0;
		}

		public UInt32 UserPacketHeader
		{
			get { return GetUInt32(0); }
			set { SetUInt32(0, value); }
		}
	}
}
