using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Com.OfficerFlake.Libraries.Color;
using Com.OfficerFlake.Libraries.Database;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Math;
using Com.OfficerFlake.Libraries.Math.CoordinateSystems;
using Com.OfficerFlake.Libraries.Math.Statistics;
using Com.OfficerFlake.Libraries.Networking;
using Com.OfficerFlake.Libraries.Networking.Packets;
using Com.OfficerFlake.Libraries.RichText;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight;
using Com.OfficerFlake.Libraries.YSFlight.Files.DAT;
using Com.OfficerFlake.Libraries.YSFlight.Files.LST;
using Com.OfficerFlake.Libraries.YSFlight.Types;

namespace Com.OfficerFlake.Libraries
{
	public static partial class MasterObjectFactory
	{
		private class _MasterObjectFactory : IObjectFactory
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
			public ISimpleColor CreateSimpleColor(IColor color, char colorCode) => new SimpleColor(color, colorCode);
			public IColor CreateColor(byte red, byte green, byte blue) => new XRGBColor(red, green, blue).GetColor();
			public IColor CreateColor(byte alpha, byte red, byte green, byte blue) => new ARGBColor(alpha, red, green, blue).GetColor();

			public IFormattingDescriptor CreateFormattingDescriptor(IColor backColor, IColor foreColor, Boolean isBold, Boolean isItallic, Boolean isUnderlined, Boolean isStrikeout, Boolean isObfuscated) => new FormattingDescriptor(backColor, foreColor, isBold, isItallic, isUnderlined, isStrikeout, isObfuscated);
			//Formatting

			#endregion
			#region Database
			//Group
			public IGroup CreateGroup(IRichTextString groupName) => new Group(groupName);
			//Permission
			public IPermissions CreatePermissions() => new Permissions();
			//Rank
			public IRank CreateRank(IRichTextString rankName) => new Rank(rankName);
			//User
			public IUser CreateUser(IRichTextString userName) => new User(userName);
			#endregion
			#region Math
			//Coordinates
			public ICoordinate2 CreateCoordinate2(IDistance x, IDistance y) => new Coordinate2(x,y);
			public ICoordinate3 CreateCoordinate3(IDistance x, IDistance y, IDistance z) => new Coordinate3(x,y,z);

			public IPoint2<T> CreatePoint2<T>(T x, T y) => new Point2<T>(x,y);
			public IPoint3<T> CreatePoint3<T>(T x, T y, T z) => new Point3<T>(x,y,z);
			public IVector2<T> CreateVector2<T>(T x, T y) => new Vector2<T>(x,y);
			public IVector3<T> CreateVector3<T>(T x, T y, T z) => new Vector3<T>(x,y,z);

			public IOrientation2 CreateOrientation2(IAngle h, IAngle p) => new Orientation2(h,p);
			public IOrientation3 CreateOrientation3(IAngle h, IAngle p, IAngle b) => new Orientation3(h,p,b);

			//Quadratic
			public IQuadraticEquation CreateQuadraticEquation(double result, double a, double b, double c) => new Equations.Quadratic(result, a, b, c);
			public IQuadraticEquation CreateQuadraticEquationFrom3Coordinate2(ICoordinate2 coordinate1, ICoordinate2 coordinate2, ICoordinate2 coordinate3) => CreateQuadraticEquationFrom3Coordinate2(coordinate1, coordinate2, coordinate3);
			public IQuadraticEquation CreateStatisticsCurve(double minimum, double center, double maximum) => Equations.Quadratic.StatisticCurve(minimum, center, maximum);
			//Statastic
			public IStatistic CreateStatsticTracker(string name) => new Statistic(name);
			#endregion
			#region Networking
			//Connection
			public IConnection CreateConnection(Socket TCPSocket, Boolean isProxyMode) => new Connection(TCPSocket, isProxyMode);

