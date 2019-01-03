﻿using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_21_GroundData(IConnection thisConnection, IPacket_21_GroundData packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
