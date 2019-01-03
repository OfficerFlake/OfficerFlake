using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_38_QueryAirstate(IConnection thisConnection, IPacket_38_QueryAirstate packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
