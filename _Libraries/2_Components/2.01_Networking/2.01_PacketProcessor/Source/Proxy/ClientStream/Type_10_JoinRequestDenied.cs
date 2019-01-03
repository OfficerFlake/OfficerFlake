using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_10_JoinRequestDenied(IConnection thisConnection, IPacket_10_JoinRequestDenied packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
