using System;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

using static Com.OfficerFlake.Libraries.SettingsLibrary;
using static Com.OfficerFlake.Libraries.Extensions.YSFlight;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ProxyServerClientStream
		{
			private static bool Process_Type_08_JoinRequest(IConnection thisConnection, IPacket_08_JoinRequest packet)
			{
				return thisConnection.SendToHostStream(packet);
			}
		}
	}
}
