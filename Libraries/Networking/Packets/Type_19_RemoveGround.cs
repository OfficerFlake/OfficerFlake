using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_19_RemoveGround : GenericPacket
	{
		public Type_19_RemoveGround() : base(19)
		{
		}
		public Type_19_RemoveGround(Int32 entityId) : base(19)
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
