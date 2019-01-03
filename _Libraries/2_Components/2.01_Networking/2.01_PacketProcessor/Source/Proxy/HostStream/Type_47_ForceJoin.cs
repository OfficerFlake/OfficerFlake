using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_47_ForceJoin(IConnection thisConnection, IPacket_47_ForceJoin packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
