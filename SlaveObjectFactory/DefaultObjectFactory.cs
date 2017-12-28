using System;
using System.Collections.Generic;

using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		private class DefaultObjectFactory : IObjectFactory
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
			#region Colors
			//Colors
			public ISimpleColor CreateSimpleColor(IColor color, char colorCode) => throw new NotImplementedException();
			public IColor CreateColor(int red, int green, int blue) => throw new NotImplementedException();
			public IColor CreateColor(int alpha, int red, int green, int blue) => throw new NotImplementedException();

			//Formatting

			#endregion
			#region Database
			//Group
			public IGroup CreateGroup(IRichTextString groupName) => throw new NotImplementedException();
			//Permission
			public IPermissions CreatePermissions() => throw new NotImplementedException();
			//Rank
			public IRank CreateRank(IRichTextString rankName) => throw new NotImplementedException();
			//User
			public IUser CreateUser(IRichTextString userName) => throw new NotImplementedException();
			#endregion
			#region Files
			public IFile CreateFileReference(string filename) => throw new NotImplementedException();
			#endregion
			#region Math
			//Coordinates
			public ICoordinate2 CreateCoordinate2(double x, double y) => throw new NotImplementedException();
			public ICoordinate3 CreateCoordinate3(double x, double y, double z) => throw new NotImplementedException();

			public IPoint2 CreatePoint2(IDistance x, IDistance y) => throw new NotImplementedException();
			public IPoint3 CreatePoint3(IDistance x, IDistance y, IDistance z) => throw new NotImplementedException();
			public IVector2 CreateVector2(IDistance x, IDistance y) => throw new NotImplementedException();
			public IVector3 CreateVector3(IDistance x, IDistance y, IDistance z) => throw new NotImplementedException();

			public IOrientation2 CreateOrientation2(IAngle h, IAngle p) => throw new NotImplementedException();
			public IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b) => throw new NotImplementedException();

			//Quadratic
			public IQuadraticEquation CreateQuadraticEquation(double y, double x, double a, double b, double c) => throw new NotImplementedException();
			public IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3) => throw new NotImplementedException();

			//Statastic
			public IStatistic CreateStatsticTracker() => throw new NotImplementedException();
			#endregion
			#region Networking
			//Connection
			public IConnection CreateConnection() => throw new NotImplementedException();

			//Packets
			public IPacket CreateGenericPacket() => throw new NotImplementedException();
			public IPacket_01_Login CreatePacket01Login() => throw new NotImplementedException();
			public IPacket_03_Error CreatePacket03Error() => throw new NotImplementedException();
			public IPacket_04_Field CreatePacket04Field() => throw new NotImplementedException();
			public IPacket_05_AddVehicle CreatePacket05AddVehicle() => throw new NotImplementedException();
			public IPacket_06_Acknowledgement CreatePacket06Acknowledgement() => throw new NotImplementedException();
			public IPacket_07_SmokeColor CreatePacket07SmokeColor() => throw new NotImplementedException();
			public IPacket_08_JoinRequest CreatePacket08JoinRequest() => throw new NotImplementedException();
			public IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved() => throw new NotImplementedException();
			public IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied() => throw new NotImplementedException();
			public IPacket_11_FlightData CreatePacket11FlightData() => throw new NotImplementedException();
			public IPacket_12_LeaveFlight CreatePacket12LeaveFlight() => throw new NotImplementedException();
			public IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft() => throw new NotImplementedException();
			public IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation() => throw new NotImplementedException();
			public IPacket_17_HeartBeat CreatePacket17HeartBeat() => throw new NotImplementedException();
			public IPacket_18_LockOn CreatePacket18LockOn() => throw new NotImplementedException();
			public IPacket_19_RemoveGround CreatePacket19RemoveGround() => throw new NotImplementedException();
			public IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn() => throw new NotImplementedException();
			public IPacket_21_GroundData CreatePacket21GroundData() => throw new NotImplementedException();
			public IPacket_22_Damage CreatePacket22Damage() => throw new NotImplementedException();
			public IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion() => throw new NotImplementedException();
			public IPacket_30_AircraftCommand CreatePacket30AircraftCommand() => throw new NotImplementedException();
			public IPacket_31_MissilesOption CreatePacket31MissilesOption() => throw new NotImplementedException();
			public IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message) => throw new NotImplementedException();
			public IPacket_32_ServerMessage CreatePacket32ServerMessage(string message) => throw new NotImplementedException();
			public IPacket_33_Weather CreatePacket33Weather() => throw new NotImplementedException();
			public IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds() => throw new NotImplementedException();
			public IPacket_36_WeaponLoadout CreatePacket36WeaponLoadout() => throw new NotImplementedException();
			public IPacket_37_ListUser CreatePacket37ListUser() => throw new NotImplementedException();
			public IPacket_38_QueryAirstate CreatePacket38QueryAirstate() => throw new NotImplementedException();
			public IPacket_39_WeaponsOption CreatePacket39WeaponsOption() => throw new NotImplementedException();
			public IPacket_41_UsernameDistance CreatePacket41UsernameDistance() => throw new NotImplementedException();
			public IPacket_43_ServerCommand CreatePacket43ServerCommand() => throw new NotImplementedException();
			public IPacket_44_AircraftList CreatePacket44AircraftList() => throw new NotImplementedException();
			public IPacket_45_GroundCommand CreatePacket45GroundCommand() => throw new NotImplementedException();
			public IPacket_47_ForceJoin CreatePacket47ForceJoin() => throw new NotImplementedException();
			public IPacket_48_FogColor CreatePacket48FogColor() => throw new NotImplementedException();
			public IPacket_49_SkyColor CreatePacket49SkyColor() => throw new NotImplementedException();
			public IPacket_50_GroundColor CreatePacket50GroundColor() => throw new NotImplementedException();

			//PacketProcessor
			public IPacketProcessor CreatePacketProcessor() => throw new NotImplementedException();

			//Server
			public Boolean ServerStart() => throw new NotImplementedException();
			public Boolean ServerEnd() => throw new NotImplementedException();
			#endregion
			#region RichText
			public IRichTextString CreateRichTextString(string formattedString) => throw new NotImplementedException();
			public IRichTextMessage CreateRichTextMessage(IRichTextString richTextString) => throw new NotImplementedException();
			#endregion
			#region Settings
			public ISettingsFile CreateSettingsFileReference(string filename) => throw new NotImplementedException();
			public ISettingsHandler GetSettingsHandler() => throw new NotImplementedException();
			#endregion
			#region UnitsOfMeasurement
			//Angle
			//Area
			//Distance
			//Duration
			public IDate CreateDate(System.DateTime dateTime) => throw new NotImplementedException();
			public ITime CreateTime(System.DateTime dateTime) => throw new NotImplementedException();
			public IDateTime CreateDateTime(System.DateTime dateTime) => throw new NotImplementedException();
			public ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan) => throw new NotImplementedException();
			//Energy
			//Mass
			//Power
			//Pressure
			//Speed
			//Temperature
			//Volume
			#endregion
			#region YSFlight
			public IDATFile CreateDATFileReference(string filename) => throw new NotImplementedException();
			public ILSTFile CreateLSTFileReference(string filename) => throw new NotImplementedException();
			#endregion
		}
	}
}
