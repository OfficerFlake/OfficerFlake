﻿using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_05_AddVehicle(IConnection thisConnection, IPacket_05_AddVehicle packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
