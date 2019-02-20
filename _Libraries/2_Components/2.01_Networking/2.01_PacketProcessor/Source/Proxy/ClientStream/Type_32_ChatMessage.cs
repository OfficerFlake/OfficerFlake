using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_32_ChatMessage(IConnection thisConnection, IPacket_32_ChatMessage packet)
			{
                //TODO : [5] Fix Connection Issues
                //Test Implementation So Far
                //Build next Debug Release and push for testing.
                return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
