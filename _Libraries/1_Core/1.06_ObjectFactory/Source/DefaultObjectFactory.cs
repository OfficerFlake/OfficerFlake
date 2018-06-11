using System;
using System.Collections.Generic;
using System.Net.Sockets;
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
			#region 3_FileIO
			public IFile CreateFileReference(string filename) => throw new NotImplementedException();
			#endregion
			#region 4_ObjectFactory
			//ObjectFactory can't create self!
			#endregion
			#region 5_Extensions
			//No objects to create in interfaces!
			#endregion
			#region 6_Settings
			//No objects to create in interfaces!
			#endregion

			//UNITS
			#region Colors
			//Colors
			public ISimpleColor CreateSimpleColor(IColor color, char colorCode) => throw new NotImplementedException();
			public IColor CreateColor(byte red, byte green, byte blue) => throw new NotImplementedException();
			public IColor CreateColor(byte alpha, byte red, byte green, byte blue) => throw new NotImplementedException();

			//Formatting
			public IFormattingDescriptor CreateFormattingDescriptor(IColor backColor, IColor foreColor, Boolean isBold, Boolean isItallic, Boolean isUnderlined, Boolean isStrikeout, Boolean isObfuscated) => throw new NotImplementedException();

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
			#region Math
			//Coordinates
			public ICoordinate2 CreateCoordinate2(IDistance x, IDistance y) => throw new NotImplementedException();
			public ICoordinate3 CreateCoordinate3(IDistance x, IDistance y, IDistance z) => throw new NotImplementedException();

			public IPoint2<T> CreatePoint2<T>(T x, T y) => throw new NotImplementedException();
			public IPoint3<T> CreatePoint3<T>(T x, T y, T z) => throw new NotImplementedException();
			public IVector2<T> CreateVector2<T>(T x, T y) => throw new NotImplementedException();
			public IVector3<T> CreateVector3<T>(T x, T y, T z) => throw new NotImplementedException();

			public IOrientation2 CreateOrientation2(IAngle h, IAngle p) => throw new NotImplementedException();
			public IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b) => throw new NotImplementedException();

			//Quadratic
			public IQuadraticEquation CreateQuadraticEquation(double result, double a, double b, double c) => throw new NotImplementedException();
			public IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3) => throw new NotImplementedException();
			public IQuadraticEquation CreateStatisticsCurve(double minimum, double center, double maximum) => throw new NotImplementedException();
			//Statastic
			public IStatistic CreateStatsticTracker(string name) => throw new NotImplementedException();
			#endregion
			#region Networking
			//Connection
			public IConnection CreateConnection(Socket TCPSocket, Boolean isProxyMode) => throw new NotImplementedException();

			//Packets
			public IPacket CreateGenericPacket() => throw new NotImplementedException();
			public IPacket_00_Null CreatePacket00Null() => throw new NotImplementedException();
			public IPacket_01_Login CreatePacket01Login() => throw new NotImplementedException();
			public IPacket_02_Logoff CreatePacket02Logoff() => throw new NotImplementedException();
			public IPacket_03_Error CreatePacket03Error() => throw new NotImplementedException();
			public IPacket_04_Field CreatePacket04Field() => throw new NotImplementedException();
			public IPacket_05_AddVehicle CreatePacket05AddVehicle() => throw new NotImplementedException();
			public IPacket_06_Acknowledgement CreatePacket06Acknowledgement(params UInt32[] args) => throw new NotImplementedException();
			public IPacket_07_SmokeColor CreatePacket07SmokeColor() => throw new NotImplementedException();
			public IPacket_08_JoinRequest CreatePacket08JoinRequest() => throw new NotImplementedException();
			public IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved() => throw new NotImplementedException();
			public IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied() => throw new NotImplementedException();
			public IPacket_11_FlightData CreatePacket11FlightData(Int16 version = 3) => throw new NotImplementedException();
			public IPacket_12_LeaveFlight CreatePacket12LeaveFlight() => throw new NotImplementedException();
			public IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft() => throw new NotImplementedException();
			public IPacket_14_RequestTestAirplane CreatePacket14RequestTestAirplane() => throw new NotImplementedException();
			public IPacket_15_KillServer CreatePacket15KillServer() => throw new NotImplementedException();
			public IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation() => throw new NotImplementedException();
			public IPacket_17_HeartBeat CreatePacket17HeartBeat() => throw new NotImplementedException();
			public IPacket_18_LockOn CreatePacket18LockOn() => throw new NotImplementedException();
			public IPacket_19_RemoveGround CreatePacket19RemoveGround() => throw new NotImplementedException();
			public IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn() => throw new NotImplementedException();
			public IPacket_21_GroundData CreatePacket21GroundData() => throw new NotImplementedException();
			public IPacket_22_Damage CreatePacket22Damage() => throw new NotImplementedException();
			public IPacket_23_GroundTurretState CreatePacket23GroundTurretState() => throw new NotImplementedException();
			public IPacket_24_SetTestAutoPilot CreatePacket24SetTestAutoPilot() => throw new NotImplementedException();
			public IPacket_25_RequestToBeSideWindowOfServer CreatePacket25RequestToBeSideWindowOfServer() => throw new NotImplementedException();
			public IPacket_26_AssignSideWindow CreatePacket26AssignSideWindow() => throw new NotImplementedException();
			public IPacket_27_ResendAirRequest CreatePacket27ResendAirRequest() => throw new NotImplementedException();
			public IPacket_28_ResendGroundRequest CreatePacket28ResendGroundRequest() => throw new NotImplementedException();
			public IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion() => throw new NotImplementedException();
			public IPacket_30_AircraftCommand CreatePacket30AircraftCommand() => throw new NotImplementedException();
			public IPacket_31_MissilesOption CreatePacket31MissilesOption() => throw new NotImplementedException();
			public IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message) => throw new NotImplementedException();
			public IPacket_32_ServerMessage CreatePacket32ServerMessage(string message) => throw new NotImplementedException();
			public IPacket_33_Weather CreatePacket33Weather() => throw new NotImplementedException();
			public IPacket_34_NeedResendJoinApproval CreatePacket34NeedResendJoinApproval() => throw new NotImplementedException();
			public IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds() => throw new NotImplementedException();
			public IPacket_36_WeaponsLoadout CreatePacket36WeaponsLoadout() => throw new NotImplementedException();
			public IPacket_37_ListUser CreatePacket37ListUser() => throw new NotImplementedException();
			public IPacket_38_QueryAirstate CreatePacket38QueryAirstate() => throw new NotImplementedException();
			public IPacket_39_WeaponsOption CreatePacket39WeaponsOption() => throw new NotImplementedException();
			public IPacket_40_AirTurretState CreatePacket40AirTurretState() => throw new NotImplementedException();
			public IPacket_41_UsernameDistance CreatePacket41UsernameDistance() => throw new NotImplementedException();
			public IPacket_42_ConfirmExistence CreatePacket42ConfirmExistence() => throw new NotImplementedException();
			public IPacket_43_ServerCommand CreatePacket43ServerCommand() => throw new NotImplementedException();
			public IPacket_44_AircraftList CreatePacket44AircraftList() => throw new NotImplementedException();
			public IPacket_45_GroundCommand CreatePacket45GroundCommand() => throw new NotImplementedException();
			public IPacket_46_ReportScore CreatePacket46ReportScore() => throw new NotImplementedException();
			public IPacket_47_ForceJoin CreatePacket47ForceJoin() => throw new NotImplementedException();
			public IPacket_48_FogColor CreatePacket48FogColor() => throw new NotImplementedException();
			public IPacket_49_SkyColor CreatePacket49SkyColor() => throw new NotImplementedException();
			public IPacket_50_GroundColor CreatePacket50GroundColor() => throw new NotImplementedException();
			public IPacket_64_UserPacket CreatePacket64UserPacket() => throw new NotImplementedException();

			//PacketProcessor

			//Server
			public Boolean ServerStart() => throw new NotImplementedException();
			public Boolean ServerStop() => throw new NotImplementedException();
			#endregion
			#region RichText
			public IRichTextElement CreateRichTextElement(IFormattingDescriptor preFormmating) => throw new NotImplementedException();
			public IRichTextElement CreateRichTextElement(string unformattedString) => throw new NotImplementedException();
			public IRichTextString CreateRichTextString(IFormattingDescriptor preFormmating) => throw new NotImplementedException();
			public IRichTextString CreateRichTextString(string formattedString) => throw new NotImplementedException();
			public IRichTextMessage CreateRichTextMessage(IRichTextString richTextString) => throw new NotImplementedException();

			public IConsoleUserMessage CreateConsoleUserMessage(IUser user, IRichTextString message) => throw new NotImplementedException();
			public IConsoleInformationMessage CreateConsoleInformationMessage(IRichTextString message) => throw new NotImplementedException();

			public IDebugSummaryMessage CreateDebugSummaryMessage(IRichTextString message) => throw new NotImplementedException();
			public IDebugDetailMessage CreateDebugDetailMessage(IRichTextString message) => throw new NotImplementedException();
			public IDebugWarningMessage CreateDebugWarningMessage(IRichTextString message) => throw new NotImplementedException();
			public IDebugErrorMessage CreateDebugErrorMessage(Exception e, IRichTextString message) => throw new NotImplementedException();
			public IDebugCrashMessage CreateDebugCrashMessage(Exception e, IRichTextString message) => throw new NotImplementedException();
			#endregion
			#region UnitsOfMeasurement
			#region Angle
			public bool TryParse(string value, out IAngle output) => throw new NotImplementedException();
			public IDegree CreateDegree(double value) => throw new NotImplementedException();
			public IGradian CreateGradian(double value) => throw new NotImplementedException();
			public IRadian CreateRadian(double value) => throw new NotImplementedException();
			#endregion
			#region Area
			public bool TryParse(string value, out IArea output) => throw new NotImplementedException();
			public IAcre CreateAcre(double value) => throw new NotImplementedException();
			public ISquareCentiMeter CreateSquareCentiMeter(double value) => throw new NotImplementedException();
			public ISquareFoot CreateSquareFoot(double value) => throw new NotImplementedException();
			public ISquareInch CreateSquareInch(double value) => throw new NotImplementedException();
			public ISquareKiloMeter CreateSquareKiloMeter(double value) => throw new NotImplementedException();
			public ISquareMeter CreateSquareMeter(double value) => throw new NotImplementedException();
			public ISquareMile CreateSquareMile(double value) => throw new NotImplementedException();
			public ISquareMilliMeter CreateSquareMilliMeter(double value) => throw new NotImplementedException();
			public ISquareNauticalMile CreateSquareNauticalMile(double value) => throw new NotImplementedException();
			public ISquareYard CreateSquareYard(double value) => throw new NotImplementedException();
			#endregion
			#region Distance
			public bool TryParse(string value, out IDistance output) => throw new NotImplementedException();
			public ICentiMeter CreateCentiMeter(double value) => throw new NotImplementedException();
			public IFoot CreateFoot(double value) => throw new NotImplementedException();
			public IInch CreateInch(double value) => throw new NotImplementedException();
			public IKiloMeter CreateKiloMeter(double value) => throw new NotImplementedException();
			public IMeter CreateMeter(double value) => throw new NotImplementedException();
			public IMicron CreateMicron(double value) => throw new NotImplementedException();
			public IMile CreateMile(double value) => throw new NotImplementedException();
			public IMilliMeter CreateMilliMeter(double value) => throw new NotImplementedException();
			public INanoMeter CreateNanoMeter(double value) => throw new NotImplementedException();
			public INauticalMile CreateNauticalMile(double value) => throw new NotImplementedException();
			public IYard CreateYard(double value) => throw new NotImplementedException();
			#endregion
			#region Duration
			public bool TryParse(string value, out IDuration output) => throw new NotImplementedException();
			public ISecond CreateSecond(double value) => throw new NotImplementedException();
			public IMinute CreateMinute(double value) => throw new NotImplementedException();
			public IHour CreateHour(double value) => throw new NotImplementedException();
			public IDay CreateDay(double value) => throw new NotImplementedException();
			public IWeek CreateWeek(double value) => throw new NotImplementedException();
			public IMonth CreateMonth(double value) => throw new NotImplementedException();
			public IYear CreateYear(double value) => throw new NotImplementedException();

			public IDate CreateDate(System.DateTime date) => throw new NotImplementedException();
			public IDate CreateDate(string date) => throw new NotImplementedException();
			public ITime CreateTime(System.DateTime time) => throw new NotImplementedException();
			public ITime CreateTime(string time) => throw new NotImplementedException();
			public IDateTime CreateDateTime(System.DateTime dateTime) => throw new NotImplementedException();
			public IDateTime CreateDateTime(string dateTime) => throw new NotImplementedException();
			public ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan) => throw new NotImplementedException();
			public ITimeSpan CreateTimeSpan(string timeSpan) => throw new NotImplementedException();
			#endregion
			#region Energy
			public bool TryParse(string value, out IEnergy output) => throw new NotImplementedException();
			public IBritishThermalUnit CreateBritishThermalUnit(double value) => throw new NotImplementedException();
			public IElectronVolt CreateElectronVolt(double value) => throw new NotImplementedException();
			public IFoodCalorie CreateFoodCalorie(double value) => throw new NotImplementedException();
			public IFootPound CreateFootPound(double value) => throw new NotImplementedException();
			public IJoule CreateJoule(double value) => throw new NotImplementedException();
			public IKiloJoule CreateKiloJoule(double value) => throw new NotImplementedException();
			public IThermalCalorie CreateThermalCalorie(double value) => throw new NotImplementedException();
			#endregion
			#region Mass
			public bool TryParse(string value, out IMass output) => throw new NotImplementedException();
			public ICarat CreateCarat(double value) => throw new NotImplementedException();
			public ICentiGram CreateCentiGram(double value) => throw new NotImplementedException();
			public IDecaGram CreateDecaGram(double value) => throw new NotImplementedException();
			public IDeciGram CreateDeciGram(double value) => throw new NotImplementedException();
			public IGram CreateGram(double value) => throw new NotImplementedException();
			public IHectoGram CreateHectoGram(double value) => throw new NotImplementedException();
			public IKiloGram CreateKiloGram(double value) => throw new NotImplementedException();
			public IMetricTonne CreateMetricTonne(double value) => throw new NotImplementedException();
			public IMilliGram CreateMilliGram(double value) => throw new NotImplementedException();
			public IOunce CreateOunce(double value) => throw new NotImplementedException();
			public IPound CreatePound(double value) => throw new NotImplementedException();
			public IStone CreateStone(double value) => throw new NotImplementedException();
			public IUKLongTon CreateUKLongTon(double value) => throw new NotImplementedException();
			public IUSShortTon CreateUSShortTon(double value) => throw new NotImplementedException();
			#endregion
			#region Power
			public bool TryParse(string value, out IPower output) => throw new NotImplementedException();
			public IBTUPerMinute CreateBTUPerMinute(double value) => throw new NotImplementedException();
			public IFootPoundPerMinute CreateFootPoundPerMinute(double value) => throw new NotImplementedException();
			public IKiloWatt CreateKiloWatt(double value) => throw new NotImplementedException();
			public IUSHorsePower CreateUSHorsePower(double value) => throw new NotImplementedException();
			public IWatt CreateWatt(double value) => throw new NotImplementedException();
			#endregion
			#region Pressure
			public bool TryParse(string value, out IPressure output) => throw new NotImplementedException();
			public IAtmosphere CreateAtmosphere(double value) => throw new NotImplementedException();
			public IBar CreateBar(double value) => throw new NotImplementedException();
			public IKiloPascal CreateKiloPascal(double value) => throw new NotImplementedException();
			public IMilliMeterOfMercury CreateMilliMeterOfMercury(double value) => throw new NotImplementedException();
			public IPascal CreatePascal(double value) => throw new NotImplementedException();
			public IPoundPerSquareInch CreatePoundPerSquareInch(double value) => throw new NotImplementedException();
			#endregion
			#region Speed
			public bool TryParse(string value, out ISpeed output) => throw new NotImplementedException();
			public ICentiMeterPerSecond CreateCentiMeterPerSecond(double value) => throw new NotImplementedException();
			public IFootPerSecond CreateFootPerSecond(double value) => throw new NotImplementedException();
			public IKiloMeterPerHour CreateKiloMeterPerHour(double value) => throw new NotImplementedException();
			public IKnot CreateKnot(double value) => throw new NotImplementedException();
			public IMachAtSeaLevel CreateMachAtSeaLevel(double value) => throw new NotImplementedException();
			public IMeterPerSecond CreateMeterPerSecond(double value) => throw new NotImplementedException();
			public IMilePerHour CreateMilePerHour(double value) => throw new NotImplementedException();
			public IMilliMeterPerSecond CreateMilliMeterPerSecond(double value) => throw new NotImplementedException();
			#endregion
			#region Temperature
			public bool TryParse(string value, out ITemperature output) => throw new NotImplementedException();
			public IDegreeCelsius CreateDegreeCelsius(double value) => throw new NotImplementedException();
			public IDegreeFahrenheit CreateDegreeFahrenheit(double value) => throw new NotImplementedException();
			public IDegreeKelvin CreateDegreeKelvin(double value) => throw new NotImplementedException();
			#endregion
			#region Volume
			public bool TryParse(string value, out IVolume output) => throw new NotImplementedException();
			public IFluidOunce CreateFluidOunce(double value) => throw new NotImplementedException();
			public IUKGallon CreateUKGallon(double value) => throw new NotImplementedException();
			public IUKPint CreateUKPint(double value) => throw new NotImplementedException();
			public IUKQuart CreateUKQuart(double value) => throw new NotImplementedException();
			public IUKTableSpoon CreateUKTableSpoon(double value) => throw new NotImplementedException();
			public IUKTeaSpoon CreateUKTeaSpoon(double value) => throw new NotImplementedException();

			public ICup CreateCup(double value) => throw new NotImplementedException();
			public IUSGallon CreateUSGallon(double value) => throw new NotImplementedException();
			public IUSPint CreateUSPint(double value) => throw new NotImplementedException();
			public IUSQuart CreateUSQuart(double value) => throw new NotImplementedException();
			public IUSTableSpoon CreateUSTableSpoon(double value) => throw new NotImplementedException();
			public IUSTeaSpoon CreateUSTeaSpoon(double value) => throw new NotImplementedException();

			public ICubicCentiMeter CreateCubicCentiMeter(double value) => throw new NotImplementedException();
			public ICubicFoot CreateCubicFoot(double value) => throw new NotImplementedException();
			public ICubicInch CreateCubicInch(double value) => throw new NotImplementedException();
			public ICubicMeter CreateCubicMeter(double value) => throw new NotImplementedException();
			public ICubicYard CreateCubicYard(double value) => throw new NotImplementedException();
			public ILitre CreateLitre(double value) => throw new NotImplementedException();
			public IMilliLitre CreateMilliLitre(double value) => throw new NotImplementedException();
			#endregion
			#endregion

			#region YSFlight
			public IDATFile CreateDATFileReference(string filename) => throw new NotImplementedException();
			public ILSTFile CreateLSTFileReference(string filename) => throw new NotImplementedException();

			public IYSTypeAircraftCategory CreateYSTypeAircraftCategory(string[] values) => throw new NotImplementedException();
			public IYSTypeHardpointDescription CreateYSTypeHardpointDescription(string value) => throw new NotImplementedException();
			public IYSTypeWeaponCategory CreateYSTypeWeaponCategory(string[] values) => throw new NotImplementedException();
			public IYSTypeWeaponType CreateYSTypeWeaponType(string[] values) => throw new NotImplementedException();

			public IWorldVehicle CreateVehicle() => throw new NotImplementedException();
			public IWorldAircraft CreateAircraft() => throw new NotImplementedException();
			public IWorldGround CreateGround() => throw new NotImplementedException();

			public IMetaDataAircraft CreateMetaDataAircraft(string identify) => throw new NotImplementedException();
			public IMetaDataGround CreateMetaDataGround(string identify) => throw new NotImplementedException();
			public IMetaDataScenery CreateMetaDataScenery(string identify) => throw new NotImplementedException();
			#endregion
		}
	}
}
