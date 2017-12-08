using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Networking.Packets;
using Com.OfficerFlake.Libraries.YSFlight;
using static Com.OfficerFlake.Libraries.Networking.Connection;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_32_ChatMessage(Connection thisConnection, Packets.Type_32_ChatMessage ChatMessagePacket)
			{
				foreach (Connection otherConnection in AllConnections)
				{
					otherConnection.SendMessageAsync(ChatMessagePacket.FullMessage).ConfigureAwait(false);
				}
				return true;
			}
		}
	}
}
