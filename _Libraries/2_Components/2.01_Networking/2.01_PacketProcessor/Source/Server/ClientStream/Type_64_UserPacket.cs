using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
	public static partial class PacketProcessor
	{
		public static partial class ServerClientStream
		{
			private static bool Process_Type_64_UserPacket(IConnection thisConnection, IPacket_64_UserPacket thisPacket)
			{
				switch (thisPacket.UserPacketHeader)
				{
					case 0:
					{
						IPacket_64_00_Null packet = ObjectFactory.CreatePacket64_00Null();
						packet.Data = thisPacket.Data;
						Process_Type_64_00_Null(thisConnection, packet);
						break;
					}
					case 1:
					{
						IPacket_64_01_OYSVersion packet = ObjectFactory.CreatePacket64_01OYSVersion();
						packet.Data = thisPacket.Data;
						Process_Type_64_01_OYSVersion(thisConnection, packet);
						break;
					}
					case 11:
					{
						IPacket_64_11_FormationFlightData packet = ObjectFactory.CreatePacket64_11FormationFlightData(3);
						packet.Data = thisPacket.Data;
						Process_Type_64_11_FormationFlightData(thisConnection, packet);
						break;
						}
					default:
					{
						throw new NotImplementedException("Not implemented User Packet: " + thisPacket.UserPacketHeader);
					}
				}
				return true;
			}
		}
	}
}
