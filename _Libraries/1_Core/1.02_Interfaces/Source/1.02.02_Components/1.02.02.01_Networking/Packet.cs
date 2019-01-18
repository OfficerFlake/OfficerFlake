using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IPacket
	{
		UInt32 Size { get; }
		UInt32 Type { get; set; }
		byte[] Data { get; set; }

		#region Data Manipulation
		byte[] GetBytesFromStartToEnd(int start, int end);
		byte[] GetBytesFromStartToLength(int start, int length);

		void ResizeData(int newsize);
		bool SetBytesFromStart(int start, byte[] bytesToCopy);
		#endregion

		#region DataTypes
		#region Bool
		bool GetBit(int start, int index);
		bool SetBit(int start, int index);
		bool UnsetBit(int start, int index);

		bool SetBit(int start, int index, bool value);
		#endregion

		#region Byte
		byte GetByte(int start);
		bool SetByte(int start, byte input);
		#endregion
		#region SByte
		sbyte GetSByte(int start);
		bool SetSByte(int start, sbyte input);
		#endregion

		#region Uint16
		UInt16 GetUInt16(int start);
		bool SetUInt16(int start, UInt16 input);
		#endregion
		#region Int16
		Int16 GetInt16(int start);
		bool SetInt16(int start, Int16 input);
		#endregion

		#region UInt32
		UInt32 GetUInt32(int start);
		bool SetUInt32(int start, UInt32 input);
		#endregion
		#region Int32
		Int32 GetInt32(int start);
		bool SetInt32(int start, Int32 input);
		#endregion

		#region Single
		Single GetSingle(int start);
		bool SetSingle(int start, Single input);
		#endregion

		#region String
		string GetString(int start, int length);
		bool SetString(int start, int length, string input);
		#endregion
		#endregion

		byte[] Serialise();
	}
	public interface IPacket_00_Null : IPacket
	{
	}
	public interface IPacket_01_Login : IPacket
	{
		String Username { get; }
		UInt32 Version { get; }
	}
	public interface IPacket_02_Logoff : IPacket
	{
	}
	public interface IPacket_03_Error : IPacket
	{
		UInt32 ErrorCode { get; }
	}
	public interface IPacket_04_Field : IPacket
	{
		String FieldName { get; set; }
		IDistance PosX { get; set; }
		IDistance PosY { get; set; }
		IDistance PosZ { get; set; }
		IAngle RotX { get; set; }
		IAngle RotY { get; set; }
		IAngle RotZ { get; set; }
		UInt32 Version { get; set; }
	}
	public interface IPacket_05_AddVehicle : IPacket
	{
		Packet_05VehicleType VehicleType { get; set; }
		UInt16 Version { get; set; }
		UInt32 ID { get; set; }
		UInt32 IFF { get; set; }
		IDistance PosX { get; set; }
		IDistance PosY { get; set; }
		IDistance PosZ { get; set; }
		ICoordinate3 Position { get;}
		IAngle HdgH { get; set; }
		IAngle HdgP { get; set; }
		IAngle HdgB { get; set; }
		IOrientation3 Attitude { get;}
		String Identify { get; set; }
		Packet_05OwnerType OwnerType { get; set; }
		String OwnerName { get; set; }
	}
	public enum Packet_05VehicleType
	{
		Aircraft,
		Ground
	}
	public enum Packet_05OwnerType
	{
		Self,
		Other
	}
	public interface IPacket_06_Acknowledgement : IPacket
	{
		UInt32[] Arguments { get; set; }
	}
	public interface IPacket_07_SmokeColor : IPacket
	{
		UInt32 VehicleID { get; set; }
		Byte SmokeGeneratorID { get; set; }
		I24BitColor Color { get; set; }
	}
	public interface IPacket_08_JoinRequest : IPacket
	{
		UInt32 IFF { get; set; }
		String AircraftIdentify { get; set; }
		String StartPositionIdentify { get; set; }
		Single FuelPercent { get; set; }
	}
	public interface IPacket_09_JoinRequestApproved : IPacket
	{
	}
	public interface IPacket_10_JoinRequestDenied : IPacket
	{
	}
	public interface IPacket_11_FlightData : IPacket
	{
		ITimeSpan Timestamp { get; set; }
		UInt32 ID { get; set; }
		UInt16 Version { get; set; }
		IDistance PosX { get; set; }
		IDistance PosY { get; set; }
		IDistance PosZ { get; set; }
		IAngle HdgH { get; set; }
		IAngle HdgP { get; set; }
		IAngle HdgB { get; set; }
		ISpeed V_PosX { get; set; }
		ISpeed V_PosY { get; set; }
		ISpeed V_PosZ { get; set; }
		IAngle V_HdgH { get; set; }
		IAngle V_HdgP { get; set; }
		IAngle V_HdgB { get; set; }
		Single LoadFactor { get; set; }
		UInt16 AmmoGUN { get; set; }
		UInt16 AmmoAAM { get; set; }
		UInt16 AmmoAGM { get; set; }
		UInt16 AmmoB500 { get; set; }
		IMass WeightSmokeOil { get; set; }
		IMass WeightFuel { get; set; }
		IMass WeightClean { get; set; }
		UInt16 Strength { get; set; }
		Byte FlightState { get; set; }
		Single AnimVGW { get; set; }
		Single AnimBoards { get; set; }
		Single AnimGear { get; set; }
		Single AnimFlaps { get; set; }
		Single AnimBrake { get; set; }
		Byte AnimFlags { get; set; }
		Boolean AnimLightLand { get; set; }
		Boolean AnimLightStrobe { get; set; }
		Boolean AnimLightNav { get; set; }
		Boolean AnimLightBeacon { get; set; }
		Boolean AnimGuns { get; set; }
		Boolean AnimContrails { get; set; }
		Boolean AnimSmoke { get; set; }
		Boolean AnimBurners { get; set; }
		Byte CPUFlags { get; set; }
		Single AnimThrottle { get; set; }
		Single AnimElevator { get; set; }
		Single AnimAileron { get; set; }
		Single AnimRudder { get; set; }
		Single AnimTrim { get; set; }
		UInt16 AmmoRKT { get; set; }
		Single AnimThrustVector { get; set; }
		Single AnimThrustReverse { get; set; }
		Single AnimBombBay { get; set; }
		IPacket_64_11_FormationFlightData ConvertTo_IPacket_64_11_FormationFlightData(IWorldVehicle FormationTarget);
	}
	public interface IPacket_12_LeaveFlight : IPacket
	{
		UInt32 ID { get; set; }
	}
	public interface IPacket_13_RemoveAircraft : IPacket
	{
		UInt32 ID { get; set; }
	}
	public interface IPacket_14_RequestTestAirplane : IPacket
	{
	}
	public interface IPacket_15_KillServer : IPacket
	{
	}
	public interface IPacket_16_PrepareSimulation : IPacket
	{
	}
	public interface IPacket_17_HeartBeat : IPacket
	{
	}
	public interface IPacket_18_LockOn : IPacket
	{
		UInt32 LockedOnByID { get; set; }
		UInt32 LockedOnByType { get; set; }
		UInt32 LockedOnToID { get; set; }
		UInt32 LockedOnToType { get; set; }
	}
	public interface IPacket_19_RemoveGround : IPacket
	{
		UInt32 ID { get; set; }
	}
	public interface IPacket_20_OrdinanceSpawn : IPacket
	{
		Packet_OrdinanceType OrdinanceType { get; set; }
		IDistance PosX { get; set; }
		IDistance PosY { get; set; }
		IDistance PosZ { get; set; }
		IAngle HdgX { get; set; }
		IAngle HdgY { get; set; }
		IAngle HdgZ { get; set; }
		ISpeed LaunchVelocity { get; set; }
		IDistance BurnoutDistance { get; set; }
		UInt32 MaximumDamage { get; set; }
		UInt16 SenderType { get; set; }
		UInt32 SenderID { get; set; }
		ISpeed MaximumVelocity { get; set; }
	}
	public enum Packet_OrdinanceType
	{
		 Null = 0,
		 AAM_Short = 1,
		 AGM = 2,
		 B500 = 3,
		 RKT = 4,
		 FLR = 5,
		 AAM_Mid = 6,
		 B250 = 7,
		 Unknown_8 = 8,
		 B500_HD = 9,
		 AAM_X = 10,
		 Unknown_11 = 11,
		 FuelTank = 12,
	}
	public interface IPacket_21_GroundData : IPacket
	{
		ITimeSpan Timestamp { get; set; }
		UInt32 ID { get; set; }
		UInt16 Strength { get; set; }
		UInt16 Version { get; set; }
		IDistance PosX { get; set; }
		IDistance PosY { get; set; }
		IDistance PosZ { get; set; }
		IAngle HdgX { get; set; }
		IAngle HdgY { get; set; }
		IAngle HdgZ { get; set; }
		Byte AnimFlags { get; set; }
		Boolean AnimGuns { get; set; }
		Byte CPUFlags { get; set; }
		ISpeed V_PosX { get; set; }
		ISpeed V_PosY { get; set; }
		ISpeed V_PosZ { get; set; }
		IAngle V_Rotation { get; set; }
	}
	public interface IPacket_22_Damage : IPacket
	{
		UInt32 VictimType { get; set; }
		UInt32 VictimID { get; set; }
		UInt32 AttackerType { get; set; }
		UInt16 Damage { get; set; }
		Packet_OrdinanceType OrdinanceType { get; set; }
		UInt32 Unknown { get; set; }
	}
	public interface IPacket_23_GroundTurretState : IPacket
	{
	}
	public interface IPacket_24_SetTestAutoPilot : IPacket
	{
	}
	public interface IPacket_25_RequestToBeSideWindowOfServer : IPacket
	{
	}
	public interface IPacket_26_AssignSideWindow : IPacket
	{
	}
	public interface IPacket_27_ResendAirRequest : IPacket
	{
	}
	public interface IPacket_28_ResendGroundRequest : IPacket
	{
	}
	public interface IPacket_29_NetcodeVersion : IPacket
	{
		UInt32 Version { get; set; }
	}
	public interface IPacket_30_AircraftCommand : IPacket
	{
		UInt32 ID { get; set; }
		String Command { get; set; }
		String Parameters { get; set; }
	}
	public interface IPacket_31_MissilesOption : IPacket
	{
		Boolean Enabled { get; set; }
	}
	public interface IPacket_32_ChatMessage : IPacket
	{
		String Message { get; set; }
		IUser User { get; set; }
	}
	public interface IPacket_32_ServerMessage : IPacket
	{
		String Message { get; set; }
	}
	public interface IPacket_33_Weather : IPacket
	{
		Packet_33WeatherLighting Lighting { get; set; }
		Byte Options { get; set; }
		Boolean ForceObeyLandEverywhere { get; set; }
		Boolean EnableLandEverywhere { get; set; }
		Boolean ForceObeyCollisions { get; set; }
		Boolean EnableCollisions { get; set; }
		Boolean ForceObeyBlackOut { get; set; }
		Boolean EnableBlackOut { get; set; }
		Boolean ForceObeyVisibility { get; set; }
		Boolean EnableVisibility { get; set; }
		ISpeed WindX { get; set; }
		ISpeed WindY { get; set; }
		ISpeed WindZ { get; set; }
		IDistance Visibility { get; set; }

	void Initialise();
	}
	public enum Packet_33WeatherLighting
	{
		Day,
		Night
	}
	public interface IPacket_34_NeedResendJoinApproval : IPacket
	{
	}
	public interface IPacket_35_ReviveAllGrounds : IPacket
	{
	}
	public interface IPacket_36_WeaponsLoadout : IPacket
	{
		UInt32 ID { get; set; }
		UInt16 Version { get; set; }
		List<IPacket_36_WeaponLoadingDescription> Weapons { get; set; }
	}
	public interface IPacket_36_WeaponLoadingDescription
	{
		Packet_OrdinanceType WeaponType { get; set; }
		UInt16 Ammo { get; set; }
	}
	public interface IPacket_37_ListUser : IPacket
	{
		Packet_37UserType UserType { get; set; }
		UInt16 IFF { get; set; }
		UInt32 ID { get; set; }
		String Identify { get; set; }
	}
	public enum Packet_37UserType
	{
		ClientIdle,
		ClientFlying,
		ServerIdle,
		ServerFlying,
	}
	public interface IPacket_38_QueryAirstate : IPacket
	{
		UInt32 AircraftCount { get; }
		UInt32[] AircraftIDs { get; set; }
	}
	public interface IPacket_39_WeaponsOption : IPacket
	{
		Boolean Enabled { get; set; }
	}
	public interface IPacket_40_AirTurretState : IPacket
	{
	}
	public interface IPacket_41_UsernameDistance : IPacket
	{
		IDistance Distance { get; set; }
		Boolean IsAlwaysVisible { get; }
		void SetAlwaysVisible();
		Boolean IsNeverVisible { get; }
		void SetNeverVisible();
	}
	public interface IPacket_42_ConfirmExistence : IPacket
	{
	}
	public interface IPacket_43_ServerCommand : IPacket
	{
		String Command { get; set; }
		String Parameters { get; set; }
	}
	public interface IPacket_44_AircraftList : IPacket
	{
		Byte Version { get; set; }
		Byte Count { get; set; }
		List<String> AircraftIdentities { get; set; }
	}
	public interface IPacket_45_GroundCommand : IPacket
	{
		UInt32 ID { get; set; }
		String Command { get; set; }
		String Parameters { get; set; }
	}
	public interface IPacket_46_ReportScore : IPacket
	{
	}
	public interface IPacket_47_ForceJoin : IPacket
	{
	}
	public interface IPacket_48_FogColor : IPacket
	{
		I24BitColor Color { get; set; }
	}
	public interface IPacket_49_SkyColor : IPacket
	{
		I24BitColor Color { get; set; }
	}
	public interface IPacket_50_GroundColor : IPacket
	{
		I24BitColor Color { get; set; }
	}
	public interface IPacket_64_UserPacket : IPacket
	{
		UInt32 UserPacketHeader { get; set; }
	}
	public interface IPacket_64_00_Null : IPacket_64_UserPacket
	{
	}
	public interface IPacket_64_01_OYSVersion : IPacket_64_UserPacket
	{
		UInt32 OYSVersion { get; set; }
	}
	public interface IPacket_64_11_FormationFlightData : IPacket_11_FlightData, IPacket_64_UserPacket
	{
		UInt32 FormationTargetID { get; set; }
		IPacket_11_FlightData ConvertTo_IPacket_11_FlightData();
	}
}
