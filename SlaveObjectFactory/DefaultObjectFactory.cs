using System;
using System.Collections.Generic;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
	{
		private class DefaultObjectFactory : IObjectFactory
		{
			public List<IConnection> AllConnections => throw new NotImplementedException();

			public IColor CreateColor(char colorCode)
			{
				throw new NotImplementedException();
			}

			public IColor CreateColor(int red, int green, int blue)
			{
				throw new NotImplementedException();
			}

			public IColor CreateColor(int alpha, int red, int green, int blue)
			{
				throw new NotImplementedException();
			}

			public ICommandFileLine CreateCommandFileLine(string contents)
			{
				throw new NotImplementedException();
			}

			public ICommandFile CreateCommandFileReference(string filename)
			{
				throw new NotImplementedException();
			}

			public IConnection CreateConnection()
			{
				throw new NotImplementedException();
			}

			public ICoordinate2 CreateCoordinate2(double x, double y)
			{
				throw new NotImplementedException();
			}

			public ICoordinate3 CreateCoordinate3(double x, double y, double z)
			{
				throw new NotImplementedException();
			}

			public IDATFileProperty CreateDATFileProperty(string contents)
			{
				throw new NotImplementedException();
			}

			public IDATFile CreateDATFileReference(string filename)
			{
				throw new NotImplementedException();
			}

			public IDimensionB CreateDimensionB(IAngle type)
			{
				throw new NotImplementedException();
			}

			public IDimensionH CreateDimensionH(IAngle type)
			{
				throw new NotImplementedException();
			}

			public IDimensionP CreateDimensionP(IAngle type)
			{
				throw new NotImplementedException();
			}

			public IDimensionX<T> CreateDimensionX<T>(T type)
			{
				throw new NotImplementedException();
			}

			public IDimensionY<T> CreateDimensionY<T>(T type)
			{
				throw new NotImplementedException();
			}

			public IDimensionZ<T> CreateDimensionZ<T>(T type)
			{
				throw new NotImplementedException();
			}

			public IExceptionHandler CreateExceptionHandler()
			{
				throw new NotImplementedException();
			}

			public IExpiringAction CreateExpiringAction(IUser actionedBy, IDateTime start, IDateTime ends, IRichTextString reason)
			{
				throw new NotImplementedException();
			}

			public IFile CreateFileReference(string filename)
			{
				throw new NotImplementedException();
			}

			public IPacket CreateGenericPacket()
			{
				throw new NotImplementedException();
			}

			public IGlobalPermissions CreateGlobalPermissions()
			{
				throw new NotImplementedException();
			}

			public IGlobalPermissionsTester CreateGlobalPermissionsTester(IHasPermissions Owner)
			{
				throw new NotImplementedException();
			}

			public IGroup CreateGroup(IRichTextString groupName)
			{
				throw new NotImplementedException();
			}

			public IListFileLine CreateListFileLine(string contents)
			{
				throw new NotImplementedException();
			}

			public IListFile CreateListFileReference(string filename)
			{
				throw new NotImplementedException();
			}

			public ILocalPermissions CreateLocalPermissions()
			{
				throw new NotImplementedException();
			}

			public ILocalPermissionsTester CreateLocalPermissionsTester(IHasPermissions Owner)
			{
				throw new NotImplementedException();
			}

			public IOrientation2 CreateOrientation2(IAngle h, IAngle p)
			{
				throw new NotImplementedException();
			}

			public IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b)
			{
				throw new NotImplementedException();
			}

			public IPacket_01_Login CreatePacket01Login()
			{
				throw new NotImplementedException();
			}

			public IPacket_03_Error CreatePacket03Error()
			{
				throw new NotImplementedException();
			}

			public IPacket_05_AddVehicle CreatePacket05AddVehicle()
			{
				throw new NotImplementedException();
			}

			public IPacket_06_Acknowledgement CreatePacket06Acknowledgement()
			{
				throw new NotImplementedException();
			}

			public IPacket_07_SmokeColor CreatePacket07SmokeColor()
			{
				throw new NotImplementedException();
			}

			public IPacket_08_JoinRequest CreatePacket08JoinRequest()
			{
				throw new NotImplementedException();
			}

			public IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved()
			{
				throw new NotImplementedException();
			}

			public IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied()
			{
				throw new NotImplementedException();
			}

			public IPacket_11_FlightData CreatePacket11FlightData()
			{
				throw new NotImplementedException();
			}

			public IPacket_12_LeaveFlight CreatePacket12LeaveFlight()
			{
				throw new NotImplementedException();
			}

			public IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft()
			{
				throw new NotImplementedException();
			}

			public IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation()
			{
				throw new NotImplementedException();
			}

			public IPacket_17_HeartBeat CreatePacket17HeartBeat()
			{
				throw new NotImplementedException();
			}

			public IPacket_18_LockOn CreatePacket18LockOn()
			{
				throw new NotImplementedException();
			}

			public IPacket_19_RemoveGround CreatePacket19RemoveGround()
			{
				throw new NotImplementedException();
			}

			public IPacket_21_GroundData CreatePacket21GroundData()
			{
				throw new NotImplementedException();
			}

			public IPacket_22_Damage CreatePacket22Damage()
			{
				throw new NotImplementedException();
			}

			public IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion()
			{
				throw new NotImplementedException();
			}

			public IPacket_30_AircraftCommand CreatePacket30AircraftCommand()
			{
				throw new NotImplementedException();
			}

			public IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message)
			{
				throw new NotImplementedException();
			}

			public IPacket_32_ServerMessage CreatePacket32ServerMessage(string message)
			{
				throw new NotImplementedException();
			}

			public IPacket_33_Weather CreatePacket33Weather()
			{
				throw new NotImplementedException();
			}

			public IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds()
			{
				throw new NotImplementedException();
			}

			public IPacket_36_WeaponLoadout CreatePacket36WeaponLoadout()
			{
				throw new NotImplementedException();
			}

			public IPacket_37_ListUser CreatePacket37ListUser()
			{
				throw new NotImplementedException();
			}

			public IPacket_38_QueryAirstate CreatePacket38QueryAirstate()
			{
				throw new NotImplementedException();
			}

			public IPacket_39_WeaponsOption CreatePacket39WeaponsOption()
			{
				throw new NotImplementedException();
			}

			public IPacket_41_UsernameDistance CreatePacket41UsernameDistance()
			{
				throw new NotImplementedException();
			}

			public IPacket_43_ServerCommand CreatePacket43ServerCommand()
			{
				throw new NotImplementedException();
			}

			public IPacket_44_AircraftList CreatePacket44AircraftList()
			{
				throw new NotImplementedException();
			}

			public IPacket_45_GroundCommand CreatePacket45GroundCommand()
			{
				throw new NotImplementedException();
			}

			public IPacket_47_ForceJoin CreatePacket47ForceJoin()
			{
				throw new NotImplementedException();
			}

			public IPacket_49_SkyColor CreatePacket49SkyColor()
			{
				throw new NotImplementedException();
			}

			public IPacket_50_GroundColor CreatePacket50GroundColor()
			{
				throw new NotImplementedException();
			}

			public IPacketProcessor CreatePacketProcessor()
			{
				throw new NotImplementedException();
			}

			public IPermanentAction CreatePermanentAction(IUser actionedBy, IDateTime actioneDateTime, IRichTextString reason)
			{
				throw new NotImplementedException();
			}

			public IPermission CreatePermission(int minRank, int maxRank, bool MustOutrank)
			{
				throw new NotImplementedException();
			}

			public IPoint2 CreatePoint2(IDistance x, IDistance y)
			{
				throw new NotImplementedException();
			}

			public IPoint3 CreatePoint3(IDistance x, IDistance y, IDistance z)
			{
				throw new NotImplementedException();
			}

			public IPacket_04_Field CreatePacket04Field()
			{
				throw new NotImplementedException();
			}

			public IQuadraticEquation CreateQuadraticEquation(double y, double x, double a, double b, double c)
			{
				throw new NotImplementedException();
			}

			public IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3)
			{
				throw new NotImplementedException();
			}

			public IRank CreateRank(IRichTextString rankName)
			{
				throw new NotImplementedException();
			}

			public IRichTextElement CreateRichTextElement()
			{
				throw new NotImplementedException();
			}

			public IRichTextMessage CreateRichTextMessage(IRichTextString richTextString)
			{
				throw new NotImplementedException();
			}

			public IRichTextString CreateRichTextString(string formattedString)
			{
				throw new NotImplementedException();
			}

			public IServer CreateServer()
			{
				throw new NotImplementedException();
			}

			public ISettingsFile CreateSettingsFileReference(string filename)
			{
				throw new NotImplementedException();
			}

			public ISettingsHandler CreateSettingsHandler()
			{
				throw new NotImplementedException();
			}

			public IStatistic CreateStatsticTracker()
			{
				throw new NotImplementedException();
			}

			public IUser CreateUser(IRichTextString userName)
			{
				throw new NotImplementedException();
			}

			public IUserGroupUpdate CreateUserGroupUpdate(IGroup group, IRank rank, IUser actionedBy, IDateTime actioneDateTime, GroupUpdateType updateType, IRichTextString reason)
			{
				throw new NotImplementedException();
			}

			public IUserHistory CreateUserHistory()
			{
				throw new NotImplementedException();
			}

			public IVector2 CreateVector2(IDistance x, IDistance y)
			{
				throw new NotImplementedException();
			}

			public IVector3 CreateVector3(IDistance x, IDistance y, IDistance z)
			{
				throw new NotImplementedException();
			}

			public IPacket_48_FogColor CreatePacket48FogColor()
			{
				throw new NotImplementedException();
			}

			public IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn()
			{
				throw new NotImplementedException();
			}

			public IPacket_31_MissilesOption CreatePacket31MissilesOption()
			{
				throw new NotImplementedException();
			}

			public List<IConnection> ExcludeConnections(List<IConnection> connections, IConnection exlude)
			{
				throw new NotImplementedException();
			}

			public List<IConnection> ExcludeConnections(List<IConnection> connections, List<IConnection> exlude)
			{
				throw new NotImplementedException();
			}

			public List<IConnection> IncludeConnections(List<IConnection> connections, IConnection include)
			{
				throw new NotImplementedException();
			}

			public List<IConnection> IncludeConnections(List<IConnection> connections, List<IConnection> include)
			{
				throw new NotImplementedException();
			}

			public IPacketWaiter CreatePacketWaiter(IConnection thisConnection, uint type)
			{
				throw new NotImplementedException();
			}
		}
	}
}
