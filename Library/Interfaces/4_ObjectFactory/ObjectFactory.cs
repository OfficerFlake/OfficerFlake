using System;
using System.Collections.Generic;
using System.Net.Sockets;

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
		#region 3_FileIO
		IFile CreateFileReference(string filename);
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
		ISimpleColor CreateSimpleColor(IColor color, char colorCode);
		IColor CreateColor(byte red, byte green, byte blue);
		IColor CreateColor(byte alpha, byte red, byte green, byte blue);

		//Formatting
		IFormattingDescriptor CreateFormattingDescriptor(IColor backColor, IColor foreColor, Boolean isBold, Boolean isItallic, Boolean isUnderlined, Boolean isStrikeout, Boolean isObfuscated);

		#endregion
		#region Database
		//Group
		IGroup CreateGroup(IRichTextString groupName);
		//Permission
		IPermissions CreatePermissions();
		//Rank
		IRank CreateRank(IRichTextString rankName);
		//User
		IUser CreateUser(IRichTextString userName);
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
		IQuadraticEquation CreateQuadraticEquation(double result, double a, double b, double c);
		IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3);
		IQuadraticEquation CreateStatisticsCurve(double minimum, double center, double maximum);

		//Statastic
		IStatistic CreateStatsticTracker(string name);
		#endregion
		#region Networking
		//Connection
		IConnection CreateConnection(Socket TCPSocket);

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

		//Server
		Boolean ServerStart();
		Boolean ServerStop();
		#endregion
		#region RichText
		IRichTextElement CreateRichTextElement(IFormattingDescriptor preFormmating);
		IRichTextElement CreateRichTextElement(string unformattedString);
		IRichTextString CreateRichTextString(IFormattingDescriptor preFormmating);
		IRichTextString CreateRichTextString(string formattedString);
		IRichTextMessage CreateRichTextMessage(IRichTextString richTextString);

		IConsoleUserMessage CreateConsoleUserMessage(IUser user, IRichTextString message);
		IConsoleInformationMessage CreateConsoleInformationMessage(IRichTextString message);

		IDebugSummaryMessage CreateDebugSummaryMessage(IRichTextString message);
		IDebugDetailMessage CreateDebugDetailMessage(IRichTextString message);
		IDebugWarningMessage CreateDebugWarningMessage(IRichTextString message);
		IDebugErrorMessage CreateDebugErrorMessage(Exception e, IRichTextString message);
		IDebugCrashMessage CreateDebugCrashMessage(Exception e, IRichTextString message);
		#endregion

		#region UnitsOfMeasurement
		#region Angle
		bool TryParse(string value, out IAngle output);
		IDegree CreateDegree(double value);
		IGradian CreateGradian(double value);
		IRadian CreateRadian(double value);
		#endregion
		#region Area
		bool TryParse(string value, out IArea output);
		IAcre CreateAcre(double value);
		ISquareCentiMeter CreateSquareCentiMeter(double value);
		ISquareFoot CreateSquareFoot(double value);
		ISquareInch CreateSquareInch(double value);
		ISquareKiloMeter CreateSquareKiloMeter(double value);
		ISquareMeter CreateSquareMeter(double value);
		ISquareMile CreateSquareMile(double value);
		ISquareMilliMeter CreateSquareMilliMeter(double value);
		ISquareNauticalMile CreateSquareNauticalMile(double value);
		ISquareYard CreateSquareYard(double value);
		#endregion
		#region Distance
		bool TryParse(string value, out IDistance output);
		ICentiMeter CreateCentiMeter(double value);
		IFoot CreateFoot(double value);
		IInch CreateInch(double value);
		IKiloMeter CreateKiloMeter(double value);
		IMeter CreateMeter(double value);
		IMicron CreateMicron(double value);
		IMile CreateMile(double value);
		IMilliMeter CreateMilliMeter(double value);
		INanoMeter CreateNanoMeter(double value);
		INauticalMile CreateNauticalMile(double value);
		IYard CreateYard(double value);
		#endregion
		#region Duration
		bool TryParse(string value, out IDuration output);
		ISecond CreateSecond(double value);
		IMinute CreateMinute(double value);
		IHour CreateHour(double value);
		IDay CreateDay(double value);
		IWeek CreateWeek(double value);
		IMonth CreateMonth(double value);
		IYear CreateYear(double value);

		IDate CreateDate(System.DateTime dateTime);
		ITime CreateTime(System.DateTime dateTime);
		IDateTime CreateDateTime(System.DateTime dateTime);
		ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan);
		#endregion
		#region Energy
		bool TryParse(string value, out IEnergy output);
		IBritishThermalUnit CreateBritishThermalUnit(double value);
		IElectronVolt CreateElectronVolt(double value);
		IFoodCalorie CreateFoodCalorie(double value);
		IFootPound CreateFootPound(double value);
		IJoule CreateJoule(double value);
		IKiloJoule CreateKiloJoule(double value);
		IThermalCalorie CreateThermalCalorie(double value);
		#endregion
		#region Mass
		bool TryParse(string value, out IMass output);
		ICarat CreateCarat(double value);
		ICentiGram CreateCentiGram(double value);
		IDecaGram CreateDecaGram(double value);
		IDeciGram CreateDeciGram(double value);
		IGram CreateGram(double value);
		IHectoGram CreateHectoGram(double value);
		IKiloGram CreateKiloGram(double value);
		IMetricTonne CreateMetricTonne(double value);
		IMilliGram CreateMilliGram(double value);
		IOunce CreateOunce(double value);
		IPound CreatePound(double value);
		IStone CreateStone(double value);
		IUKLongTon CreateUKLongTon(double value);
		IUSShortTon CreateUSShortTon(double value);
		#endregion
		#region Power
		bool TryParse(string value, out IPower output);
		IBTUPerMinute CreateBTUPerMinute(double value);
		IFootPoundPerMinute CreateFootPoundPerMinute(double value);
		IKiloWatt CreateKiloWatt(double value);
		IUSHorsePower CreateUSHorsePower(double value);
		IWatt CreateWatt(double value);
		#endregion
		#region Pressure
		bool TryParse(string value, out IPressure output);
		IAtmosphere CreateAtmosphere(double value);
		IBar CreateBar(double value);
		IKiloPascal CreateKiloPascal(double value);
		IMilliMeterOfMercury CreateMilliMeterOfMercury(double value);
		IPascal CreatePascal(double value);
		IPoundPerSquareInch CreatePoundPerSquareInch(double value);
		#endregion
		#region Speed
		bool TryParse(string value, out ISpeed output);
		ICentiMeterPerSecond CreateCentiMeterPerSecond(double value);
		IFootPerSecond CreateFootPerSecond(double value);
		IKiloMeterPerHour CreateKiloMeterPerHour(double value);
		IKnot CreateKnot(double value);
		IMachAtSeaLevel CreateMachAtSeaLevel(double value);
		IMeterPerSecond CreateMeterPerSecond(double value);
		IMilePerHour CreateMilePerHour(double value);
		IMilliMeterPerSecond CreateMilliMeterPerSecond(double value);
		#endregion
		#region Temperature
		bool TryParse(string value, out ITemperature output);
		IDegreeCelsius CreateDegreeCelsius(double value);
		IDegreeFahrenheit CreateDegreeFahrenheit(double value);
		IDegreeKelvin CreateDegreeKelvin(double value);
		#endregion
		#region Volume
		bool TryParse(string value, out IVolume output);
		IFluidOunce CreateFluidOunce(double value);
		IUKGallon CreateUKGallon(double value);
		IUKPint CreateUKPint(double value);
		IUKQuart CreateUKQuart(double value);
		IUKTableSpoon CreateUKTableSpoon(double value);
		IUKTeaSpoon CreateUKTeaSpoon(double value);

		ICup CreateCup(double value);
		IUSGallon CreateUSGallon(double value);
		IUSPint CreateUSPint(double value);
		IUSQuart CreateUSQuart(double value);
		IUSTableSpoon CreateUSTableSpoon(double value);
		IUSTeaSpoon CreateUSTeaSpoon(double value);

		ICubicCentiMeter CreateCubicCentiMeter(double value);
		ICubicFoot CreateCubicFoot(double value);
		ICubicInch CreateCubicInch(double value);
		ICubicMeter CreateCubicMeter(double value);
		ICubicYard CreateCubicYard(double value);
		ILitre CreateLitre(double value);
		IMilliLitre CreateMilliLitre(double value);
		#endregion
		#endregion

		#region YSFlight
		IDATFile CreateDATFileReference(string filename);
		ILSTFile CreateLSTFileReference(string filename);

		IYSTypeAircraftCategory CreateYSTypeAircraftCategory(string[] values);
		IYSTypeHardpointDescription CreateYSTypeHardpointDescription(string value);
		IYSTypeWeaponCategory CreateYSTypeWeaponCategory(string[] values);
		IYSTypeWeaponType CreateYSTypeWeaponType(string[] values);

		IMetaDataAircraft CreateMetaDataAircraft(string identify);
		IMetaDataGround CreateMetaDataGround(string identify);
		IMetaDataScenery CreateMetaDataScenery(string identify);
		#endregion
	}
}
