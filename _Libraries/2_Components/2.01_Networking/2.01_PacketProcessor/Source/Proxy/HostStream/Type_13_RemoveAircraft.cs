using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_13_RemoveAircraft(IConnection thisConnection, IPacket_13_RemoveAircraft packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
