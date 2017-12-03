using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_13_RemoveAircraft : GenericPacket
	{
		public Type_13_RemoveAircraft() : base(13)
		{
		}
		public Type_13_RemoveAircraft(Int32 entityId) : base(13)
		{
			EntityId = entityId;
		}

		public Int32 EntityId
		{
			get => GetInt32(0);
			set => SetInt32(0, value);
		}
	}
}
