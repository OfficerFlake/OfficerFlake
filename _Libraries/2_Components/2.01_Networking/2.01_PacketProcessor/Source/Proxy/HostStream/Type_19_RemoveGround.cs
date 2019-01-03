using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_19_RemoveGround(IConnection thisConnection, IPacket_19_RemoveGround packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
