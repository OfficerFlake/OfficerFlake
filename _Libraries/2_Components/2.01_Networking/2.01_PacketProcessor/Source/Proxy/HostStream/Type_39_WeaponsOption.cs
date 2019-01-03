using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_39_WeaponsOption(IConnection thisConnection, IPacket_39_WeaponsOption packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
