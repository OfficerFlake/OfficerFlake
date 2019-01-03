using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerHostStream
		{
			private static bool Process_Type_33_Weather(IConnection thisConnection, IPacket_33_Weather packet)
			{
				return thisConnection.SendToClientStream(packet);
			}
		}
	}
}
