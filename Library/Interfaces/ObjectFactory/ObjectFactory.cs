using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IObjectFactory
	{
		//Create Objects
		#region Colors
		//Colors
		IColor CreateColor(char colorCode);

		IColor CreateColor(int red, int green, int blue);
		IColor CreateColor(int alpha, int red, int green, int blue);

		//Formatting

		#endregion
		#region Database
		//Group
		IGroup CreateGroup(IRichTextString groupName);
		//Permission
		IPermission CreatePermission(int minRank, int maxRank, bool MustOutrank);
		ILocalPermissions CreateLocalPermissions();
		IGlobalPermissions CreateGlobalPermissions();
		ILocalPermissionsTester CreateLocalPermissionsTester(IHasPermissions Owner);
		IGlobalPermissionsTester CreateGlobalPermissionsTester(IHasPermissions Owner);
		//Rank
		IRank CreateRank(IRichTextString rankName);
		//User
		IUser CreateUser(IRichTextString userName);
		IUserHistory CreateUserHistory();
		IExpiringAction CreateExpiringAction(IUser actionedBy, IDateTime start, IDateTime ends, IRichTextString reason);
		IPermanentAction CreatePermanentAction(IUser actionedBy, IDateTime actioneDateTime, IRichTextString reason);
		IUserGroupUpdate CreateUserGroupUpdate(IGroup group, IRank rank, IUser actionedBy, IDateTime actioneDateTime, GroupUpdateType updateType, IRichTextString reason);
		#endregion
		#region ExceptionHandling
		IExceptionHandler CreateExceptionHandler();
		#endregion
		#region Files
		IFile CreateFileReference(string filename);
		ICommandFile CreateCommandFileReference(string filename);
		ICommandFileLine CreateCommandFileLine(string contents);
		IListFile CreateListFileReference(string filename);
		IListFileLine CreateListFileLine(string contents);
		#endregion
		#region Logging
		//No Objects To Create.
		#endregion
		#region Math
		//Coordinates
		IDimensionX<T> CreateDimensionX<T>(T type);
		IDimensionY<T> CreateDimensionY<T>(T type);
		IDimensionZ<T> CreateDimensionZ<T>(T type);
		IDimensionH CreateDimensionH(IAngle type);
		IDimensionP CreateDimensionP(IAngle type);
		IDimensionB CreateDimensionB(IAngle type);

		IPoint2 CreatePoint2(IDimensionX<IDistance> x, IDimensionY<IDistance> y);
		IPoint3 CreatePoint3(IDimensionX<IDistance> x, IDimensionY<IDistance> y, IDimensionZ<IDistance> z);
		IVector2 CreateVector2(IDimensionX<IDistance> x, IDimensionY<IDistance> y);
		IVector3 CreateVector3(IDimensionX<IDistance> x, IDimensionY<IDistance> y, IDimensionZ<IDistance> z);
		ICoordinate2 CreateCoordinate2(IDimensionX<double> x, IDimensionY<double> y);
		ICoordinate3 CreateCoordinate3(IDimensionX<double> x, IDimensionY<double> y, IDimensionZ<double> z);
		IOrientation2 CreateOrientation2(IDimensionH h, IDimensionP p);
		IOrientation3 CreateOrientation3(IDimensionH h, IDimensionP p, IDimensionB b);

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
		IPacket_04_Field CreatepPacket04Field();
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
		IPacket_20_OrdinanceSpawn CreattePacket20OrdinanceSpawn();
		IPacket_21_GroundData CreatePacket21GroundData();
		IPacket_22_Damage CreatePacket22Damage();
		IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion();
		IPacket_30_AircraftCommand CreatePacket30AircraftCommand();
		IPacket_31_MissilesOption CretatePacket31MissilesOption();
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
		IPacket_48_FogColor CreatPacket48FogColor();
		IPacket_49_SkyColor CreatePacket49SkyColor();
		IPacket_50_GroundColor CreatePacket50GroundColor();
		//PacketProcessor
		IPacketProcessor CreatePacketProcessor();
		//Server
		IServer CreateServer();
		#endregion
		#region ObjectFactory
		//Can't create self!
		#endregion
		#region RichText
		IRichTextElement CreateRichTextElement();
		IRichTextString CreateRichTextString(string formattedString);
		IRichTextMessage CreateRichTextMessage(IRichTextString richTextString);
		#endregion
		#region Settings
		ISettingsFile CreateSettingsFileReference(string filename);
		ISettingsHandler CreateSettingsHandler();
		#endregion
		#region UnitsOfMeasurement
		//Reference This Directly!
		#endregion
		#region YSFlight
		IDATFile CreateDATFileReference(string filename);
		IDATFileProperty CreateDATFileProperty(string contents);
		#endregion
	}
}
