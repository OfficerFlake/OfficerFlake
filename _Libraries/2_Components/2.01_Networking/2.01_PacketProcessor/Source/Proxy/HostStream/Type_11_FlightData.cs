using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_11_FlightData(IConnection thisConnection, IPacket_11_FlightData packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
