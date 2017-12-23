using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_09_JoinApproved : GenericPacket, IPacket_09_JoinRequestApproved
	{
		public Type_09_JoinApproved() : base(9)
		{
		}
	}
}
