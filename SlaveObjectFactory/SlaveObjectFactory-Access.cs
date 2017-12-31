using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	public static partial class ObjectFactory
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
		//ObjectFactory has direct access.
		#endregion
		#region 4_ObjectFactory
		//ObjectFactory can't create self!
		#endregion
		#region 5_Extensions
		//No objects to create in Extensions!
		#endregion
		#region 6_Settings
		//No objects to create in Settings!
		#endregion

		//UNITS
		#region Color
		public static ISimpleColor CreateSimpleColor(IColor color, char colorCode) => slaveFactory.CreateSimpleColor(color, colorCode);
		public static IColor CreateColor(byte red, byte green, byte blue) => slaveFactory.CreateColor(red, green, blue);
		public static IColor CreateColor(byte alpha, byte red, byte green, byte blue) => slaveFactory.CreateColor(alpha, red, green, blue);

		public static IFormattingDescriptor CreateFormattingDescriptor(IColor backColor, IColor foreColor, Boolean isBold, Boolean isItallic, Boolean isUnderlined, Boolean isStrikeout, Boolean isObfuscated) => slaveFactory.CreateFormattingDescriptor(backColor, foreColor, isBold, isItallic, isUnderlined, isStrikeout,isObfuscated);
		#endregion
		#region Database
		//Group
		public static IGroup CreateGroup(IRichTextString groupName) => slaveFactory.CreateGroup(groupName);

		//Permissions
		public static IPermissions CreatePermissions() => slaveFactory.CreatePermissions();

		//Rank
		public static IRank CreateRank(IRichTextString rankName) => slaveFactory.CreateRank(rankName);

		//User
		public static IUser CreateUser(IRichTextString userName) => slaveFactory.CreateUser(userName);
		#endregion
		#region Math
		//Coordinates
		public static ICoordinate2 CreateCoordinate2(double x, double y) => slaveFactory.CreateCoordinate2(x, y);
		public static ICoordinate3 CreateCoordinate3(double x, double y, double z) => slaveFactory.CreateCoordinate3(x, y, z);

		public static IPoint2 CreatePoint2(IDistance x, IDistance y) => slaveFactory.CreatePoint2(x, y);
		public static IPoint3 CreatePoint3(IDistance x, IDistance y, IDistance z) => slaveFactory.CreatePoint3(x, y, z);
		public static IVector2 CreateVector2(IDistance x, IDistance y) => slaveFactory.CreateVector2(x, y);
		public static IVector3 CreateVector3(IDistance x, IDistance y, IDistance z) => slaveFactory.CreateVector3(x, y, z);

		public static IOrientation2 CreateOrientation2(IAngle h, IAngle p) => slaveFactory.CreateOrientation2(h, p);
		public static IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b) => slaveFactory.CreateOrientation3(h, p, b);

		//Quadratics
		public static IQuadraticEquation CreateQuadraticEquation(double result, double x, double a, double b, double c) => slaveFactory.CreateQuadraticEquation(result, a, b, c);
		public static IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3) => slaveFactory.CreateQuadraticEquationFrom3Coordinate2(coordinate1, coordinate2, coordinate3);
		public static IQuadraticEquation CreateStatisticsCurve(double minimum, double center, double maximum) =>slaveFactory.CreateStatisticsCurve(minimum, center, maximum);

		//Statistics
		public static IStatistic CreateStatsticTracker(string name) => slaveFactory.CreateStatsticTracker(name);
		#endregion
		#region Networking
		//Connection
		public static IConnection CreateConnection(Socket TCPSocket) => slaveFactory.CreateConnection(TCPSocket);

		//Packets
		public static IPacket CreateGenericPacket() => slaveFactory.CreateGenericPacket();
		public static IPacket_01_Login CreatePacket01Login() => slaveFactory.CreatePacket01Login();
		public static IPacket_03_Error CreatePacket03Error() => slaveFactory.CreatePacket03Error();
		public static IPacket_04_Field CreatePacket04Field() => slaveFactory.CreatePacket04Field();
		public static IPacket_05_AddVehicle CreatePacket05AddVehicle() => slaveFactory.CreatePacket05AddVehicle();
		public static IPacket_06_Acknowledgement CreatePacket06Acknowledgement() => slaveFactory.CreatePacket06Acknowledgement();
		public static IPacket_07_SmokeColor CreatePacket07SmokeColor() => slaveFactory.CreatePacket07SmokeColor();
		public static IPacket_08_JoinRequest CreatePacket08JoinRequest() => slaveFactory.CreatePacket08JoinRequest();
		public static IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved() => slaveFactory.CreatePacket09JoinRequestApproved();
		public static IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied() => slaveFactory.CreatePacket10JoinRequestDenied();
		public static IPacket_11_FlightData CreatePacket11FlightData() => slaveFactory.CreatePacket11FlightData();
		public static IPacket_12_LeaveFlight CreatePacket12LeaveFlight() => slaveFactory.CreatePacket12LeaveFlight();
		public static IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft() => slaveFactory.CreatePacket13RemoveAircraft();
		public static IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation() => slaveFactory.CreatePacket16PrepareSimulation();
		public static IPacket_17_HeartBeat CreatePacket17HeartBeat() => slaveFactory.CreatePacket17HeartBeat();
		public static IPacket_18_LockOn CreatePacket18LockOn() => slaveFactory.CreatePacket18LockOn();
		public static IPacket_19_RemoveGround CreatePacket19RemoveGround() => slaveFactory.CreatePacket19RemoveGround();
		public static IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn() => slaveFactory.CreatePacket20OrdinanceSpawn();
		public static IPacket_21_GroundData CreatePacket21GroundData() => slaveFactory.CreatePacket21GroundData();
		public static IPacket_22_Damage CreatePacket22Damage() => slaveFactory.CreatePacket22Damage();
		public static IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion() => slaveFactory.CreatePacket29NetcodeVersion();
		public static IPacket_30_AircraftCommand CreatePacket30AircraftCommand() => slaveFactory.CreatePacket30AircraftCommand();
		public static IPacket_31_MissilesOption CreatePacket31MissilesOption() => slaveFactory.CreatePacket31MissilesOption();
		public static IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message) => slaveFactory.CreatePacket32ChatMessage(user,message);
		public static IPacket_32_ServerMessage CreatePacket32ServerMessage(string message) => slaveFactory.CreatePacket32ServerMessage(message);
		public static IPacket_33_Weather CreatePacket33Weather() => slaveFactory.CreatePacket33Weather();
		public static IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds() => slaveFactory.CreatePacket35ReviveAllGrounds();
		public static IPacket_36_WeaponLoadout CreatePacket36WeaponLoadout() => slaveFactory.CreatePacket36WeaponLoadout();
		public static IPacket_37_ListUser CreatePacket37ListUser() => slaveFactory.CreatePacket37ListUser();
		public static IPacket_38_QueryAirstate CreatePacket38QueryAirstate() => slaveFactory.CreatePacket38QueryAirstate();
		public static IPacket_39_WeaponsOption CreatePacket39WeaponsOption() => slaveFactory.CreatePacket39WeaponsOption();
		public static IPacket_41_UsernameDistance CreatePacket41UsernameDistance() => slaveFactory.CreatePacket41UsernameDistance();
		public static IPacket_43_ServerCommand CreatePacket43ServerCommand() => slaveFactory.CreatePacket43ServerCommand();
		public static IPacket_44_AircraftList CreatePacket44AircraftList() => slaveFactory.CreatePacket44AircraftList();
		public static IPacket_45_GroundCommand CreatePacket45GroundCommand() => slaveFactory.CreatePacket45GroundCommand();
		public static IPacket_47_ForceJoin CreatePacket47ForceJoin() => slaveFactory.CreatePacket47ForceJoin();
		public static IPacket_48_FogColor CreatePacket48FogColor() => slaveFactory.CreatePacket48FogColor();
		public static IPacket_49_SkyColor CreatePacket49SkyColor() => slaveFactory.CreatePacket49SkyColor();
		public static IPacket_50_GroundColor CreatePacket50GroundColor() => slaveFactory.CreatePacket50GroundColor();

		//PacketProcessor

		//Server
		public static Boolean ServerStart() => slaveFactory.ServerStart();
		public static Boolean ServerStop() => slaveFactory.ServerStop();
		#endregion
		#region RichText
		public static IRichTextElement CreateRichTextElement(IFormattingDescriptor preformatting) => slaveFactory.CreateRichTextElement(preformatting);
		public static IRichTextElement CreateRichTextElement(string unformattedString) => slaveFactory.CreateRichTextElement(unformattedString);
		public static IRichTextString CreateRichTextString(IFormattingDescriptor preformatting) => slaveFactory.CreateRichTextString(preformatting);
		public static IRichTextString CreateRichTextString(string formattedString) =>slaveFactory.CreateRichTextString(formattedString);
		public static IRichTextMessage CreateRichTextMessage(IRichTextString richTextString) => slaveFactory.CreateRichTextMessage(richTextString);

		public static IConsoleUserMessage CreateConsoleUserMessage(IUser user, IRichTextString message) => slaveFactory.CreateConsoleUserMessage(user, message);
		public static IConsoleInformationMessage CreateConsoleInformationMessage(IRichTextString message) => slaveFactory.CreateConsoleInformationMessage(message);

		public static IDebugSummaryMessage CreateDebugSummaryMessage(IRichTextString message) => slaveFactory.CreateDebugSummaryMessage(message);
		public static IDebugDetailMessage CreateDebugDetailMessage(IRichTextString message) => slaveFactory.CreateDebugDetailMessage(message);
		public static IDebugWarningMessage CreateDebugWarningMessage(IRichTextString message) => slaveFactory.CreateDebugWarningMessage(message);

		public static IDebugErrorMessage CreateDebugErrorMessage(Exception e, IRichTextString message) => slaveFactory.CreateDebugErrorMessage(e, message);
		public static IDebugCrashMessage CreateDebugCrashMessage(Exception e, IRichTextString message) => slaveFactory.CreateDebugCrashMessage(e, message);
		#endregion
		#region UnitsOfMeasurement
		#region Angle
		public static bool TryParse(string value, out IAngle output) => slaveFactory.TryParse(value, out output);
		public static IDegree CreateDegree(double value) => slaveFactory.CreateDegree(value);
		public static IGradian CreateGradian(double value) => slaveFactory.CreateGradian(value);
		public static IRadian CreateRadian(double value) => slaveFactory.CreateRadian(value);
		#endregion
		#region Area
		public static bool TryParse(string value, out IArea output) => slaveFactory.TryParse(value, out output);
		public static IAcre CreateAcre(double value) => slaveFactory.CreateAcre(value);
		public static ISquareCentiMeter CreateSquareCentiMeter(double value) => slaveFactory.CreateSquareCentiMeter(value);
		public static ISquareFoot CreateSquareFoot(double value) => slaveFactory.CreateSquareFoot(value);
		public static ISquareInch CreateSquareInch(double value) => slaveFactory.CreateSquareInch(value);
		public static ISquareKiloMeter CreateSquareKiloMeter(double value) => slaveFactory.CreateSquareKiloMeter(value);
		public static ISquareMeter CreateSquareMeter(double value) => slaveFactory.CreateSquareMeter(value);
		public static ISquareMile CreateSquareMile(double value) => slaveFactory.CreateSquareMile(value);
		public static ISquareMilliMeter CreateSquareMilliMeter(double value) => slaveFactory.CreateSquareMilliMeter(value);
		public static ISquareNauticalMile CreateSquareNauticalMile(double value) => slaveFactory.CreateSquareNauticalMile(value);
		public static ISquareYard CreateSquareYard(double value) => slaveFactory.CreateSquareYard(value);
		#endregion
		#region Distance
		public static bool TryParse(string value, out IDistance output) => slaveFactory.TryParse(value, out output);
		public static ICentiMeter CreateCentiMeter(double value) => slaveFactory.CreateCentiMeter(value);
		public static IFoot CreateFoot(double value) => slaveFactory.CreateFoot(value);
		public static IInch CreateInch(double value) => slaveFactory.CreateInch(value);
		public static IKiloMeter CreateKiloMeter(double value) => slaveFactory.CreateKiloMeter(value);
		public static IMeter CreateMeter(double value) => slaveFactory.CreateMeter(value);
		public static IMicron CreateMicron(double value) => slaveFactory.CreateMicron(value);
		public static IMile CreateMile(double value) => slaveFactory.CreateMile(value);
		public static IMilliMeter CreateMilliMeter(double value) => slaveFactory.CreateMilliMeter(value);
		public static INanoMeter CreateNanoMeter(double value) => slaveFactory.CreateNanoMeter(value);
		public static INauticalMile CreateNauticalMile(double value) => slaveFactory.CreateNauticalMile(value);
		public static IYard CreateYard(double value) => slaveFactory.CreateYard(value);
		#endregion
		#region Duration
		public static bool TryParse(string value, out IDuration output) => slaveFactory.TryParse(value, out output);
		public static ISecond CreateSecond(double value) => slaveFactory.CreateSecond(value);
		public static IMinute CreateMinute(double value) => slaveFactory.CreateMinute(value);
		public static IHour CreateHour(double value) => slaveFactory.CreateHour(value);
		public static IDay CreateDay(double value) => slaveFactory.CreateDay(value);
		public static IWeek CreateWeek(double value) => slaveFactory.CreateWeek(value);
		public static IMonth CreateMonth(double value) => slaveFactory.CreateMonth(value);
		public static IYear CreateYear(double value) => slaveFactory.CreateYear(value);

		public static IDate CreateDate(System.DateTime dateTime) => slaveFactory.CreateDate(dateTime);
		public static ITime CreateTime(System.DateTime dateTime) => slaveFactory.CreateTime(dateTime);
		public static IDateTime CreateDateTime(System.DateTime dateTime) => slaveFactory.CreateDateTime(dateTime);
		public static ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan) => slaveFactory.CreateTimeSpan(timeSpan);
		#endregion
		#region Energy
		public static bool TryParse(string value, out IEnergy output) => slaveFactory.TryParse(value, out output);
		public static IBritishThermalUnit CreateBritishThermalUnit(double value) => slaveFactory.CreateBritishThermalUnit(value);
		public static IElectronVolt CreateElectronVolt(double value) => slaveFactory.CreateElectronVolt(value);
		public static IFoodCalorie CreateFoodCalorie(double value) => slaveFactory.CreateFoodCalorie(value);
		public static IFootPound CreateFootPound(double value) => slaveFactory.CreateFootPound(value);
		public static IJoule CreateJoule(double value) => slaveFactory.CreateJoule(value);
		public static IKiloJoule CreateKiloJoule(double value) => slaveFactory.CreateKiloJoule(value);
		public static IThermalCalorie CreateThermalCalorie(double value) => slaveFactory.CreateThermalCalorie(value);
		#endregion
		#region Mass
		public static bool TryParse(string value, out IMass output) => slaveFactory.TryParse(value, out output);
		public static ICarat CreateCarat(double value) => slaveFactory.CreateCarat(value);
		public static ICentiGram CreateCentiGram(double value) => slaveFactory.CreateCentiGram(value);
		public static IDecaGram CreateDecaGram(double value) => slaveFactory.CreateDecaGram(value);
		public static IDeciGram CreateDeciGram(double value) => slaveFactory.CreateDeciGram(value);
		public static IGram CreateGram(double value) => slaveFactory.CreateGram(value);
		public static IHectoGram CreateHectoGram(double value) => slaveFactory.CreateHectoGram(value);
		public static IKiloGram CreateKiloGram(double value) => slaveFactory.CreateKiloGram(value);
		public static IMetricTonne CreateMetricTonne(double value) => slaveFactory.CreateMetricTonne(value);
		public static IMilliGram CreateMilliGram(double value) => slaveFactory.CreateMilliGram(value);
		public static IOunce CreateOunce(double value) => slaveFactory.CreateOunce(value);
		public static IPound CreatePound(double value) => slaveFactory.CreatePound(value);
		public static IStone CreateStone(double value) => slaveFactory.CreateStone(value);
		public static IUKLongTon CreateUKLongTon(double value) => slaveFactory.CreateUKLongTon(value);
		public static IUSShortTon CreateUSShortTon(double value) => slaveFactory.CreateUSShortTon(value);
		#endregion
		#region Power
		public static bool TryParse(string value, out IPower output) => slaveFactory.TryParse(value, out output);
		public static IBTUPerMinute CreateBTUPerMinute(double value) => slaveFactory.CreateBTUPerMinute(value);
		public static IFootPoundPerMinute CreateFootPoundPerMinute(double value) => slaveFactory.CreateFootPoundPerMinute(value);
		public static IKiloWatt CreateKiloWatt(double value) => slaveFactory.CreateKiloWatt(value);
		public static IUSHorsePower CreateUSHorsePower(double value) => slaveFactory.CreateUSHorsePower(value);
		public static IWatt CreateWatt(double value) => slaveFactory.CreateWatt(value);
		#endregion
		#region Pressure
		public static bool TryParse(string value, out IPressure output) => slaveFactory.TryParse(value, out output);
		public static IAtmosphere CreateAtmosphere(double value) => slaveFactory.CreateAtmosphere(value);
		public static IBar CreateBar(double value) => slaveFactory.CreateBar(value);
		public static IKiloPascal CreateKiloPascal(double value) => slaveFactory.CreateKiloPascal(value);
		public static IMilliMeterOfMercury CreateMilliMeterOfMercury(double value) => slaveFactory.CreateMilliMeterOfMercury(value);
		public static IPascal CreatePascal(double value) => slaveFactory.CreatePascal(value);
		public static IPoundPerSquareInch CreatePoundPerSquareInch(double value) => slaveFactory.CreatePoundPerSquareInch(value);
		#endregion
		#region Speed
		public static bool TryParse(string value, out ISpeed output) => slaveFactory.TryParse(value, out output);
		public static ICentiMeterPerSecond CreateCentiMeterPerSecond(double value) => slaveFactory.CreateCentiMeterPerSecond(value);
		public static IFootPerSecond CreateFootPerSecond(double value) => slaveFactory.CreateFootPerSecond(value);
		public static IKiloMeterPerHour CreateKiloMeterPerHour(double value) => slaveFactory.CreateKiloMeterPerHour(value);
		public static IKnot CreateKnot(double value) => slaveFactory.CreateKnot(value);
		public static IMachAtSeaLevel CreateMachAtSeaLevel(double value) => slaveFactory.CreateMachAtSeaLevel(value);
		public static IMeterPerSecond CreateMeterPerSecond(double value) => slaveFactory.CreateMeterPerSecond(value);
		public static IMilePerHour CreateMilePerHour(double value) => slaveFactory.CreateMilePerHour(value);
		public static IMilliMeterPerSecond CreateMilliMeterPerSecond(double value) => slaveFactory.CreateMilliMeterPerSecond(value);
		#endregion
		#region Temperature
		public static bool TryParse(string value, out ITemperature output) => slaveFactory.TryParse(value, out output);
		public static IDegreeCelsius CreateDegreeCelsius(double value) => slaveFactory.CreateDegreeCelsius(value);
		public static IDegreeFahrenheit CreateDegreeFahrenheit(double value) => slaveFactory.CreateDegreeFahrenheit(value);
		public static IDegreeKelvin CreateDegreeKelvin(double value) => slaveFactory.CreateDegreeKelvin(value);
		#endregion
		#region Volume
		public static bool TryParse(string value, out IVolume output) => slaveFactory.TryParse(value, out output);
		public static IFluidOunce CreateFluidOunce(double value) => slaveFactory.CreateFluidOunce(value);
		public static IUKGallon CreateUKGallon(double value) => slaveFactory.CreateUKGallon(value);
		public static IUKPint CreateUKPint(double value) => slaveFactory.CreateUKPint(value);
		public static IUKQuart CreateUKQuart(double value) => slaveFactory.CreateUKQuart(value);
		public static IUKTableSpoon CreateUKTableSpoon(double value) => slaveFactory.CreateUKTableSpoon(value);
		public static IUKTeaSpoon CreateUKTeaSpoon(double value) => slaveFactory.CreateUKTeaSpoon(value);

		public static ICup CreateCup(double value) => slaveFactory.CreateCup(value);
		public static IUSGallon CreateUSGallon(double value) => slaveFactory.CreateUSGallon(value);
		public static IUSPint CreateUSPint(double value) => slaveFactory.CreateUSPint(value);
		public static IUSQuart CreateUSQuart(double value) => slaveFactory.CreateUSQuart(value);
		public static IUSTableSpoon CreateUSTableSpoon(double value) => slaveFactory.CreateUSTableSpoon(value);
		public static IUSTeaSpoon CreateUSTeaSpoon(double value) => slaveFactory.CreateUSTeaSpoon(value);

		public static ICubicCentiMeter CreateCubicCentiMeter(double value) => slaveFactory.CreateCubicCentiMeter(value);
		public static ICubicFoot CreateCubicFoot(double value) => slaveFactory.CreateCubicFoot(value);
		public static ICubicInch CreateCubicInch(double value) => slaveFactory.CreateCubicInch(value);
		public static ICubicMeter CreateCubicMeter(double value) => slaveFactory.CreateCubicMeter(value);
		public static ICubicYard CreateCubicYard(double value) => slaveFactory.CreateCubicYard(value);
		public static ILitre CreateLitre(double value) => slaveFactory.CreateLitre(value);
		public static IMilliLitre CreateMilliLitre(double value) => slaveFactory.CreateMilliLitre(value);
		#endregion
		#endregion

		#region YSFlight
		public static IDATFile CreateDATFileReference(string filename) => slaveFactory.CreateDATFileReference(filename);
		public static ILSTFile CreateLSTFileReference(string filename) => slaveFactory.CreateLSTFileReference(filename);

		public static IYSTypeAircraftCategory CreateYSTypeAircraftCategory(string[] values) => slaveFactory.CreateYSTypeAircraftCategory(values);
		public static IYSTypeHardpointDescription CreateYSTypeHardpointDescription(string value) => slaveFactory.CreateYSTypeHardpointDescription(value);
		public static IYSTypeWeaponCategory CreateYSTypeWeaponCategory(string[] values) => slaveFactory.CreateYSTypeWeaponCategory(values);
		public static IYSTypeWeaponType CreateYSTypeWeaponType(string[] values) => slaveFactory.CreateYSTypeWeaponType(values);

		public static IMetaDataAircraft CreateMetaDataAircraft(string identify) => slaveFactory.CreateMetaDataAircraft(identify);
		public static IMetaDataGround CreateMetaDataGround(string identify) => slaveFactory.CreateMetaDataGround(identify);
		public static IMetaDataScenery CreateMetaDataScenery(string identify) => slaveFactory.CreateMetaDataScenery(identify);
		#endregion
	}
}
