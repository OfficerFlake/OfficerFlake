using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		#region Color
		public static IColor CreateColor(char colorCode)
		{
			throw new NotImplementedException();
		}
		public static IColor CreateColor(int red, int green, int blue)
		{
			throw new NotImplementedException();
		}
		public static IColor CreateColor(int alpha, int red, int green, int blue)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Database
		public static IGroup CreateGroup(IRichTextString groupName)
		{
			throw new NotImplementedException();
		}

		public static IRank CreateRank(IRichTextString rankName)
		{
			throw new NotImplementedException();
		}

		public static IUser CreateUser(IRichTextString userName)
		{
			throw new NotImplementedException();
		}
		public static IUserGroupUpdate CreateUserGroupUpdate(IGroup group, IRank rank, IUser actionedBy, IDateTime actioneDateTime, GroupUpdateType updateType, IRichTextString reason)
		{
			throw new NotImplementedException();
		}
		public static IUserHistory CreateUserHistory()
		{
			throw new NotImplementedException();
		}
		public static IExpiringAction CreateExpiringAction(IUser actionedBy, IDateTime start, IDateTime ends, IRichTextString reason)
		{
			throw new NotImplementedException();
		}
		public static IPermanentAction CreatePermanentAction(IUser actionedBy, IDateTime actioneDateTime, IRichTextString reason)
		{
			throw new NotImplementedException();
		}

		public static IPermission CreatePermission(int minRank, int maxRank, bool MustOutrank)
		{
			throw new NotImplementedException();
		}
		public static ILocalPermissions CreateLocalPermissions()
		{
			throw new NotImplementedException();
		}
		public static ILocalPermissionsTester CreateLocalPermissionsTester(IHasPermissions Owner)
		{
			throw new NotImplementedException();
		}
		public static IGlobalPermissions CreateGlobalPermissions()
		{
			throw new NotImplementedException();
		}
		public static IGlobalPermissionsTester CreateGlobalPermissionsTester(IHasPermissions Owner)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region ExceptionHandling
		public static IExceptionHandler CreateExceptionHandler()
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Files
		public static IFile CreateFileReference(string filename)
		{
			throw new NotImplementedException();
		}
		public static ICommandFileLine CreateCommandFileLine(string contents)
		{
			throw new NotImplementedException();
		}
		public static ICommandFile CreateCommandFileReference(string filename)
		{
			throw new NotImplementedException();
		}
		public static IListFileLine CreateListFileLine(string contents)
		{
			throw new NotImplementedException();
		}
		public static IListFile CreateListFileReference(string filename)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Logging
		#endregion
		#region Math
		public static IDimensionX<T> CreateDimensionX<T>(T type)
		{
			throw new NotImplementedException();
		}
		public static IDimensionY<T> CreateDimensionY<T>(T type)
		{
			throw new NotImplementedException();
		}
		public static IDimensionZ<T> CreateDimensionZ<T>(T type)
		{
			throw new NotImplementedException();
		}
		public static IDimensionH CreateDimensionH(IAngle type)
		{
			throw new NotImplementedException();
		}
		public static IDimensionP CreateDimensionP(IAngle type)
		{
			throw new NotImplementedException();
		}
		public static IDimensionB CreateDimensionB(IAngle type)
		{
			throw new NotImplementedException();
		}

		public static IPoint2 CreatePoint2(IDimensionX<IDistance> x, IDimensionY<IDistance> y)
		{
			throw new NotImplementedException();
		}
		public static IPoint3 CreatePoint3(IDimensionX<IDistance> x, IDimensionY<IDistance> y, IDimensionZ<IDistance> z)
		{
			throw new NotImplementedException();
		}
		public static IVector2 CreateVector2(IDimensionX<IDistance> x, IDimensionY<IDistance> y)
		{
			throw new NotImplementedException();
		}
		public static IVector3 CreateVector3(IDimensionX<IDistance> x, IDimensionY<IDistance> y, IDimensionZ<IDistance> z)
		{
			throw new NotImplementedException();
		}

		public static ICoordinate2 CreateCoordinate2(IDimensionX<double> x, IDimensionY<double> y)
		{
			throw new NotImplementedException();
		}
		public static ICoordinate3 CreateCoordinate3(IDimensionX<double> x, IDimensionY<double> y, IDimensionZ<double> z)
		{
			throw new NotImplementedException();
		}
		public static IOrientation2 CreateOrientation2(IDimensionH h, IDimensionP p)
		{
			throw new NotImplementedException();
		}
		public static IOrientation3 CreateOrientation3(IDimensionH h, IDimensionP p, IDimensionB b)
		{
			throw new NotImplementedException();
		}

		public static IQuadraticEquation CreateQuadraticEquation(double y, double x, double a, double b, double c)
		{
			throw new NotImplementedException();
		}
		public static IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3)
		{
			throw new NotImplementedException();
		}

		public static IStatistic CreateStatsticTracker()
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Networking
		public static IConnection CreateConnection()
		{
			throw new NotImplementedException();
		}

		public static IPacket CreateGenericPacket()
		{
			throw new NotImplementedException();
		}
		public static IPacket_01_Login CreatePacket01Login()
		{
			throw new NotImplementedException();
		}
		public static IPacket_03_Error CreatePacket03Error()
		{
			throw new NotImplementedException();
		}
		public static IPacket_04_Field CreatepPacket04Field()
		{
			throw new NotImplementedException();
		}
		public static IPacket_05_AddVehicle CreatePacket05AddVehicle()
		{
			throw new NotImplementedException();
		}
		public static IPacket_06_Acknowledgement CreatePacket06Acknowledgement()
		{
			throw new NotImplementedException();
		}
		public static IPacket_07_SmokeColor CreatePacket07SmokeColor()
		{
			throw new NotImplementedException();
		}
		public static IPacket_08_JoinRequest CreatePacket08JoinRequest()
		{
			throw new NotImplementedException();
		}
		public static IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved()
		{
			throw new NotImplementedException();
		}
		public static IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied()
		{
			throw new NotImplementedException();
		}
		public static IPacket_11_FlightData CreatePacket11FlightData()
		{
			throw new NotImplementedException();
		}
		public static IPacket_12_LeaveFlight CreatePacket12LeaveFlight()
		{
			throw new NotImplementedException();
		}
		public static IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft()
		{
			throw new NotImplementedException();
		}
		public static IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation()
		{
			throw new NotImplementedException();
		}
		public static IPacket_17_HeartBeat CreatePacket17HeartBeat()
		{
			throw new NotImplementedException();
		}
		public static IPacket_18_LockOn CreatePacket18LockOn()
		{
			throw new NotImplementedException();
		}
		public static IPacket_19_RemoveGround CreatePacket19RemoveGround()
		{
			throw new NotImplementedException();
		}
		public static IPacket_20_OrdinanceSpawn CreattePacket20OrdinanceSpawn()
		{
			throw new NotImplementedException();
		}
		public static IPacket_21_GroundData CreatePacket21GroundData()
		{
			throw new NotImplementedException();
		}
		public static IPacket_22_Damage CreatePacket22Damage()
		{
			throw new NotImplementedException();
		}
		public static IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion()
		{
			throw new NotImplementedException();
		}
		public static IPacket_30_AircraftCommand CreatePacket30AircraftCommand()
		{
			throw new NotImplementedException();
		}
		public static IPacket_31_MissilesOption CretatePacket31MissilesOption()
		{
			throw new NotImplementedException();
		}
		public static IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message)
		{
			throw new NotImplementedException();
		}
		public static IPacket_32_ServerMessage CreatePacket32ServerMessage(string message)
		{
			throw new NotImplementedException();
		}
		public static IPacket_33_Weather CreatePacket33Weather()
		{
			throw new NotImplementedException();
		}
		public static IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds()
		{
			throw new NotImplementedException();
		}
		public static IPacket_36_WeaponLoadout CreatePacket36WeaponLoadout()
		{
			throw new NotImplementedException();
		}
		public static IPacket_37_ListUser CreatePacket37ListUser()
		{
			throw new NotImplementedException();
		}
		public static IPacket_38_QueryAirstate CreatePacket38QueryAirstate()
		{
			throw new NotImplementedException();
		}
		public static IPacket_39_WeaponsOption CreatePacket39WeaponsOption()
		{
			throw new NotImplementedException();
		}
		public static IPacket_41_UsernameDistance CreatePacket41UsernameDistance()
		{
			throw new NotImplementedException();
		}
		public static IPacket_43_ServerCommand CreatePacket43ServerCommand()
		{
			throw new NotImplementedException();
		}
		public static IPacket_44_AircraftList CreatePacket44AircraftList()
		{
			throw new NotImplementedException();
		}
		public static IPacket_45_GroundCommand CreatePacket45GroundCommand()
		{
			throw new NotImplementedException();
		}
		public static IPacket_47_ForceJoin CreatePacket47ForceJoin()
		{
			throw new NotImplementedException();
		}
		public static IPacket_48_FogColor CreatPacket48FogColor()
		{
			throw new NotImplementedException();
		}
		public static IPacket_49_SkyColor CreatePacket49SkyColor()
		{
			throw new NotImplementedException();
		}
		public static IPacket_50_GroundColor CreatePacket50GroundColor()
		{
			throw new NotImplementedException();
		}

		public static IPacketProcessor CreatePacketProcessor()
		{
			throw new NotImplementedException();
		}

		public static IServer CreateServer()
		{
			throw new NotImplementedException();
		}
		#endregion
		#region ObjectFactory
		#endregion
		#region RichText
		public static IRichTextElement CreateRichTextElement()
		{
			throw new NotImplementedException();
		}
		public static IRichTextString CreateRichTextString(string formattedString)
		{
			throw new NotImplementedException();
		}
		public static IRichTextMessage CreateRichTextMessage(IRichTextString richTextString)
		{
			throw new NotImplementedException();
		}
		#endregion
		#region Settings
		public static ISettingsFile CreateSettingsFileReference(string filename)
		{
			throw new NotImplementedException();
		}
		public static ISettingsHandler CreateSettingsHandler()
		{
			throw new NotImplementedException();
		}
		#endregion
		#region UnitsOfMeasurement
		#endregion
		#region YSFlight
		public static IDATFileProperty CreateDATFileProperty(string contents)
		{
			throw new NotImplementedException();
		}
		public static IDATFile CreateDATFileReference(string filename)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
