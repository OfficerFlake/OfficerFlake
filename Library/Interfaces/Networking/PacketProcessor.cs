using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IPacketProcessor
	{
		bool Process(IConnection connection, IPacket packet);
		bool Process_Type_01_Login(IConnection connection, IPacket_01_Login packet);
		bool Process_Type_03_Errpr(IConnection connection, IPacket_03_Error packet);
		bool Process_Type_04_Field(IConnection connection, IPacket_04_Field packet);
		bool Process_Type_05_AddVehicle(IConnection connection, IPacket_05_AddVehicle packet);
		bool Process_Type_06_Acknowledgement(IConnection connection, IPacket_06_Acknowledgement packet);
		bool Process_Type_07_SmokeColor(IConnection connection, IPacket_07_SmokeColor packet);
		bool Process_Type_08_JoinRequest(IConnection connection, IPacket_08_JoinRequest packet);
		bool Process_Type_09_JoinRequestApproved(IConnection connection, IPacket_09_JoinRequestApproved packet);
		bool Process_Type_10_JoinRequestDenied(IConnection connection, IPacket_10_JoinRequestDenied packet);
		bool Process_Type_11_FlightData(IConnection connection, IPacket_11_FlightData packet);
		bool Process_Type_12_LeaveFlight(IConnection connection, IPacket_12_LeaveFlight packet);
		bool Process_Type_13_RemoveAircraft(IConnection connection, IPacket_13_RemoveAircraft packet);
		bool Process_Type_16_PrepareSimulation(IConnection connection, IPacket_16_PrepareSimulation packet);
		bool Process_Type_17_HeartBeat(IConnection connection, IPacket_17_HeartBeat packet);
		bool Process_Type_18_LockOn(IConnection connection, IPacket_18_LockOn packet);
		bool Process_Type_19_RemoveGround(IConnection connection, IPacket_19_RemoveGround packet);
		bool Process_Type_20_OrdinanceSpawn(IConnection connection, IPacket_20_OrdinanceSpawn packet);
		bool Process_Type_21_GroundData(IConnection connection, IPacket_21_GroundData packet);
		bool Process_Type_22_Damage(IConnection connection, IPacket_22_Damage packet);
		bool Process_Type_29_NetcodeVersion(IConnection connection, IPacket_29_NetcodeVersion packet);
		bool Process_Type_30_AircraftCommand(IConnection connection, IPacket_30_AircraftCommand packet);
		bool Process_Type_31_MissileOption(IConnection connection, IPacket_31_MissilesOption packet);
		bool Process_Type_32_ChatMessage(IConnection connection, IPacket_32_ChatMessage packet);
		bool Process_Type_33_Weather(IConnection connection, IPacket_33_Weather packet);
		bool Process_Type_35_ReviveAllGrounds(IConnection connection, IPacket_35_ReviveAllGrounds packet);
		bool Process_Type_36_WeaponLoadout(IConnection connection, IPacket_36_WeaponLoadout packet);
		bool Process_Type_37_ListUser(IConnection connection, IPacket_37_ListUser packet);
		bool Process_Type_38_QueryAirstate(IConnection connection, IPacket_38_QueryAirstate packet);
		bool Process_Type_39_WeaponsOption(IConnection connection, IPacket_39_WeaponsOption packet);
		bool Process_Type_41_UsernameDistance(IConnection connection, IPacket_41_UsernameDistance packet);
		bool Process_Type_43_ServerCommand(IConnection connection, IPacket_43_ServerCommand packet);
		bool Process_Type_44_AircraftList(IConnection connection, IPacket_44_AircraftList packet);
		bool Process_Type_45_GroundCommand(IConnection connection, IPacket_45_GroundCommand packet);
		bool Process_Type_47_ForceJoin(IConnection connection, IPacket_47_ForceJoin packet);
		bool Process_Type_48_FogColor(IConnection connection, IPacket_48_FogColor packet);
		bool Process_Type_49_SkyColor(IConnection connection, IPacket_49_SkyColor packet);
		bool Process_Type_50_GroundColor(IConnection connection, IPacket_50_GroundColor packet);
	}
}
