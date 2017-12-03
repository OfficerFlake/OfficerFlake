using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_12_Unjoin : GenericPacket
	{
		public Type_12_Unjoin() : base(12)
		{
		}
		public Type_12_Unjoin(Int32 entityId) : base(12)
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
