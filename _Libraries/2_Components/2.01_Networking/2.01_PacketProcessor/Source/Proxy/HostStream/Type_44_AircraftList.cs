using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_44_AircraftList(IConnection thisConnection, IPacket_44_AircraftList packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
