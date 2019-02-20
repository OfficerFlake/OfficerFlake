using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_03_Error(IConnection thisConnection, IPacket_03_Error packet)
			{
				Loggers.Debug.AddSummaryMessage(thisConnection.User.UserName.ToInternallyFormattedSystemString() + " sends an error code (" + packet.ErrorCode + ")");
				return true;
			}
		}
	}
}
