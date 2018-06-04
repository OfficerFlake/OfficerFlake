using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class Server
		{
			private static bool Process_Type_37_ListUser(IConnection thisConnection, IPacket_37_ListUser packet)
			{
				if (!SettingsLibrary.Settings.Options.AllowListUsers)
				{
					thisConnection.SendMessageAsync("ListUsers is disabled on this server.");
					return true;
				}
				foreach (IConnection OtherClient in Connections.AllConnections)
				{
					short ClientType = 0;
					ushort IFF = 0;
					uint ID = 0;
					string Identify = "";

					if (OtherClient.Vehicle != Extensions.YSFlight.World.NoVehicle)
					{
						if (OtherClient.Vehicle != null) ClientType += 1;
						IFF = (ushort)(OtherClient.Vehicle?.IFF ?? 0);
						ID = (OtherClient.Vehicle?.ID ?? 0);
					}
					Identify = OtherClient.User.UserName.ToUnformattedSystemString();

					IPacket_37_ListUser ListUser = ObjectFactory.CreatePacket37ListUser();
					ListUser.ID = ID;
					ListUser.IFF = IFF;
					ListUser.Identify = Identify;
					switch (ClientType)
					{
						default:
						case 0:
							ListUser.UserType = Packet_37UserType.ClientIdle;
							break;
						case 1:
							ListUser.UserType = Packet_37UserType.ClientFlying;
							break;
						case 2:
							ListUser.UserType = Packet_37UserType.ServerIdle;
							break;
						case 3:
							ListUser.UserType = Packet_37UserType.ServerFlying;
							break;
					}
					thisConnection.SendAsync(ListUser);
				}
				return true;
			}
		}
	}
}
