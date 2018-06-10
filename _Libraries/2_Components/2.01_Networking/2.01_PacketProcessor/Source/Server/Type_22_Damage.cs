using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_22_Damage(IConnection thisConnection, IPacket_22_Damage packet)
			{
				Connections.LoggedIn.SendAsync(packet).ConfigureAwait(false);
				return true;
			}
		}
	}
}
