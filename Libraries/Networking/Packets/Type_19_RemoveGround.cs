using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_19_RemoveGround : GenericPacket, IPacket_19_RemoveGround
	{
		public Type_19_RemoveGround() : base(19)
		{
		}
		public Type_19_RemoveGround(UInt32 entityId) : base(19)
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
