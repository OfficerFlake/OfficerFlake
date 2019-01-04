using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
    public static partial class PacketProcessor
    {
	    public static partial class ServerClientStream
	    {
		    public static async Task<bool> Process(IConnection thisConnection, IPacket thisPacket)
		    {
			    switch (thisPacket.Type)
				{
					case 1:
					{
						IPacket_01_Login packet = ObjectFactory.CreatePacket01Login();
						packet.Data = thisPacket.Data;
						return Process_Type_01_Login(thisConnection, packet);
					}
					case 3:
					{
						IPacket_03_Error packet = ObjectFactory.CreatePacket03Error();
						packet.Data = thisPacket.Data;
						return Process_Type_03_Error(thisConnection, packet);
					}
					case 4:
					{
						IPacket_04_Field packet = ObjectFactory.CreatePacket04Field();
						packet.Data = thisPacket.Data;
						return Process_Type_04_Field(thisConnection, packet);
					}
					case 5:
					{
						IPacket_05_AddVehicle packet = ObjectFactory.CreatePacket05AddVehicle();
						packet.Data = thisPacket.Data;
						return Process_Type_05_AddVehicle(thisConnection, packet);
					}
					case 6:
					{
						IPacket_06_Acknowledgement packet = ObjectFactory.CreatePacket06Acknowledgement();
						packet.Data = thisPacket.Data;
						return Process_Type_06_Acknowledgement(thisConnection, packet);
					}
					case 7:
					{
						IPacket_07_SmokeColor packet = ObjectFactory.CreatePacket07SmokeColor();
						packet.Data = thisPacket.Data;
						return Process_Type_07_SmokeColor(thisConnection, packet);
					}
					case 8:
					{
						IPacket_08_JoinRequest packet = ObjectFactory.CreatePacket08JoinRequest();
						packet.Data = thisPacket.Data;
						return Process_Type_08_JoinRequest(thisConnection, packet);
					}
					case 9:
					{
						IPacket_09_JoinRequestApproved packet = ObjectFactory.CreatePacket09JoinRequestApproved();
						packet.Data = thisPacket.Data;
						return Process_Type_09_JoinRequestApproved(thisConnection, packet);
					}
					case 10:
					{
						IPacket_10_JoinRequestDenied packet = ObjectFactory.CreatePacket10JoinRequestDenied();
						packet.Data = thisPacket.Data;
						return Process_Type_10_JoinRequestDenied(thisConnection, packet);
					}
					case 11:
					{
						IPacket_11_FlightData packet = ObjectFactory.CreatePacket11FlightData();
						packet.Data = thisPacket.Data;
						return Process_Type_11_FlightData(thisConnection, packet);
					}
					case 12:
					{
						IPacket_12_LeaveFlight packet = ObjectFactory.CreatePacket12LeaveFlight();
						packet.Data = thisPacket.Data;
						return Process_Type_12_LeaveFlight(thisConnection, packet);
					}
					case 13:
					{
						IPacket_13_RemoveAircraft packet = ObjectFactory.CreatePacket13RemoveAircraft();
						packet.Data = thisPacket.Data;
						return Process_Type_13_RemoveAircraft(thisConnection, packet);
					}
					case 16:
					{
						IPacket_16_PrepareSimulation packet = ObjectFactory.CreatePacket16PrepareSimulation();
						packet.Data = thisPacket.Data;
						return Process_Type_16_PrepareSimulation(thisConnection, packet);
					}
					case 17:
					{
						IPacket_17_HeartBeat packet = ObjectFactory.CreatePacket17HeartBeat();
						packet.Data = thisPacket.Data;
						return Process_Type_17_HeartBeat(thisConnection, packet);
					}
					case 18:
					{
						IPacket_18_LockOn packet = ObjectFactory.CreatePacket18LockOn();
						packet.Data = thisPacket.Data;
						return Process_Type_18_LockOn(thisConnection, packet);
					}
					case 19:
					{
						IPacket_19_RemoveGround packet = ObjectFactory.CreatePacket19RemoveGround();
						packet.Data = thisPacket.Data;
						return Process_Type_19_RemoveGround(thisConnection, packet);
					}
					case 20:
					{
						IPacket_20_OrdinanceSpawn packet = ObjectFactory.CreatePacket20OrdinanceSpawn();
						packet.Data = thisPacket.Data;
						return Process_Type_20_OrdinanceSpawn(thisConnection, packet);
					}
					case 21:
					{
						IPacket_21_GroundData packet = ObjectFactory.CreatePacket21GroundData();
						packet.Data = thisPacket.Data;
						return Process_Type_21_GroundData(thisConnection, packet);
					}
					case 22:
					{
						IPacket_22_Damage packet = ObjectFactory.CreatePacket22Damage();
						packet.Data = thisPacket.Data;
						return Process_Type_22_Damage(thisConnection, packet);
					}
					case 29:
					{
						IPacket_29_NetcodeVersion packet = ObjectFactory.CreatePacket29NetcodeVersion();
						packet.Data = thisPacket.Data;
						return Process_Type_29_NetcodeVersion(thisConnection, packet);
					}
					case 30:
					{
						IPacket_30_AircraftCommand packet = ObjectFactory.CreatePacket30AircraftCommand();
						packet.Data = thisPacket.Data;
						return Process_Type_30_AircraftCommand(thisConnection, packet);
					}
					case 31:
					{
						IPacket_31_MissilesOption packet = ObjectFactory.CreatePacket31MissilesOption();
						packet.Data = thisPacket.Data;
						return Process_Type_31_MissilesOption(thisConnection, packet);
					}
					case 32:
					{
						IPacket_32_ChatMessage packet = ObjectFactory.CreatePacket32ChatMessage(thisConnection.User, "");
						packet.Data = thisPacket.Data;
						return Process_Type_32_ChatMessage(thisConnection, packet);
					}
					case 33:
					{
						IPacket_33_Weather packet = ObjectFactory.CreatePacket33Weather();
						packet.Data = thisPacket.Data;
						return Process_Type_33_Weather(thisConnection, packet);
					}
					case 35:
					{
						IPacket_35_ReviveAllGrounds packet = ObjectFactory.CreatePacket35ReviveAllGrounds();
						packet.Data = thisPacket.Data;
						return Process_Type_35_ReviveAllGrounds(thisConnection, packet);
					}
					case 36:
					{
						IPacket_36_WeaponsLoadout packet = ObjectFactory.CreatePacket36WeaponsLoadout();
						packet.Data = thisPacket.Data;
						return Process_Type_36_WeaponsLoadout(thisConnection, packet);
					}
					case 37:
					{
						IPacket_37_ListUser packet = ObjectFactory.CreatePacket37ListUser();
						packet.Data = thisPacket.Data;
						return Process_Type_37_ListUser(thisConnection, packet);
					}
					case 38:
					{
						IPacket_38_QueryAirstate packet = ObjectFactory.CreatePacket38QueryAirstate();
						packet.Data = thisPacket.Data;
						return Process_Type_38_QueryAirstate(thisConnection, packet);
					}
					case 39:
					{
						IPacket_39_WeaponsOption packet = ObjectFactory.CreatePacket39WeaponsOption();
						packet.Data = thisPacket.Data;
						return Process_Type_39_WeaponsOption(thisConnection, packet);
					}
					case 41:
					{
						IPacket_41_UsernameDistance packet = ObjectFactory.CreatePacket41UsernameDistance();
						packet.Data = thisPacket.Data;
						return Process_Type_41_UsernameDistance(thisConnection, packet);
					}
					case 43:
					{
						IPacket_43_ServerCommand packet = ObjectFactory.CreatePacket43ServerCommand();
						packet.Data = thisPacket.Data;
						return Process_Type_43_ServerCommand(thisConnection, packet);
					}
					case 44:
					{
						IPacket_44_AircraftList packet = ObjectFactory.CreatePacket44AircraftList();
						packet.Data = thisPacket.Data;
						return Process_Type_44_AircraftList(thisConnection, packet);
					}
					case 45:
					{
						IPacket_45_GroundCommand packet = ObjectFactory.CreatePacket45GroundCommand();
						packet.Data = thisPacket.Data;
						return Process_Type_45_GroundCommand(thisConnection, packet);
					}
					case 47:
					{
						IPacket_47_ForceJoin packet = ObjectFactory.CreatePacket47ForceJoin();
						packet.Data = thisPacket.Data;
						return Process_Type_47_ForceJoin(thisConnection, packet);
					}
					case 48:
					{
						IPacket_48_FogColor packet = ObjectFactory.CreatePacket48FogColor();
						packet.Data = thisPacket.Data;
						return Process_Type_48_FogColor(thisConnection, packet);
					}
					case 49:
					{
						IPacket_49_SkyColor packet = ObjectFactory.CreatePacket49SkyColor();
						packet.Data = thisPacket.Data;
						return Process_Type_49_SkyColor(thisConnection, packet);
					}
					case 50:
					{
						IPacket_50_GroundColor packet = ObjectFactory.CreatePacket50GroundColor();
						packet.Data = thisPacket.Data;
						return Process_Type_50_GroundColor(thisConnection, packet);
					}
					case 64:
					{
						IPacket_64_UserPacket packet = ObjectFactory.CreatePacket64UserPacket();
						packet.Data = thisPacket.Data;
						return Process_Type_64_UserPacket(thisConnection, packet);
					}
					default:
					{
						break;
					}
				}
			    return true;
		    }
	    }
    }
}
