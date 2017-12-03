using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.OfficerFlake.Libraries.Networking;

namespace Com.OfficerFlake.Libraries.Networking.Packets
{
	public class Type_16_PrepareSimulation : GenericPacket
	{
		public Type_16_PrepareSimulation() : base(16)
		{
		}
	}
}
