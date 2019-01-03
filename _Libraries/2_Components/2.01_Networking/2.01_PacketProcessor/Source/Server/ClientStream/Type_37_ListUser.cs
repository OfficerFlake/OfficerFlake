using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_37_ListUser(IConnection thisConnection, IPacket_37_ListUser packet)
			{
				if (!SettingsLibrary.Settings.Options.AllowListUsers)
				{
					thisConnection.SendToClientStream("ListUsers is disabled on this server.");
					return true;
				}

				IPacket_37_ListUser ListConsole = ObjectFactory.CreatePacket37ListUser();
				ListConsole.ID = 0;
				ListConsole.IFF = 0;
				ListConsole.Identify = Users.Console.UserName.ToUnformattedSystemString();
				ListConsole.UserType = Packet_37UserType.ServerIdle;
				thisConnection.SendToClientStream(ListConsole);

				foreach (IConnection otherConnection in Connections.AllConnections)
				{
					short ClientType = 0;
					ushort IFF = 0;
					uint ID = 0;
					string Identify = "";

					if (otherConnection.Vehicle != Extensions.YSFlight.World.NoVehicle)
					{
						if (otherConnection.Vehicle != null) ClientType += 1;
						IFF = (ushort)(otherConnection.Vehicle?.IFF ?? 0);
						ID = (otherConnection.Vehicle?.ID ?? 0);
					}
					Identify = otherConnection.User.UserName.ToUnformattedSystemString();

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
					thisConnection.SendToClientStream(ListUser);
				}
				return true;
			}
		}
	}
}
