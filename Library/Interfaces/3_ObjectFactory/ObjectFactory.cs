using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IObjectFactory
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
		ISimpleColor GetSimpleColor(char colorCode);
		I24BitColor CreateColor(int red, int green, int blue);
		I32BitColor CreateColor(int alpha, int red, int green, int blue);

		//Formatting

		#endregion
		#region Database
		//Group
		IGroup CreateGroup(IRichTextString groupName);
		IUser GetGroupNone { get; }

		//Permission
		IPermissions CreatePermissions();

		//Rank
		IRank CreateRank(IRichTextString rankName);
		IUser GetRankNone { get; }

		//User
		IUser CreateUser(IRichTextString userName);
		IUser GetUserConsole { get; }
		IUser GetUserNone { get; }
		#endregion
		#region Files
		IFile CreateFileReference(string filename);
		#endregion
		#region Math
		//Coordinates
		ICoordinate2 CreateCoordinate2(double x, double y);
		ICoordinate3 CreateCoordinate3(double x, double y, double z);

		IPoint2 CreatePoint2(IDistance x, IDistance y);
		IPoint3 CreatePoint3(IDistance x, IDistance y, IDistance z);
		IVector2 CreateVector2(IDistance x, IDistance y);
		IVector3 CreateVector3(IDistance x, IDistance y, IDistance z);

		IOrientation2 CreateOrientation2(IAngle h, IAngle p);
		IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b);

		//Quadratic
		IQuadraticEquation CreateQuadraticEquation(double y, double x, double a, double b, double c);
		IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3);

		//Statastic
		IStatistic CreateStatsticTracker();
		#endregion
		#region Networking
		//Connection
		IConnection CreateConnection();

		//Packets
		IPacket CreateGenericPacket();
		IPacket_01_Login CreatePacket01Login();
		IPacket_03_Error CreatePacket03Error();
		IPacket_04_Field CreatePacket04Field();
		IPacket_05_AddVehicle CreatePacket05AddVehicle();
		IPacket_06_Acknowledgement CreatePacket06Acknowledgement();
		IPacket_07_SmokeColor CreatePacket07SmokeColor();
		IPacket_08_JoinRequest CreatePacket08JoinRequest();
		IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved();
		IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied();
		IPacket_11_FlightData CreatePacket11FlightData();
		IPacket_12_LeaveFlight CreatePacket12LeaveFlight();
		IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft();
		IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation();
		IPacket_17_HeartBeat CreatePacket17HeartBeat();
		IPacket_18_LockOn CreatePacket18LockOn();
		IPacket_19_RemoveGround CreatePacket19RemoveGround();
		IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn();
		IPacket_21_GroundData CreatePacket21GroundData();
		IPacket_22_Damage CreatePacket22Damage();
		IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion();
		IPacket_30_AircraftCommand CreatePacket30AircraftCommand();
		IPacket_31_MissilesOption CreatePacket31MissilesOption();
		IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message);
		IPacket_32_ServerMessage CreatePacket32ServerMessage(string message);
		IPacket_33_Weather CreatePacket33Weather();
		IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds();
		IPacket_36_WeaponLoadout CreatePacket36WeaponLoadout();
		IPacket_37_ListUser CreatePacket37ListUser();
		IPacket_38_QueryAirstate CreatePacket38QueryAirstate();
		IPacket_39_WeaponsOption CreatePacket39WeaponsOption();
		IPacket_41_UsernameDistance CreatePacket41UsernameDistance();
		IPacket_43_ServerCommand CreatePacket43ServerCommand();
		IPacket_44_AircraftList CreatePacket44AircraftList();
		IPacket_45_GroundCommand CreatePacket45GroundCommand();
		IPacket_47_ForceJoin CreatePacket47ForceJoin();
		IPacket_48_FogColor CreatePacket48FogColor();
		IPacket_49_SkyColor CreatePacket49SkyColor();
		IPacket_50_GroundColor CreatePacket50GroundColor();

		//PacketProcessor
		IPacketProcessor CreatePacketProcessor();

		//Server
		IServer CreateServer();
		#endregion
		#region RichText
		IRichTextString CreateRichTextString(string formattedString);
		IRichTextMessage CreateRichTextMessage(IRichTextString richTextString);
		#endregion
		#region Settings
		ISettingsFile CreateSettingsFileReference(string filename);
		ISettingsHandler GetSettingsHandler();
		#endregion
		#region UnitsOfMeasurement
		//Angle
		//Area
		//Distance
		//Duration
		IDate CreateDate(System.DateTime dateTime);
		ITime CreateTime(System.DateTime dateTime);
		IDateTime CreateDateTime(System.DateTime dateTime);
		ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan);
		//Energy
		//Mass
		//Power
		//Pressure
		//Speed
		//Temperature
		//Volume
		#endregion
		#region YSFlight
		IDATFile CreateDATFileReference(string filename);
		ILSTFile CreateLSTFileReference(string filename);
		#endregion
	}
}
