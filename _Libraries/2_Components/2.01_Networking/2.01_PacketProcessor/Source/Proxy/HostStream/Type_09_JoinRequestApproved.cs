using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_09_JoinRequestApproved(IConnection thisConnection, IPacket_09_JoinRequestApproved packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
