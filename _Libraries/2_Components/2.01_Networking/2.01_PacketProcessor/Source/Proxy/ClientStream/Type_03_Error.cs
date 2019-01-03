using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_03_Error(IConnection thisConnection, IPacket_03_Error packet)
			{
				Logger.Debug.AddSummaryMessage("Server sends an error code (" + packet.ErrorCode + ") to " + thisConnection.User.UserName.ToInternallyFormattedSystemString());
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
