using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_31_MissilesOption(IConnection thisConnection, IPacket_31_MissilesOption packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
