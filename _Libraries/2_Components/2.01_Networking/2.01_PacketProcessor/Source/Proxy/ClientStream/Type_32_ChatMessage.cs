using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_32_ChatMessage(IConnection thisConnection, IPacket_32_ChatMessage packet)
			{
				//TODO: TestPoint
				if (packet.Message.StartsWith("/Target "))
				{
					UInt32 target = 0;
					try
					{
						string strTarget = packet.Message.Split(' ')[1];
						target = UInt32.Parse(strTarget);
						thisConnection.SendToClientStream("Target: " + target);
					}
					catch
					{
						thisConnection.SendToClientStream("Target Cleared.");
					}
					return true;
				}
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