			//Packets
			public IPacket CreateGenericPacket() => new GenericPacket();
			public IPacket_01_Login CreatePacket01Login() => new Type_01_Login();
			public IPacket_03_Error CreatePacket03Error() => new Type_03_Error();
			public IPacket_04_Field CreatePacket04Field() => new Type_04_Field();
			public IPacket_05_AddVehicle CreatePacket05AddVehicle() => new Type_05_EntityJoined();
			public IPacket_06_Acknowledgement CreatePacket06Acknowledgement(params UInt32[] args) => new Type_06_Acknowledgement(args);
			public IPacket_07_SmokeColor CreatePacket07SmokeColor() => new Type_07_SmokeColor();
			public IPacket_08_JoinRequest CreatePacket08JoinRequest() => new Type_08_JoinRequest();
			public IPacket_09_JoinRequestApproved CreatePacket09JoinRequestApproved() => new Type_09_JoinApproved();
			public IPacket_10_JoinRequestDenied CreatePacket10JoinRequestDenied() => new Type_10_JoinDenied();
			public IPacket_11_FlightData CreatePacket11FlightData(Int16 version = 3) => new Type_11_FlightData(version);
			public IPacket_12_LeaveFlight CreatePacket12LeaveFlight() => new Type_12_Unjoin();
			public IPacket_13_RemoveAircraft CreatePacket13RemoveAircraft() => new Type_13_RemoveAircraft();
			public IPacket_16_PrepareSimulation CreatePacket16PrepareSimulation() => new Type_16_PrepareSimulation();
			public IPacket_17_HeartBeat CreatePacket17HeartBeat() => new Type_17_Heartbeat();
			public IPacket_18_LockOn CreatePacket18LockOn() => new Type_18_LockOn();
			public IPacket_19_RemoveGround CreatePacket19RemoveGround() => new Type_19_RemoveGround();
			public IPacket_20_OrdinanceSpawn CreatePacket20OrdinanceSpawn() => new Type_20_OrdinanceLaunched();
			public IPacket_21_GroundData CreatePacket21GroundData() => new Type_21_GroundData();
			public IPacket_22_Damage CreatePacket22Damage() => new Type_22_Damage();
			public IPacket_29_NetcodeVersion CreatePacket29NetcodeVersion() => new Type_29_NetcodeVersion();
			public IPacket_30_AircraftCommand CreatePacket30AircraftCommand() => throw new NotImplementedException();
			public IPacket_31_MissilesOption CreatePacket31MissilesOption() => new Type_31_MissilesOption();
			public IPacket_32_ChatMessage CreatePacket32ChatMessage(IUser user, string message) => new Type_32_ChatMessage(user, message);
			public IPacket_32_ServerMessage CreatePacket32ServerMessage(string message) => new Type_32_ServerMessage(message);
			public IPacket_33_Weather CreatePacket33Weather() => new Type_33_Weather();
			public IPacket_35_ReviveAllGrounds CreatePacket35ReviveAllGrounds() => new Type_35_ReviveAllGrounds();
			public IPacket_36_WeaponsLoadout CreatePacket36WeaponsLoadout() => new Type_36_WeaponsLoadout();
			public IPacket_37_ListUser CreatePacket37ListUser() => new Type_37_ListUser();
			public IPacket_38_QueryAirstate CreatePacket38QueryAirstate() => new Type_38_QueryAirstate();
			public IPacket_39_WeaponsOption CreatePacket39WeaponsOption() => new Type_39_WeaponsOption();
			public IPacket_41_UsernameDistance CreatePacket41UsernameDistance() => new Type_41_UsernameDistance();
			public IPacket_43_ServerCommand CreatePacket43ServerCommand() => new Type_43_ServerCommand();
			public IPacket_44_AircraftList CreatePacket44AircraftList() => new Type_44_AircraftList();
			public IPacket_45_GroundCommand CreatePacket45GroundCommand() => new Type_45_GroundCommand();
			public IPacket_47_ForceJoin CreatePacket47ForceJoin() => new Type_47_ForceJoin();
			public IPacket_48_FogColor CreatePacket48FogColor() => new Type_48_FogColor();
			public IPacket_49_SkyColor CreatePacket49SkyColor() => new Type_49_SkyColor();
			public IPacket_50_GroundColor CreatePacket50GroundColor() => new Type_50_GroundColor();

			//PacketProcessor

