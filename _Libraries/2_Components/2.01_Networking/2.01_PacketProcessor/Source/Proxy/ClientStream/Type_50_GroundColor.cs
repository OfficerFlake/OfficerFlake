
using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_50_GroundColor(IConnection thisConnection, IPacket_50_GroundColor packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
