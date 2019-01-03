using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_36_WeaponsLoadout(IConnection thisConnection, IPacket_36_WeaponsLoadout packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