			//Server
			public Boolean ServerStart() => Networking.Server.Start();
			public Boolean ServerStop() => Networking.Server.Stop();
			#endregion
			#region RichText
			public IRichTextElement CreateRichTextElement(IFormattingDescriptor preFormmating) => new RichText.RichTextString.MessageElement(preFormmating);
			public IRichTextElement CreateRichTextElement(string unformattedString) => new RichText.RichTextString.MessageElement(unformattedString, SimpleColors.White, false, false, false, false, false);
			public IRichTextString CreateRichTextString(IFormattingDescriptor preFormmating) => new RichTextString(preFormmating);
			public IRichTextString CreateRichTextString(string formattedString) => new RichText.RichTextString(formattedString);
			public IRichTextMessage CreateRichTextMessage(IRichTextString richTextString) => new RichText.RichTextMessage(richTextString);

			public IConsoleUserMessage CreateConsoleUserMessage(IUser user, IRichTextString message) => new ConsoleUserMessage(user, message);
			public IConsoleInformationMessage CreateConsoleInformationMessage(IRichTextString message) => new ConsoleInformationMessage(message);

			public IDebugSummaryMessage CreateDebugSummaryMessage(IRichTextString message) => new DebugSummaryMessage(message);
			public IDebugDetailMessage CreateDebugDetailMessage(IRichTextString message) => new DebugDetailMessage(message);
			public IDebugWarningMessage CreateDebugWarningMessage(IRichTextString message) => new DebugWarningMessage(message);
			public IDebugErrorMessage CreateDebugErrorMessage(Exception e, IRichTextString message) => new DebugErrorMessage(e, message);
			public IDebugCrashMessage CreateDebugCrashMessage(Exception e, IRichTextString message) => new DebugCrashMessage(e, message);
			#endregion
			#region UnitsOfMeasurement
			#region Angle
			public bool TryParse(string value, out IAngle output) => Angle.TryParse(value, out output);
			public IDegree CreateDegree(double value) => new Angles.Degree(value);
			public IGradian CreateGradian(double value) => new Angles.Gradian(value);
			public IRadian CreateRadian(double value) => new Angles.Radian(value);
			#endregion
			#region Area
			public bool TryParse(string value, out IArea output) => Area.TryParse(value, out output);
			public IAcre CreateAcre(double value) => new Areas.Acre(value);
			public ISquareCentiMeter CreateSquareCentiMeter(double value) => new Areas.SquareCentiMeter(value);
			public ISquareFoot CreateSquareFoot(double value) => new Areas.SquareFoot(value);
			public ISquareInch CreateSquareInch(double value) => new Areas.SquareInch(value);
			public ISquareKiloMeter CreateSquareKiloMeter(double value) => new Areas.SquareKiloMeter(value);
			public ISquareMeter CreateSquareMeter(double value) => new Areas.SquareMeter(value);
			public ISquareMile CreateSquareMile(double value) => new Areas.SquareMile(value);
			public ISquareMilliMeter CreateSquareMilliMeter(double value) => new Areas.SquareMilliMeter(value);
			public ISquareNauticalMile CreateSquareNauticalMile(double value) => new Areas.SquareNauticalMile(value);
			public ISquareYard CreateSquareYard(double value) => new Areas.SquareYard(value);
			#endregion
			#region Distance
			public bool TryParse(string value, out IDistance output) => Distance.TryParse(value, out output);
			public ICentiMeter CreateCentiMeter(double value) => new Distances.CentiMeter(value);
			public IFoot CreateFoot(double value) => new Distances.Foot(value);
			public IInch CreateInch(double value) => new Distances.Inch(value);
			public IKiloMeter CreateKiloMeter(double value) => new Distances.KiloMeter(value);
			public IMeter CreateMeter(double value) => new Distances.Meter(value);
			public IMicron CreateMicron(double value) => new Distances.Micron(value);
			public IMile CreateMile(double value) => new Distances.Mile(value);
			public IMilliMeter CreateMilliMeter(double value) => new Distances.MilliMeter(value);
			public INanoMeter CreateNanoMeter(double value) => new Distances.NanoMeter(value);
			public INauticalMile CreateNauticalMile(double value) => new Distances.NauticalMile(value);
			public IYard CreateYard(double value) => new Distances.Yard(value);
			#endregion
			#region Duration
			public bool TryParse(string value, out IDuration output) => Duration.TryParse(value, out output);
			public ISecond CreateSecond(double value) => new Durations.Second(value);
			public IMinute CreateMinute(double value) => new Durations.Minute(value);
			public IHour CreateHour(double value) => new Durations.Hour(value);
			public IDay CreateDay(double value) => new Durations.Day(value);
			public IWeek CreateWeek(double value) => new Durations.Week(value);
			public IMonth CreateMonth(double value) => new Durations.Month(value);
			public IYear CreateYear(double value) => new Durations.Year(value);

