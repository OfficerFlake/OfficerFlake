using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_45_GroundCommand(IConnection thisConnection, IPacket_45_GroundCommand packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
