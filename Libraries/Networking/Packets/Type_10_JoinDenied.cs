using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_10_JoinDenied : GenericPacket, IPacket_10_JoinRequestDenied
	{
		public Type_10_JoinDenied() : base(10)
		{
		}
	}
}
