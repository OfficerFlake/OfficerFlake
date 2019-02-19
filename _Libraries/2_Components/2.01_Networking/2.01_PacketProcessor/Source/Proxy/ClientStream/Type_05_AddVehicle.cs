using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_05_AddVehicle(IConnection thisConnection, IPacket_05_AddVehicle packet)
			{
                return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