			public IDate CreateDate(System.DateTime dateTime) => new OYSDate(dateTime);
			public ITime CreateTime(System.DateTime dateTime) => new OYSTime(dateTime);
			public IDateTime CreateDateTime(System.DateTime dateTime) => new OYSDateTime(dateTime);
			public ITimeSpan CreateTimeSpan(System.TimeSpan timeSpan) => new OYSTimeSpan(timeSpan);
			#endregion
			#region Energy
			public bool TryParse(string value, out IEnergy output) => Energy.TryParse(value, out output);
			public IBritishThermalUnit CreateBritishThermalUnit(double value) => new Energys.BritishThermalUnit(value);
			public IElectronVolt CreateElectronVolt(double value) => new Energys.ElectronVolt(value);
			public IFoodCalorie CreateFoodCalorie(double value) => new Energys.FoodCalorie(value);
			public IFootPound CreateFootPound(double value) => new Energys.FootPound(value);
			public IJoule CreateJoule(double value) => new Energys.Joule(value);
			public IKiloJoule CreateKiloJoule(double value) => new Energys.KiloJoule(value);
			public IThermalCalorie CreateThermalCalorie(double value) => new Energys.ThermalCalorie(value);
			#endregion
			#region Mass
			public bool TryParse(string value, out IMass output) => Mass.TryParse(value, out output);
			public ICarat CreateCarat(double value) => new Masses.Carat(value);
			public ICentiGram CreateCentiGram(double value) => new Masses.CentiGram(value);
			public IDecaGram CreateDecaGram(double value) => new Masses.DecaGram(value);
			public IDeciGram CreateDeciGram(double value) => new Masses.DeciGram(value);
			public IGram CreateGram(double value) => new Masses.Gram(value);
			public IHectoGram CreateHectoGram(double value) => new Masses.HectoGram(value);
			public IKiloGram CreateKiloGram(double value) => new Masses.KiloGram(value);
			public IMetricTonne CreateMetricTonne(double value) => new Masses.MetricTonne(value);
			public IMilliGram CreateMilliGram(double value) => new Masses.MilliGram(value);
			public IOunce CreateOunce(double value) => new Masses.Ounce(value);
			public IPound CreatePound(double value) => new Masses.Pound(value);
			public IStone CreateStone(double value) => new Masses.Stone(value);
			public IUKLongTon CreateUKLongTon(double value) => new Masses.UKLongTon(value);
			public IUSShortTon CreateUSShortTon(double value) => new Masses.USShortTon(value);
			#endregion
			#region Power
			public bool TryParse(string value, out IPower output) => Power.TryParse(value, out output);
			public IBTUPerMinute CreateBTUPerMinute(double value) => new Powers.BTUPerMinute(value); 
			public IFootPoundPerMinute CreateFootPoundPerMinute(double value) => new Powers.FootPoundPerMinute(value);
			public IKiloWatt CreateKiloWatt(double value) => new Powers.KiloWatt(value);
			public IUSHorsePower CreateUSHorsePower(double value) => new Powers.USHorsePower(value);
			public IWatt CreateWatt(double value) => new Powers.Watt(value);
			#endregion
			#region Pressure
			public bool TryParse(string value, out IPressure output) => Pressure.TryParse(value, out output);
			public IAtmosphere CreateAtmosphere(double value) => new Pressures.Atmosphere(value);
			public IBar CreateBar(double value) => new Pressures.Bar(value);
			public IKiloPascal CreateKiloPascal(double value) => new Pressures.KiloPascal(value);
			public IMilliMeterOfMercury CreateMilliMeterOfMercury(double value) => new Pressures.MilliMeterOfMercury(value);
			public IPascal CreatePascal(double value) => new Pressures.Pascal(value);
			public IPoundPerSquareInch CreatePoundPerSquareInch(double value) => new Pressures.PoundPerSquareInch(value);
			#endregion
			#region Speed
			public bool TryParse(string value, out ISpeed output) => Speed.TryParse(value, out output);
			public ICentiMeterPerSecond CreateCentiMeterPerSecond(double value) => new Speeds.CentiMeterPerSecond(value);
			public IFootPerSecond CreateFootPerSecond(double value) => new Speeds.FootPerSecond(value);
			public IKiloMeterPerHour CreateKiloMeterPerHour(double value) => new Speeds.KiloMeterPerHour(value);
			public IKnot CreateKnot(double value) => new Speeds.Knot(value);
			public IMachAtSeaLevel CreateMachAtSeaLevel(double value) => new Speeds.MachAtSeaLevel(value);
			public IMeterPerSecond CreateMeterPerSecond(double value) => new Speeds.MeterPerSecond(value);
			public IMilePerHour CreateMilePerHour(double value) => new Speeds.MilePerHour(value);
			public IMilliMeterPerSecond CreateMilliMeterPerSecond(double value) => new Speeds.MilliMeterPerSecond(value);
			#endregion
			#region Temperature
			public bool TryParse(string value, out ITemperature output) => Temperature.TryParse(value, out output);
			public IDegreeCelsius CreateDegreeCelsius(double value) => new Temperatures.DegreeCelsius(value);
			public IDegreeFahrenheit CreateDegreeFahrenheit(double value) => new Temperatures.DegreeFahrenheit(value);
			public IDegreeKelvin CreateDegreeKelvin(double value) => new Temperatures.DegreeKelvin(value);
			#endregion
			#region Volume
			public bool TryParse(string value, out IVolume output) => Volume.TryParse(value, out output);
			public IFluidOunce CreateFluidOunce(double value) => new Volumes.FluidOunce(value);
			public IUKGallon CreateUKGallon(double value) => new Volumes.UKGallon(value);
			public IUKPint CreateUKPint(double value) => new Volumes.UKPint(value);
			public IUKQuart CreateUKQuart(double value) => new Volumes.UKQuart(value);
			public IUKTableSpoon CreateUKTableSpoon(double value) => new Volumes.UKTableSpoon(value);
			public IUKTeaSpoon CreateUKTeaSpoon(double value) => new Volumes.UKTeaSpoon(value);

