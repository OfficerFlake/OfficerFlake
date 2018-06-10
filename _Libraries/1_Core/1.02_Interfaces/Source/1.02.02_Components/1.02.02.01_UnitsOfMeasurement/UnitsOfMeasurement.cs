using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	//UnitsOfMeasurement
	public interface IUnitOfMeasurement
	{
		double RawValue { get; set; }
		double ConversionRatio { get; set; }

		string ToString();
	}
	#region Angle
	public interface IAngle : IUnitOfMeasurement
	{
		IDegree ToDegrees();
		IGradian ToGradians();
		IRadian ToRadians();
	}
	public interface IDegree : IAngle
	{
	}
	public interface IGradian : IAngle
	{

	}
	public interface IRadian : IAngle
	{

	}
	#endregion
	#region Area
	public interface IArea : IUnitOfMeasurement
	{
		IAcre ToAcres();
		ISquareCentiMeter ToSquareCentiMeters();
		ISquareFoot ToSquareFeet();
		ISquareInch ToSquareInches();
		ISquareKiloMeter ToSquareKiloMeters();
		ISquareMeter ToSquareMeters();
		ISquareMile ToSquareMiles();
		ISquareMilliMeter ToSquareMilliMeters();
		ISquareNauticalMile ToSquareNauticalMiles();
		ISquareYard ToSquareYards();
	}
	public interface IAcre : IArea
	{
	}
	public interface ISquareCentiMeter : IArea
	{
	}
	public interface ISquareFoot : IArea
	{
	}
	public interface ISquareInch : IArea
	{
	}
	public interface ISquareKiloMeter : IArea
	{
	}
	public interface ISquareMeter : IArea
	{
	}
	public interface ISquareMile : IArea
	{
	}
	public interface ISquareMilliMeter : IArea
	{
	}
	public interface ISquareNauticalMile : IArea
	{
	}
	public interface ISquareYard : IArea
	{
	}
	#endregion Area
	#region Distance
	public interface IDistance : IUnitOfMeasurement
	{
		ICentiMeter ToCentiMeters();
		IFoot ToFeet();
		IInch ToInches();
		IKiloMeter ToKiloMeters();
		IMeter ToMeters();
		IMicron ToMicrons();
		IMile ToMiles();
		IMilliMeter ToMilliMeters();
		INanoMeter ToNanoMeters();
		INauticalMile ToNauticalMiles();
		IYard ToYards();
	}
	public interface ICentiMeter : IDistance
	{
		
	}
	public interface IFoot : IDistance
	{

	}
	public interface IInch : IDistance
	{

	}
	public interface IKiloMeter : IDistance
	{

	}
	public interface IMeter : IDistance
	{

	}
	public interface IMicron : IDistance
	{

	}
	public interface IMile : IDistance
	{

	}
	public interface IMilliMeter : IDistance
	{

	}
	public interface INanoMeter : IDistance
	{

	}
	public interface INauticalMile : IDistance
	{

	}
	public interface IYard : IDistance
	{

	}
	#endregion
	#region Duration
	public interface IDuration : IUnitOfMeasurement
	{
		ISecond ToSeconds();
		IMinute ToMinutes();
		IHour ToHours();
		IDay ToDays();
		IWeek ToWeeks();
		IMonth ToMonths();
		IYear ToYears();
	}
	public interface ISecond : IDuration
	{
	}
	public interface IMinute : IDuration
	{
	}
	public interface IHour : IDuration
	{
	}
	public interface IDay : IDuration
	{
	}
	public interface IWeek : IDuration
	{
	}
	public interface IMonth : IDuration
	{
	}
	public interface IYear : IDuration
	{
	}

	public interface IDate
	{
		IYear Year { get; set; }
		IMonth Month { get; set; }
		IDay Day { get; set; }

		DateTime ToSystemDateTime();
		string ToSystemString();
	}
	public interface ITime
	{
		IHour Hour { get; set; }
		IMinute Minute { get; set; }
		ISecond Second { get; set; }

		DateTime ToSystemDateTime();
		string ToSystemString();
	}
	public interface IDateTime
	{
		IYear Year { get; set; }
		IMonth Month { get; set; }
		IDay Day { get; set; }
		IHour Hour { get; set; }
		IMinute Minute { get; set; }
		ISecond Second { get; set; }

		DateTime ToSystemDateTime();
		string ToSystemString();
	}
	public interface ITimeSpan
	{
		IYear Years { get; set; }
		IMonth Months { get; set; }
		IWeek Weeks { get; set; }
		IDay Days { get; set; }
		IHour Hours { get; set; }
		IMinute Minutes { get; set; }
		ISecond Seconds { get; set; }

		IYear TotalYears();
		IMonth TotalMonths();
		IWeek TotalWeeks();
		IDay TotalDays();
		IHour TotalHours();
		IMinute TotalMinutes();
		ISecond TotalSeconds();

		TimeSpan ToSystemTimeSpan();
		string ToSystemString();
	}
	#endregion
	#region Energy
	public interface IEnergy : IUnitOfMeasurement
	{
		IBritishThermalUnit ToBritishThermalUnits();
		IElectronVolt ToElectronVolts();
		IFoodCalorie ToFoodCalories();
		IFootPound ToFootPounds();
		IJoule ToJoules();
		IKiloJoule ToKiloJoules();
		IThermalCalorie ToThermalCalories();
	}
	public interface IBritishThermalUnit : IEnergy
	{
	}
	public interface IElectronVolt : IEnergy
	{
	}
	public interface IFoodCalorie : IEnergy
	{
	}
	public interface IFootPound : IEnergy
	{
	}
	public interface IJoule : IEnergy
	{
	}
	public interface IKiloJoule : IEnergy
	{
	}
	public interface IThermalCalorie : IEnergy
	{
	}
	#endregion
	#region Mass
	public interface IMass : IUnitOfMeasurement
	{
		ICarat ToCarats();
		ICentiGram ToCentiGrams();
		IDecaGram ToDecaGrams();
		IGram ToGrams();
		IHectoGram ToHectoGrams();
		IKiloGram ToKiloGrams();
		IMetricTonne ToMetricTonnes();
		IOunce ToOunces();
		IPound ToPounds();
		IStone ToStones();
		IUKLongTon TUKLongTons();
		IUSShortTon TUSShortTons();
	}
	public interface ICarat : IMass
	{
	}
	public interface ICentiGram : IMass
	{
	}
	public interface IDecaGram : IMass
	{
	}
	public interface IDeciGram : IMass
	{
	}
	public interface IGram : IMass
	{
	}
	public interface IHectoGram : IMass
	{
	}
	public interface IKiloGram : IMass
	{
	}
	public interface IMetricTonne : IMass
	{
	}
	public interface IMilliGram : IMass
	{
	}
	public interface IOunce : IMass
	{
	}
	public interface IPound : IMass
	{
	}
	public interface IStone : IMass
	{
	}
	public interface IUKLongTon : IMass
	{
	}
	public interface IUSShortTon : IMass
	{
	}
	#endregion
	#region Power
	public interface IPower : IUnitOfMeasurement
	{
		IBTUPerMinute ToBTUsPerMinute();
		IFootPoundPerMinute ToFootPoundsPerMinute();
		IKiloWatt ToKiloWatts();
		IUSHorsePower ToUSHorsePower();
		IWatt ToWatts();
	}
	public interface IBTUPerMinute : IPower { }
	public interface IFootPoundPerMinute : IPower { }
	public interface IKiloWatt : IPower { }
	public interface IUSHorsePower : IPower { }
	public interface IWatt : IPower { }
	#endregion
	#region Pressure
	public interface IPressure : IUnitOfMeasurement
	{
		IAtmosphere ToAtmospheres();
		IBar ToBars();
		IKiloPascal ToKiloPascals();
		IMilliMeterOfMercury ToMilliMetersOfMercury();
		IPascal ToPascals();
		IPoundPerSquareInch ToPoundsPerSquareInch();
	}
	public interface IAtmosphere : IPressure { }
	public interface IBar : IPressure { }
	public interface IKiloPascal : IPressure { }
	public interface IMilliMeterOfMercury : IPressure { }
	public interface IPascal : IPressure { }
	public interface IPoundPerSquareInch : IPressure { }
	#endregion
	#region Speed
	public interface ISpeed : IUnitOfMeasurement
	{
		ICentiMeterPerSecond ToCentiMetersPerSecond();
		IFootPerSecond ToFeetPerSecond();
		IKiloMeterPerHour ToKiloMetersPerHour();
		IKnot ToKnots();
		IMachAtSeaLevel ToMachAtSeaLevel();
		IMeterPerSecond ToMetersPerSecond();
		IMilePerHour ToMilesPerHour();
		IMilliMeterPerSecond ToMilliMetersPerSecond();
	}
	public interface ICentiMeterPerSecond : ISpeed { }
	public interface IFootPerSecond : ISpeed { }
	public interface IKiloMeterPerHour : ISpeed { }
	public interface IKnot : ISpeed { }
	public interface IMachAtSeaLevel : ISpeed { }
	public interface IMeterPerSecond : ISpeed { }
	public interface IMilePerHour : ISpeed { }
	public interface IMilliMeterPerSecond : ISpeed { }
	#endregion
	#region Temperature
	public interface ITemperature
	{
		double Value { get; set; }

		IDegreeCelsius ToDegreesCelsius();
		IDegreeFahrenheit ToDegreesFahrenheit();
		IDegreeKelvin ToDegreesKelvin();
	}
	public interface IDegreeCelsius : ITemperature
	{
		new IDegreeFahrenheit ToDegreesFahrenheit();
		new IDegreeKelvin ToDegreesKelvin();
	}
	public interface IDegreeFahrenheit : ITemperature
	{
		new IDegreeCelsius ToDegreesCelsius();
		new IDegreeKelvin ToDegreesKelvin();

	}
	public interface IDegreeKelvin : ITemperature
	{
		new IDegreeCelsius ToDegreesCelsius();
		new IDegreeFahrenheit ToDegreesFahrenheit();
	}
	#endregion
	#region Volume
	public interface IVolume : IUnitOfMeasurement
	{
		IFluidOunce ToFluidOunces();
		IUKGallon ToUKGallons();
		IUKPint ToUKPints();
		IUKQuart ToUKQuarts();
		IUKTableSpoon ToUKTableSpoons();
		IUKTeaSpoon ToUKTeaSpoons();

		ICup ToCups();
		IUSGallon ToUSGallons();
		IUSPint ToUSPints();
		IUSQuart ToUSQuarts();
		IUSTableSpoon ToUSTableSpoons();
		IUSTeaSpoon ToUSTeaSpoons();

		ICubicCentiMeter ToCubicCentiMeters();
		ICubicFoot ToCubicFeet();
		ICubicInch ToCubicInches();
		ICubicMeter ToCubicMeters();
		ICubicYard ToCubicYards();

		ILitre ToLitres();
		IMilliLitre ToMilliLitres();
	}
	#region UK
	public interface IFluidOunce : IVolume { }
	public interface IUKGallon : IVolume { }
	public interface IUKPint : IVolume { }
	public interface IUKQuart : IVolume { }
	public interface IUKTableSpoon : IVolume { }
	public interface IUKTeaSpoon : IVolume { }
	#endregion
	#region US
	public interface ICup : IVolume { }
	public interface IUSGallon : IVolume { }
	public interface IUSPint : IVolume { }
	public interface IUSQuart : IVolume { }
	public interface IUSTableSpoon : IVolume { }
	public interface IUSTeaSpoon : IVolume { }
	#endregion
	public interface ICubicCentiMeter : IVolume { }
	public interface ICubicFoot : IVolume { }
	public interface ICubicInch : IVolume { }
	public interface ICubicMeter : IVolume { }
	public interface ICubicYard : IVolume { }
	public interface ILitre : IVolume { }
	public interface IMilliLitre : IVolume { }
	#endregion
}
