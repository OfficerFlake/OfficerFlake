using System;
using System.Net;
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

		//COMPONENTS
		#region Color
		public static ISimpleColor CreateSimpleColor(IColor color, char colorCode) => objectFactory.CreateSimpleColor(color, colorCode);
		public static IColor CreateColor(byte red, byte green, byte blue) => objectFactory.CreateColor(red, green, blue);
		public static IColor CreateColor(byte alpha, byte red, byte green, byte blue) => objectFactory.CreateColor(alpha, red, green, blue);

		public static IFormattingDescriptor CreateFormattingDescriptor(IColor backColor, IColor foreColor, Boolean isBold, Boolean isItallic, Boolean isUnderlined, Boolean isStrikeout, Boolean isObfuscated) => objectFactory.CreateFormattingDescriptor(backColor, foreColor, isBold, isItallic, isUnderlined, isStrikeout,isObfuscated);
		#endregion
		#region Database
		//Group
		public static IGroup CreateGroup(IRichTextString groupName) => objectFactory.CreateGroup(groupName);

		//Permissions
		public static IPermissions CreatePermissions() => objectFactory.CreatePermissions();

		//Rank
		public static IRank CreateRank(IRichTextString rankName) => objectFactory.CreateRank(rankName);

		//User
		public static IUser CreateUser(IRichTextString userName) => objectFactory.CreateUser(userName);
		#endregion
		#region Math
		//Coordinates

		public static IPoint2<T> CreatePoint2<T>(T x, T y) => objectFactory.CreatePoint2<T>(x, y);
		public static IPoint3<T> CreatePoint3<T>(T x, T y, T z) => objectFactory.CreatePoint3<T>(x, y, z);
		public static IVector2<T> CreateVector2<T>(T x, T y) => objectFactory.CreateVector2<T>(x, y);
		public static IVector3<T> CreateVector3<T>(T x, T y, T z) => objectFactory.CreateVector3<T>(x, y, z);

		public static ICoordinate2 CreateCoordinate2(IDistance x, IDistance y) => objectFactory.CreateCoordinate2(x, y);
		public static ICoordinate3 CreateCoordinate3(IDistance x, IDistance y, IDistance z) => objectFactory.CreateCoordinate3(x, y, z);
		public static IOrientation2 CreateOrientation2(IAngle h, IAngle p) => objectFactory.CreateOrientation2(h, p);
		public static IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b) => objectFactory.CreateOrientation3(h, p, b);

		//Quadratics
		public static IQuadraticEquation CreateQuadraticEquation(double result, double x, double a, double b, double c) => objectFactory.CreateQuadraticEquation(result, a, b, c);
		public static IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3) => objectFactory.CreateQuadraticEquationFrom3Coordinate2(coordinate1, coordinate2, coordinate3);
		public static IQuadraticEquation CreateStatisticsCurve(double minimum, double center, double maximum) =>objectFactory.CreateStatisticsCurve(minimum, center, maximum);

		//Statistics
		public static IStatistic CreateStatsticTracker(string name) => objectFactory.CreateStatsticTracker(name);
		#endregion
		#region Networking
		//Connection
		public static IConnection CreateConnection() => objectFactory.CreateConnection();

		//HostAddress
		public static IHostAddress CreateHostAddress(IPAddress IP) => objectFactory.CreateHostAddress(IP);
		public static IHostAddress CreateHostAddress(string DomainName) => objectFactory.CreateHostAddress(DomainName);

		//Packets
		public static IPacket CreateGenericPacket() => objectFactory.CreateGenericPacket();
		public static IPacket_00_Null CreatePacket00Null() => objectFactory.CreatePacket00Null();
		public static IPacket_01_Login CreatePacket01Login() => objectFactory.CreatePacket01Login();
		public static IPacket_02_Logoff CreatePacket02Logoff() => objectFactory.CreatePacket02Logoff();
		public static IPacket_03_Error CreatePacket03Error() => objectFactory.CreatePacket03Error();
		public static IPacket_04_Field CreatePacket04Field() => objectFactory.CreatePacket04Field();
		public static IPacket_05_AddVehicle CreatePacket05AddVehicle() => objectFactory.CreatePacket05AddVehicle();
		public static IPacket_06_Acknowledgement CreatePacket06Acknowledgement(params UInt32[] args) => objectFactory.CreatePacket06Acknowledgement(args);
		public static IPacket_07_SmokeColor CreatePacket07SmokeColor() => objectFactory.CreatePacket07SmokeColor();
		public static IPacket_08_JoinRequest CreatePacket08JoinRequest() => objectFactory.CreatePacket08JoinRequest();
		public static IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved() => objectFactory.CreatePacket09JoinRequestApproved();
		public static IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied() => objectFactory.CreatePacket10JoinRequestDenied();
		public static IPacket_11_FlightData CreatePacket11FlightData(Int16 version = 3) => objectFactory.CreatePacket11FlightData(version);
		public static IPacket_12_LeaveFlight CreatePacket12LeaveFlight() => objectFactory.CreatePacket12LeaveFlight();
		public static IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft() => objectFactory.CreatePacket13RemoveAircraft();
		public static IPacket_14_RequestTestAirplane CreatePacket14RequestTestAirplane() => objectFactory.CreatePacket14RequestTestAirplane();
		public static IPacket_15_KillServer CreatePacket15KillServer() => objectFactory.CreatePacket15KillServer();
		public static IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation() => objectFactory.CreatePacket16PrepareSimulation();
		public static IPacket_17_HeartBeat CreatePacket17HeartBeat() => objectFactory.CreatePacket17HeartBeat();
		public static IPacket_18_LockOn CreatePacket18LockOn() => objectFactory.CreatePacket18LockOn();
		public static IPacket_19_RemoveGround CreatePacket19RemoveGround() => objectFactory.CreatePacket19RemoveGround();
		public static IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn() => objectFactory.CreatePacket20OrdinanceSpawn();
		public static IPacket_21_GroundData CreatePacket21GroundData() => objectFactory.CreatePacket21GroundData();
		public static IPacket_22_Damage CreatePacket22Damage() => objectFactory.CreatePacket22Damage();
		public static IPacket_23_GroundTurretState CreatePacket23GroundTurretState() => objectFactory.CreatePacket23GroundTurretState();
		public static IPacket_24_SetTestAutoPilot CreatePacket24SetTestAutoPilot() => objectFactory.CreatePacket24SetTestAutoPilot();
		public static IPacket_25_RequestToBeSideWindowOfServer CreatePacket25RequestToBeSideWindowOfServer() => objectFactory.CreatePacket25RequestToBeSideWindowOfServer();
		public static IPacket_26_AssignSideWindow CreatePacket26AssignSideWindow() => objectFactory.CreatePacket26AssignSideWindow();
		public static IPacket_27_ResendAirRequest CreatePacket27ResendAirRequest() => objectFactory.CreatePacket27ResendAirRequest();
		public static IPacket_28_ResendGroundRequest CreatePacket28ResendGroundRequest() => objectFactory.CreatePacket28ResendGroundRequest();
		public static IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion() => objectFactory.CreatePacket29NetcodeVersion();
		public static IPacket_30_AircraftCommand CreatePacket30AircraftCommand() => objectFactory.CreatePacket30AircraftCommand();
		public static IPacket_31_MissilesOption CreatePacket31MissilesOption() => objectFactory.CreatePacket31MissilesOption();
		public static IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message) => objectFactory.CreatePacket32ChatMessage(user, message);
		public static IPacket_32_ServerMessage CreatePacket32ServerMessage(string message) => objectFactory.CreatePacket32ServerMessage(message);
		public static IPacket_33_Weather CreatePacket33Weather() => objectFactory.CreatePacket33Weather();
		public static IPacket_34_NeedResendJoinApproval CreatePacket34NeedResendJoinApproval() => objectFactory.CreatePacket34NeedResendJoinApproval();
		public static IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds() => objectFactory.CreatePacket35ReviveAllGrounds();
		public static IPacket_36_WeaponsLoadout CreatePacket36WeaponsLoadout() => objectFactory.CreatePacket36WeaponsLoadout();
		public static IPacket_37_ListUser CreatePacket37ListUser() => objectFactory.CreatePacket37ListUser();
		public static IPacket_38_QueryAirstate CreatePacket38QueryAirstate() => objectFactory.CreatePacket38QueryAirstate();
		public static IPacket_39_WeaponsOption CreatePacket39WeaponsOption() => objectFactory.CreatePacket39WeaponsOption();
		public static IPacket_40_AirTurretState CreatePacket40AirTurretState() => objectFactory.CreatePacket40AirTurretState();
		public static IPacket_41_UsernameDistance CreatePacket41UsernameDistance() => objectFactory.CreatePacket41UsernameDistance();
		public static IPacket_42_ConfirmExistence CreatePacket42ConfirmExistence() => objectFactory.CreatePacket42ConfirmExistence();
		public static IPacket_43_ServerCommand CreatePacket43ServerCommand() => objectFactory.CreatePacket43ServerCommand();
		public static IPacket_44_AircraftList CreatePacket44AircraftList() => objectFactory.CreatePacket44AircraftList();
		public static IPacket_45_GroundCommand CreatePacket45GroundCommand() => objectFactory.CreatePacket45GroundCommand();
		public static IPacket_46_ReportScore CreatePacket46ReportScore() => objectFactory.CreatePacket46ReportScore();
		public static IPacket_47_ForceJoin CreatePacket47ForceJoin() => objectFactory.CreatePacket47ForceJoin();
		public static IPacket_48_FogColor CreatePacket48FogColor() => objectFactory.CreatePacket48FogColor();
		public static IPacket_49_SkyColor CreatePacket49SkyColor() => objectFactory.CreatePacket49SkyColor();
		public static IPacket_50_GroundColor CreatePacket50GroundColor() => objectFactory.CreatePacket50GroundColor();
		public static IPacket_64_UserPacket CreatePacket64UserPacket() => objectFactory.CreatePacket64UserPacket();
		public static IPacket_64_00_Null CreatePacket64_00Null() => objectFactory.CreatePacket64_00Null();
		public static IPacket_64_01_OYSVersion CreatePacket64_01OYSVersion() => objectFactory.CreatePacket64_01OYSVersion();
		public static IPacket_64_11_FormationFlightData CreatePacket64_11FormationFlightData(short version) => objectFactory.CreatePacket64_11FormationFlightData(version);

		//PacketProcessor

		//Server
		public static Boolean ServerStart() => objectFactory.ServerStart();
		public static Boolean ServerStop() => objectFactory.ServerStop();
		public static ITimeSpan ServerUpTime => objectFactory.ServerUpTime;
		#endregion
		#region RichText
		public static IRichTextElement CreateRichTextElement(IFormattingDescriptor preformatting) => objectFactory.CreateRichTextElement(preformatting);
		public static IRichTextElement CreateRichTextElement(string unformattedString) => objectFactory.CreateRichTextElement(unformattedString);
		public static IRichTextString CreateRichTextString(IFormattingDescriptor preformatting) => objectFactory.CreateRichTextString(preformatting);
		public static IRichTextString CreateRichTextString(string formattedString) =>objectFactory.CreateRichTextString(formattedString);
		public static IRichTextMessage CreateRichTextMessage(IRichTextString richTextString) => objectFactory.CreateRichTextMessage(richTextString);

		public static IConsoleUserMessage CreateConsoleUserMessage(IUser user, IRichTextString message) => objectFactory.CreateConsoleUserMessage(user, message);
		public static IConsoleInformationMessage CreateConsoleInformationMessage(IRichTextString message) => objectFactory.CreateConsoleInformationMessage(message);

		public static IDebugSummaryMessage CreateDebugSummaryMessage(IRichTextString message) => objectFactory.CreateDebugSummaryMessage(message);
		public static IDebugDetailMessage CreateDebugDetailMessage(IRichTextString message) => objectFactory.CreateDebugDetailMessage(message);
		public static IDebugWarningMessage CreateDebugWarningMessage(IRichTextString message) => objectFactory.CreateDebugWarningMessage(message);

		public static IDebugErrorMessage CreateDebugErrorMessage(Exception e, IRichTextString message) => objectFactory.CreateDebugErrorMessage(e, message);
		public static IDebugCrashMessage CreateDebugCrashMessage(Exception e, IRichTextString message) => objectFactory.CreateDebugCrashMessage(e, message);
		#endregion
		#region UnitsOfMeasurement
		#region Angle
		public static bool TryParse(string value, out IAngle output) => objectFactory.TryParse(value, out output);
		public static IDegree CreateDegree(double value) => objectFactory.CreateDegree(value);
		public static IGradian CreateGradian(double value) => objectFactory.CreateGradian(value);
		public static IRadian CreateRadian(double value) => objectFactory.CreateRadian(value);
		#endregion
		#region Area
		public static bool TryParse(string value, out IArea output) => objectFactory.TryParse(value, out output);
		public static IAcre CreateAcre(double value) => objectFactory.CreateAcre(value);
		public static ISquareCentiMeter CreateSquareCentiMeter(double value) => objectFactory.CreateSquareCentiMeter(value);
		public static ISquareFoot CreateSquareFoot(double value) => objectFactory.CreateSquareFoot(value);
		public static ISquareInch CreateSquareInch(double value) => objectFactory.CreateSquareInch(value);
		public static ISquareKiloMeter CreateSquareKiloMeter(double value) => objectFactory.CreateSquareKiloMeter(value);
		public static ISquareMeter CreateSquareMeter(double value) => objectFactory.CreateSquareMeter(value);
		public static ISquareMile CreateSquareMile(double value) => objectFactory.CreateSquareMile(value);
		public static ISquareMilliMeter CreateSquareMilliMeter(double value) => objectFactory.CreateSquareMilliMeter(value);
		public static ISquareNauticalMile CreateSquareNauticalMile(double value) => objectFactory.CreateSquareNauticalMile(value);
		public static ISquareYard CreateSquareYard(double value) => objectFactory.CreateSquareYard(value);
		#endregion
		#region Distance
		public static bool TryParse(string value, out IDistance output) => objectFactory.TryParse(value, out output);
		public static ICentiMeter CreateCentiMeter(double value) => objectFactory.CreateCentiMeter(value);
		public static IFoot CreateFoot(double value) => objectFactory.CreateFoot(value);
		public static IInch CreateInch(double value) => objectFactory.CreateInch(value);
		public static IKiloMeter CreateKiloMeter(double value) => objectFactory.CreateKiloMeter(value);
		public static IMeter CreateMeter(double value) => objectFactory.CreateMeter(value);
		public static IMicron CreateMicron(double value) => objectFactory.CreateMicron(value);
		public static IMile CreateMile(double value) => objectFactory.CreateMile(value);
		public static IMilliMeter CreateMilliMeter(double value) => objectFactory.CreateMilliMeter(value);
		public static INanoMeter CreateNanoMeter(double value) => objectFactory.CreateNanoMeter(value);
		public static INauticalMile CreateNauticalMile(double value) => objectFactory.CreateNauticalMile(value);
		public static IYard CreateYard(double value) => objectFactory.CreateYard(value);
		#endregion
		#region Duration
		public static bool TryParse(string value, out IDuration output) => objectFactory.TryParse(value, out output);
		public static ISecond CreateSecond(double value) => objectFactory.CreateSecond(value);
		public static IMinute CreateMinute(double value) => objectFactory.CreateMinute(value);
		public static IHour CreateHour(double value) => objectFactory.CreateHour(value);
		public static IDay CreateDay(double value) => objectFactory.CreateDay(value);
		public static IWeek CreateWeek(double value) => objectFactory.CreateWeek(value);
		public static IMonth CreateMonth(double value) => objectFactory.CreateMonth(value);
		public static IYear CreateYear(double value) => objectFactory.CreateYear(value);

		public static IDate CreateDate(System.DateTime date) => objectFactory.CreateDate(date);
		public static IDate CreateDate(string date) => objectFactory.CreateDate(date);
		public static ITime CreateTime(System.DateTime time) => objectFactory.CreateTime(time);
		public static ITime CreateTime(string time) => objectFactory.CreateTime(time);
		public static IDateTime CreateDateTime(System.DateTime dateTime) => objectFactory.CreateDateTime(dateTime);
		public static IDateTime CreateDateTime(string dateTime) => objectFactory.CreateDateTime(dateTime);
		public static ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan) => objectFactory.CreateTimeSpan(timeSpan);
		public static ITimeSpan CreateTimeSpan(string timeSpan) => objectFactory.CreateTimeSpan(timeSpan);
		#endregion
		#region Energy
		public static bool TryParse(string value, out IEnergy output) => objectFactory.TryParse(value, out output);
		public static IBritishThermalUnit CreateBritishThermalUnit(double value) => objectFactory.CreateBritishThermalUnit(value);
		public static IElectronVolt CreateElectronVolt(double value) => objectFactory.CreateElectronVolt(value);
		public static IFoodCalorie CreateFoodCalorie(double value) => objectFactory.CreateFoodCalorie(value);
		public static IFootPound CreateFootPound(double value) => objectFactory.CreateFootPound(value);
		public static IJoule CreateJoule(double value) => objectFactory.CreateJoule(value);
		public static IKiloJoule CreateKiloJoule(double value) => objectFactory.CreateKiloJoule(value);
		public static IThermalCalorie CreateThermalCalorie(double value) => objectFactory.CreateThermalCalorie(value);
		#endregion
		#region Mass
		public static bool TryParse(string value, out IMass output) => objectFactory.TryParse(value, out output);
		public static ICarat CreateCarat(double value) => objectFactory.CreateCarat(value);
		public static ICentiGram CreateCentiGram(double value) => objectFactory.CreateCentiGram(value);
		public static IDecaGram CreateDecaGram(double value) => objectFactory.CreateDecaGram(value);
		public static IDeciGram CreateDeciGram(double value) => objectFactory.CreateDeciGram(value);
		public static IGram CreateGram(double value) => objectFactory.CreateGram(value);
		public static IHectoGram CreateHectoGram(double value) => objectFactory.CreateHectoGram(value);
		public static IKiloGram CreateKiloGram(double value) => objectFactory.CreateKiloGram(value);
		public static IMetricTonne CreateMetricTonne(double value) => objectFactory.CreateMetricTonne(value);
		public static IMilliGram CreateMilliGram(double value) => objectFactory.CreateMilliGram(value);
		public static IOunce CreateOunce(double value) => objectFactory.CreateOunce(value);
		public static IPound CreatePound(double value) => objectFactory.CreatePound(value);
		public static IStone CreateStone(double value) => objectFactory.CreateStone(value);
		public static IUKLongTon CreateUKLongTon(double value) => objectFactory.CreateUKLongTon(value);
		public static IUSShortTon CreateUSShortTon(double value) => objectFactory.CreateUSShortTon(value);
		#endregion
		#region Power
		public static bool TryParse(string value, out IPower output) => objectFactory.TryParse(value, out output);
		public static IBTUPerMinute CreateBTUPerMinute(double value) => objectFactory.CreateBTUPerMinute(value);
		public static IFootPoundPerMinute CreateFootPoundPerMinute(double value) => objectFactory.CreateFootPoundPerMinute(value);
		public static IKiloWatt CreateKiloWatt(double value) => objectFactory.CreateKiloWatt(value);
		public static IUSHorsePower CreateUSHorsePower(double value) => objectFactory.CreateUSHorsePower(value);
		public static IWatt CreateWatt(double value) => objectFactory.CreateWatt(value);
		#endregion
		#region Pressure
		public static bool TryParse(string value, out IPressure output) => objectFactory.TryParse(value, out output);
		public static IAtmosphere CreateAtmosphere(double value) => objectFactory.CreateAtmosphere(value);
		public static IBar CreateBar(double value) => objectFactory.CreateBar(value);
		public static IKiloPascal CreateKiloPascal(double value) => objectFactory.CreateKiloPascal(value);
		public static IMilliMeterOfMercury CreateMilliMeterOfMercury(double value) => objectFactory.CreateMilliMeterOfMercury(value);
		public static IPascal CreatePascal(double value) => objectFactory.CreatePascal(value);
		public static IPoundPerSquareInch CreatePoundPerSquareInch(double value) => objectFactory.CreatePoundPerSquareInch(value);
		#endregion
		#region Speed
		public static bool TryParse(string value, out ISpeed output) => objectFactory.TryParse(value, out output);
		public static ICentiMeterPerSecond CreateCentiMeterPerSecond(double value) => objectFactory.CreateCentiMeterPerSecond(value);
		public static IFootPerSecond CreateFootPerSecond(double value) => objectFactory.CreateFootPerSecond(value);
		public static IKiloMeterPerHour CreateKiloMeterPerHour(double value) => objectFactory.CreateKiloMeterPerHour(value);
		public static IKnot CreateKnot(double value) => objectFactory.CreateKnot(value);
		public static IMachAtSeaLevel CreateMachAtSeaLevel(double value) => objectFactory.CreateMachAtSeaLevel(value);
		public static IMeterPerSecond CreateMeterPerSecond(double value) => objectFactory.CreateMeterPerSecond(value);
		public static IMilePerHour CreateMilePerHour(double value) => objectFactory.CreateMilePerHour(value);
		public static IMilliMeterPerSecond CreateMilliMeterPerSecond(double value) => objectFactory.CreateMilliMeterPerSecond(value);
		#endregion
		#region Temperature
		public static bool TryParse(string value, out ITemperature output) => objectFactory.TryParse(value, out output);
		public static IDegreeCelsius CreateDegreeCelsius(double value) => objectFactory.CreateDegreeCelsius(value);
		public static IDegreeFahrenheit CreateDegreeFahrenheit(double value) => objectFactory.CreateDegreeFahrenheit(value);
		public static IDegreeKelvin CreateDegreeKelvin(double value) => objectFactory.CreateDegreeKelvin(value);
		#endregion
		#region Volume
		public static bool TryParse(string value, out IVolume output) => objectFactory.TryParse(value, out output);
		public static IFluidOunce CreateFluidOunce(double value) => objectFactory.CreateFluidOunce(value);
		public static IUKGallon CreateUKGallon(double value) => objectFactory.CreateUKGallon(value);
		public static IUKPint CreateUKPint(double value) => objectFactory.CreateUKPint(value);
		public static IUKQuart CreateUKQuart(double value) => objectFactory.CreateUKQuart(value);
		public static IUKTableSpoon CreateUKTableSpoon(double value) => objectFactory.CreateUKTableSpoon(value);
		public static IUKTeaSpoon CreateUKTeaSpoon(double value) => objectFactory.CreateUKTeaSpoon(value);

		public static ICup CreateCup(double value) => objectFactory.CreateCup(value);
		public static IUSGallon CreateUSGallon(double value) => objectFactory.CreateUSGallon(value);
		public static IUSPint CreateUSPint(double value) => objectFactory.CreateUSPint(value);
		public static IUSQuart CreateUSQuart(double value) => objectFactory.CreateUSQuart(value);
		public static IUSTableSpoon CreateUSTableSpoon(double value) => objectFactory.CreateUSTableSpoon(value);
		public static IUSTeaSpoon CreateUSTeaSpoon(double value) => objectFactory.CreateUSTeaSpoon(value);

		public static ICubicCentiMeter CreateCubicCentiMeter(double value) => objectFactory.CreateCubicCentiMeter(value);
		public static ICubicFoot CreateCubicFoot(double value) => objectFactory.CreateCubicFoot(value);
		public static ICubicInch CreateCubicInch(double value) => objectFactory.CreateCubicInch(value);
		public static ICubicMeter CreateCubicMeter(double value) => objectFactory.CreateCubicMeter(value);
		public static ICubicYard CreateCubicYard(double value) => objectFactory.CreateCubicYard(value);
		public static ILitre CreateLitre(double value) => objectFactory.CreateLitre(value);
		public static IMilliLitre CreateMilliLitre(double value) => objectFactory.CreateMilliLitre(value);
		#endregion
		#endregion

		#region YSFlight
		public static IDATFile CreateDATFileReference(string filename) => objectFactory.CreateDATFileReference(filename);
		public static ILSTFile CreateLSTFileReference(string filename) => objectFactory.CreateLSTFileReference(filename);

		public static IYSTypeAircraftCategory CreateYSTypeAircraftCategory(string[] values) => objectFactory.CreateYSTypeAircraftCategory(values);
		public static IYSTypeHardpointDescription CreateYSTypeHardpointDescription(string value) => objectFactory.CreateYSTypeHardpointDescription(value);
		public static IYSTypeWeaponCategory CreateYSTypeWeaponCategory(string[] values) => objectFactory.CreateYSTypeWeaponCategory(values);
		public static IYSTypeWeaponType CreateYSTypeWeaponType(string[] values) => objectFactory.CreateYSTypeWeaponType(values);

		public static IWorldVehicle CreateVehicle() => objectFactory.CreateVehicle();
		public static IWorldAircraft CreateAircraft() => objectFactory.CreateAircraft();
		public static IWorldGround CreateGround() => objectFactory.CreateGround();

		public static IMetaDataAircraft CreateMetaDataAircraft(string identify) => objectFactory.CreateMetaDataAircraft(identify);
		public static IMetaDataGround CreateMetaDataGround(string identify) => objectFactory.CreateMetaDataGround(identify);
		public static IMetaDataScenery CreateMetaDataScenery(string identify) => objectFactory.CreateMetaDataScenery(identify);
		#endregion
	}
}
