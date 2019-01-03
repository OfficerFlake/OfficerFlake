using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_17_HeartBeat(IConnection thisConnection, IPacket_17_HeartBeat packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
