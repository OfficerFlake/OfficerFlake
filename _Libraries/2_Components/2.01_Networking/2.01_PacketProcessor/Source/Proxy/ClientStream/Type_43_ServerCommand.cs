using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_43_ServerCommand(IConnection thisConnection, IPacket_43_ServerCommand packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
