using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_49_SkyColor(IConnection thisConnection, IPacket_49_SkyColor packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
