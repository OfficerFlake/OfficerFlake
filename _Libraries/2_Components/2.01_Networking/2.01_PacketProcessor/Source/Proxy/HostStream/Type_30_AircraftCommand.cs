using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_30_AircraftCommand(IConnection thisConnection, IPacket_30_AircraftCommand packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
