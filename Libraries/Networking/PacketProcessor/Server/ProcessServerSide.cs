using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Networking
{
    public static partial class PacketProcessor
    {
	    public static partial class Server
	    {
		    public static bool Process(IConnection thisConnection, IPacket thisPacket)
		    {
			    switch (thisPacket.Type)
			    {
				    case 1:
					    IPacket_01_Login Packet01 = ObjectFactory.CreatePacket01Login();
					    Packet01.Data = thisPacket.Data;
					    return Process_Type_01_Login(thisConnection, Packet01);
				    case 3:
						IPacket_03_Error Packet03 = ObjectFactory.CreatePacket03Error();
					    Packet03.Data = thisPacket.Data;
					    return true;
					    //throw new NotImplementedException(); //Don't had object on client?
					case 4:
						IPacket_04_Field Packet04 = ObjectFactory.CreatePacket04Field();
						Packet04.Data = thisPacket.Data;
						return Process_Type_04_Field(thisConnection, Packet04);
					case 5:
						IPacket_05_AddVehicle Packet05 = ObjectFactory.CreatePacket05AddVehicle();
						Packet05.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 6:
						IPacket_06_Acknowledgement Packet06 = ObjectFactory.CreatePacket06Acknowledgement();
						Packet06.Data = thisPacket.Data;
						return Process_Type_06_Acknowledgement(thisConnection, Packet06);
					case 7:
						IPacket_07_SmokeColor Packet07 = ObjectFactory.CreatePacket07SmokeColor();
						Packet07.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 8:
						IPacket_08_JoinRequest Packet08 = ObjectFactory.CreatePacket08JoinRequest();
						Packet08.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 9:
						IPacket_09_JoinRequestApproved Packet09 = ObjectFactory.CreatePacket09JoinRequestApproved();
						Packet09.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 10:
						IPacket_10_JoinRequestDenied Packet10 = ObjectFactory.CreatePacket10JoinRequestDenied();
						Packet10.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 11:
						IPacket_11_FlightData Packet11 = ObjectFactory.CreatePacket11FlightData();
						Packet11.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 12:
						IPacket_12_LeaveFlight Packet12 = ObjectFactory.CreatePacket12LeaveFlight();
						Packet12.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 13:
						IPacket_13_RemoveAircraft Packet13 = ObjectFactory.CreatePacket13RemoveAircraft();
						Packet13.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 16:
						IPacket_16_PrepareSimulation Packet16 = ObjectFactory.CreatePacket16PrepareSimulation();
						Packet16.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 17:
						IPacket_17_HeartBeat Packet17 = ObjectFactory.CreatePacket17HeartBeat();
						Packet17.Data = thisPacket.Data;
						return Process_Type_17_HeartBeat(thisConnection, Packet17);
					case 18:
						IPacket_18_LockOn Packet18 = ObjectFactory.CreatePacket18LockOn();
						Packet18.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 19:
						IPacket_19_RemoveGround Packet19 = ObjectFactory.CreatePacket19RemoveGround();
						Packet19.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 20:
						IPacket_20_OrdinanceSpawn Packet20 = ObjectFactory.CreatePacket20OrdinanceSpawn();
						Packet20.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 21:
						IPacket_21_GroundData Packet21 = ObjectFactory.CreatePacket21GroundData();
						Packet21.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 22:
						IPacket_22_Damage Packet22 = ObjectFactory.CreatePacket22Damage();
						Packet22.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 29:
						IPacket_29_NetcodeVersion Packet29 = ObjectFactory.CreatePacket29NetcodeVersion();
						Packet29.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 30:
						IPacket_30_AircraftCommand Packet30 = ObjectFactory.CreatePacket30AircraftCommand();
						Packet30.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 31:
						IPacket_31_MissilesOption Packet31 = ObjectFactory.CreatePacket31MissilesOption();
						Packet31.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 32:
					    IPacket_32_ChatMessage thisChatMessage = ObjectFactory.CreatePacket32ChatMessage(thisConnection.User, "");
					    thisChatMessage.User = thisConnection.User;
					    thisChatMessage.Data = thisPacket.Data;
					    return Process_Type_32_ChatMessage(thisConnection, thisChatMessage);
				    case 33:
					    IPacket_33_Weather Packet33 = ObjectFactory.CreatePacket33Weather();
					    Packet33.Data = thisPacket.Data;
					    return Process_Type_33_Weather(thisConnection, Packet33);
					case 35:
						IPacket_35_ReviveAllGrounds Packet35 = ObjectFactory.CreatePacket35ReviveAllGrounds();
						Packet35.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 36:
						IPacket_36_WeaponsLoadout Packet36 = ObjectFactory.CreatePacket36WeaponsLoadout();
						Packet36.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 37:
						IPacket_37_ListUser Packet37 = ObjectFactory.CreatePacket37ListUser();
						Packet37.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 38:
						IPacket_38_QueryAirstate Packet38 = ObjectFactory.CreatePacket38QueryAirstate();
						Packet38.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 39:
						IPacket_39_WeaponsOption Packet39 = ObjectFactory.CreatePacket39WeaponsOption();
						Packet39.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 41:
						IPacket_41_UsernameDistance Packet41 = ObjectFactory.CreatePacket41UsernameDistance();
						Packet41.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 43:
						IPacket_43_ServerCommand Packet43 = ObjectFactory.CreatePacket43ServerCommand();
						Packet43.Data = thisPacket.Data;
						return Process_Type_43_ServerCommand(thisConnection, Packet43);
					case 44:
						IPacket_44_AircraftList Packet44 = ObjectFactory.CreatePacket44AircraftList();
						Packet44.Data = thisPacket.Data;
						return Process_Type_44_AircraftList(thisConnection, Packet44);
					case 45:
						IPacket_45_GroundCommand Packet45 = ObjectFactory.CreatePacket45GroundCommand();
						Packet45.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 47:
						IPacket_47_ForceJoin Packet47 = ObjectFactory.CreatePacket47ForceJoin();
						Packet47.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 48:
						IPacket_48_FogColor Packet48 = ObjectFactory.CreatePacket48FogColor();
						Packet48.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 49:
						IPacket_49_SkyColor Packet49 = ObjectFactory.CreatePacket49SkyColor();
						Packet49.Data = thisPacket.Data;
						throw new NotImplementedException();
					case 50:
						IPacket_50_GroundColor Packet50 = ObjectFactory.CreatePacket50GroundColor();
						Packet50.Data = thisPacket.Data;
						throw new NotImplementedException();
					default:
					    break;
			    }
			    return true;
		    }
	    }
    }
}
