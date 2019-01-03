using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_35_ReviveAllGrounds(IConnection thisConnection, IPacket_35_ReviveAllGrounds packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
