using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_07_SmokeColor(IConnection thisConnection, IPacket_07_SmokeColor packet)
			{
				foreach (IConnection otherConnection in Connections.LoggedIn.Exclude(thisConnection))
				{
					otherConnection.Send(packet);
				}
				return true;
				throw new NotImplementedException();
			}
		}
	}
}
