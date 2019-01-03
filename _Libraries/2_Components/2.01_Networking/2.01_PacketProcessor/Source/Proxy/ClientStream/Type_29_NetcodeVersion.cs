using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_29_NetcodeVersion(IConnection thisConnection, IPacket_29_NetcodeVersion packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
