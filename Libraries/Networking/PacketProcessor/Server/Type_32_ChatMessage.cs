using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_32_ChatMessage(IConnection thisConnection, IPacket_32_ChatMessage ChatMessagePacket)
			{
				foreach (IConnection otherConnection in ObjectFactory.AllConnections)
				{
					otherConnection.SendMessageAsync("(" + ChatMessagePacket.User.UserName.ToUnformattedSystemString() + ")" + ChatMessagePacket.Message).ConfigureAwait(false);
				}
				return true;
			}
		}
	}
}
