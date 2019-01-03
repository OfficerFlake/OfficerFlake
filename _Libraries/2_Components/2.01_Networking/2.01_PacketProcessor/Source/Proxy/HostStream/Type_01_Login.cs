using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_01_Login(IConnection thisConnection, IPacket_01_Login packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
