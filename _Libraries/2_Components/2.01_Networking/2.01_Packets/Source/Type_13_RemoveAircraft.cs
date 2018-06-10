using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_13_RemoveAircraft : GenericPacket, IPacket_13_RemoveAircraft
	{
		public Type_13_RemoveAircraft() : base(13)
		{
		}
		public Type_13_RemoveAircraft(UInt32 entityId) : base(13)
		{
			ID = entityId;
		}

		public UInt32 ID
		{
			get => GetUInt32(0);
			set => SetUInt32(0, value);
		}
	}
}
