using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_16_PrepareSimulation(IConnection thisConnection, IPacket_16_PrepareSimulation packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
