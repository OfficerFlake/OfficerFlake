using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static  partial class ObjectFactory
	{
		//CORE
		#region 0_Interfaces
		//No objects to create in interfaces!
		#endregion
		#region 1_Logger
		//ObjectFactory has direct access.
		#endregion
		#region 2_ExceptionHandling
		//ObjectFactory has direct access.
		#endregion
		#region 3_ObjectFactory
		//ObjectFactory can't create self!
		#endregion

		//UNITS
		#region Color
		public static  ISimpleColor GetSimpleColor(char colorCode) => throw new NotImplementedException();
		public static  I24BitColor CreateColor(int red, int green, int blue) => throw new NotImplementedException();
		public static  I32BitColor CreateColor(int alpha, int red, int green, int blue) => throw new NotImplementedException();
		#endregion
		#region Database
		//Group
		public static IGroup CreateGroup(IRichTextString groupName) => throw new NotImplementedException();
		public static IGroup GetGroupNone => throw new NotImplementedException();

		//Permissions
		public static IPermissions CreatePermissions() => throw new NotImplementedException();

		//Rank
		public static  IRank CreateRank(IRichTextString rankName) => throw new NotImplementedException();
		public static IRank GetRankNone => throw new NotImplementedException();

		//User
		public static  IUser CreateUser(IRichTextString userName) => throw new NotImplementedException();
		public static IUser GetUserConsole => throw new NotImplementedException();
		public static IUser GetUserNone => throw new NotImplementedException();
		#endregion
		#region Files
		public static IFile CreateFileReference(string filename) => throw new NotImplementedException();
		#endregion
		#region Math
		//Coordinates
		public static ICoordinate2 CreateCoordinate2(double x, double y) => throw new NotImplementedException();
		public static ICoordinate3 CreateCoordinate3(double x, double y, double z) => throw new NotImplementedException();

		public static IPoint2 CreatePoint2(IDistance x, IDistance y) => throw new NotImplementedException();
		public static IPoint3 CreatePoint3(IDistance x, IDistance y, IDistance z) => throw new NotImplementedException();
		public static IVector2 CreateVector2(IDistance x, IDistance y) => throw new NotImplementedException();
		public static IVector3 CreateVector3(IDistance x, IDistance y, IDistance z) => throw new NotImplementedException();

		public static IOrientation2 CreateOrientation2(IAngle h, IAngle p) => throw new NotImplementedException();
		public static IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b) => throw new NotImplementedException();

		//Quadratics
		public static IQuadraticEquation CreateQuadraticEquation(double y, double x, double a, double b, double c) => throw new NotImplementedException();
		public static IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3) => throw new NotImplementedException();

		//Statistics
		public static IStatistic CreateStatsticTracker() => throw new NotImplementedException();
		#endregion
		#region Networking
		//Connection
		public static IConnection CreateConnection() => throw new NotImplementedException();

		//Packets
		public static IPacket CreateGenericPacket() => throw new NotImplementedException();
		public static IPacket_01_Login CreatePacket01Login() => throw new NotImplementedException();
		public static IPacket_03_Error CreatePacket03Error() => throw new NotImplementedException();
		public static IPacket_04_Field CreatePacket04Field() => throw new NotImplementedException();
		public static IPacket_05_AddVehicle CreatePacket05AddVehicle() => throw new NotImplementedException();
		public static IPacket_06_Acknowledgement CreatePacket06Acknowledgement() => throw new NotImplementedException();
		public static IPacket_07_SmokeColor CreatePacket07SmokeColor() => throw new NotImplementedException();
		public static IPacket_08_JoinRequest CreatePacket08JoinRequest() => throw new NotImplementedException();
		public static IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved() => throw new NotImplementedException();
		public static IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied() => throw new NotImplementedException();
		public static IPacket_11_FlightData CreatePacket11FlightData() => throw new NotImplementedException();
		public static IPacket_12_LeaveFlight CreatePacket12LeaveFlight() => throw new NotImplementedException();
		public static IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft() => throw new NotImplementedException();
		public static IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation() => throw new NotImplementedException();
		public static IPacket_17_HeartBeat CreatePacket17HeartBeat() => throw new NotImplementedException();
		public static IPacket_18_LockOn CreatePacket18LockOn() => throw new NotImplementedException();
		public static IPacket_19_RemoveGround CreatePacket19RemoveGround() => throw new NotImplementedException();
		public static IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn() => throw new NotImplementedException();
		public static IPacket_21_GroundData CreatePacket21GroundData() => throw new NotImplementedException();
		public static IPacket_22_Damage CreatePacket22Damage() => throw new NotImplementedException();
		public static IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion() => throw new NotImplementedException();
		public static IPacket_30_AircraftCommand CreatePacket30AircraftCommand() => throw new NotImplementedException();
		public static IPacket_31_MissilesOption CreatePacket31MissilesOption() => throw new NotImplementedException();
		public static IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message) => throw new NotImplementedException();
		public static IPacket_32_ServerMessage CreatePacket32ServerMessage(string message) => throw new NotImplementedException();
		public static IPacket_33_Weather CreatePacket33Weather() => throw new NotImplementedException();
		public static IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds() => throw new NotImplementedException();
		public static IPacket_36_WeaponLoadout CreatePacket36WeaponLoadout() => throw new NotImplementedException();
		public static IPacket_37_ListUser CreatePacket37ListUser() => throw new NotImplementedException();
		public static IPacket_38_QueryAirstate CreatePacket38QueryAirstate() => throw new NotImplementedException();
		public static IPacket_39_WeaponsOption CreatePacket39WeaponsOption() => throw new NotImplementedException();
		public static IPacket_41_UsernameDistance CreatePacket41UsernameDistance() => throw new NotImplementedException();
		public static IPacket_43_ServerCommand CreatePacket43ServerCommand() => throw new NotImplementedException();
		public static IPacket_44_AircraftList CreatePacket44AircraftList() => throw new NotImplementedException();
		public static IPacket_45_GroundCommand CreatePacket45GroundCommand() => throw new NotImplementedException();
		public static IPacket_47_ForceJoin CreatePacket47ForceJoin() => throw new NotImplementedException();
		public static IPacket_48_FogColor CreatePacket48FogColor() => throw new NotImplementedException();
		public static IPacket_49_SkyColor CreatePacket49SkyColor() => throw new NotImplementedException();
		public static IPacket_50_GroundColor CreatePacket50GroundColor() => throw new NotImplementedException();

		//PacketProcessor
		public static IPacketProcessor CreatePacketProcessor() => throw new NotImplementedException();

		//Server
		public static IServer CreateServer() => throw new NotImplementedException();
		#endregion
		#region RichText
		public static IRichTextString CreateRichTextString(string formattedString) => throw new NotImplementedException();
		public static IRichTextMessage CreateRichTextMessage(IRichTextString richTextString) => throw new NotImplementedException();
		#endregion
		#region Settings
		public static ISettingsFile CreateSettingsFileReference(string filename) => throw new NotImplementedException();
		public static ISettingsHandler GetSettingsHandler() => throw new NotImplementedException();
		#endregion
		#region UnitsOfMeasurement
		//Angle
		//Area
		//Distance
		//Duration
		public static IDate CreateDate(System.DateTime dateTime) => throw new NotImplementedException();
		public static ITime CreateTime(System.DateTime dateTime) => throw new NotImplementedException();
		public static IDateTime CreateDateTime(System.DateTime dateTime) => throw new NotImplementedException();
		public static ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan) => throw new NotImplementedException();
		//Energy
		//Mass
		//Power
		//Pressure
		//Speed
		//Temperature
		//Volume
		#endregion
		#region YSFlight
		public static IDATFile CreateDATFileReference(string filename) => throw new NotImplementedException();
		public static ILSTFile CreateLSTFileReference(string filename) => throw new NotImplementedException();
		#endregion
	}
}
