using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_13_RemoveAircraft(IConnection thisConnection, IPacket_13_RemoveAircraft packet)
			{
			    return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
