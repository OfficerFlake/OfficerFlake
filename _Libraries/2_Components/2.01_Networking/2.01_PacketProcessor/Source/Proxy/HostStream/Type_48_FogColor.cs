﻿using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_48_FogColor(IConnection thisConnection, IPacket_48_FogColor packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
