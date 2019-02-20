using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_32_ChatMessage(IConnection thisConnection, IPacket_32_ChatMessage packet)
			{
				Console.AddUserMessage(packet.User, packet.Message);
				foreach (IConnection connection in Connections.AllConnections)
				{
					connection.SendToClientStreamAsync("(" + packet.User.UserName.ToUnformattedSystemString() + ")" + packet.Message).ConfigureAwait(false);
				}
				return true;
			}
		}
	}
}
