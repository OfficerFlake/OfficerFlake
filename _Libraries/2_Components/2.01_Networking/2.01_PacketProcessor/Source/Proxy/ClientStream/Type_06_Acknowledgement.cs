﻿using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_06_Acknowledgement(IConnection thisConnection, IPacket_06_Acknowledgement packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