			public ICup CreateCup(double value) => new Volumes.Cup(value);
			public IUSGallon CreateUSGallon(double value) => new Volumes.USGallon(value);
			public IUSPint CreateUSPint(double value) => new Volumes.USPint(value);
			public IUSQuart CreateUSQuart(double value) => new Volumes.USQuart(value);
			public IUSTableSpoon CreateUSTableSpoon(double value) => new Volumes.USTableSpoon(value);
			public IUSTeaSpoon CreateUSTeaSpoon(double value) => new Volumes.USTeaSpoon(value);

			public ICubicCentiMeter CreateCubicCentiMeter(double value) => new Volumes.CubicCentiMeter(value);
			public ICubicFoot CreateCubicFoot(double value) => new Volumes.CubicFoot(value);
			public ICubicInch CreateCubicInch(double value) => new Volumes.CubicInch(value);
			public ICubicMeter CreateCubicMeter(double value) => new Volumes.CubicMeter(value);
			public ICubicYard CreateCubicYard(double value) => new Volumes.CubicYard(value);
			public ILitre CreateLitre(double value) => new Volumes.Litre(value);
			public IMilliLitre CreateMilliLitre(double value) => new Volumes.MilliLitre(value);
			#endregion
			#endregion
			#region YSFlight
			public IDATFile CreateDATFileReference(string filename) => new File(filename);
			public ILSTFile CreateLSTFileReference(string filename) => throw new NotImplementedException();

			public IYSTypeAircraftCategory CreateYSTypeAircraftCategory(string[] values) => new AircraftCategory(values);
			public IYSTypeHardpointDescription CreateYSTypeHardpointDescription(string value) => new HardPointDescription(value);
			public IYSTypeWeaponCategory CreateYSTypeWeaponCategory(string[] values) => new WeaponCategory(values);
			public IYSTypeWeaponType CreateYSTypeWeaponType(string[] values) => new WeaponType(values);

			public IMetaDataAircraft CreateMetaDataAircraft(string identify) => new Metadata.Aircraft(identify);
			public IMetaDataGround CreateMetaDataGround(string identify) => new Metadata.Ground(identify);
			public IMetaDataScenery CreateMetaDataScenery(string identify) => new Metadata.Scenery(identify);
			#endregion
		}
	}
}
