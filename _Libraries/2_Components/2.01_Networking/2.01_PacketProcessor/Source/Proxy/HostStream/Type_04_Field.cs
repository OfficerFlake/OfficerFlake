﻿using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_04_Field(IConnection thisConnection, IPacket_04_Field packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
