using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_12_Unjoin : GenericPacket, IPacket_12_LeaveFlight
	{
		public Type_12_Unjoin() : base(12)
		{
		}
		public Type_12_Unjoin(UInt32 entityId) : base(12)
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
