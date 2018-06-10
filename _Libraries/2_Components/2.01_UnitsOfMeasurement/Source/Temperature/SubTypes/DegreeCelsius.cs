using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Temperatures
		{
			public class DegreeCelsius : Temperature, IDegreeCelsius
			{
				#region CTOR
				public DegreeCelsius(double value) : base(value) { }
				#endregion
				#region Operators
				public static DegreeCelsius operator +(DegreeCelsius firstMeasurement, DegreeCelsius secondMeasurement)
				{
					return new DegreeCelsius(firstMeasurement.Value + secondMeasurement.Value);
				}
				public static DegreeCelsius operator -(DegreeCelsius firstMeasurement, DegreeCelsius secondMeasurement)
				{
					return new DegreeCelsius(firstMeasurement.Value - secondMeasurement.Value);
				}
				public static DegreeCelsius operator *(DegreeCelsius firstMeasurement, DegreeCelsius secondMeasurement)
				{
					return new DegreeCelsius(firstMeasurement.Value * secondMeasurement.Value);
				}
				public static DegreeCelsius operator /(DegreeCelsius firstMeasurement, DegreeCelsius secondMeasurement)
				{
					return new DegreeCelsius(firstMeasurement.Value / secondMeasurement.Value);
				}
				#endregion

				public new IDegreeFahrenheit ToDegreesFahrenheit()
				{
					return base.ToDegreesFahrenheit();
				}
				public new IDegreeKelvin ToDegreesKelvin()
				{
					return base.ToDegreesKelvin();
				}

				public override string ToString()
				{
					return Value + "*C";
				}
			}
			#region [Number].DegreesCelcius
			public static DegreeCelsius DegreesCelcius(this Byte input) => new DegreeCelsius(input);
			public static DegreeCelsius DegreesCelcius(this Int16 input) => new DegreeCelsius(input);
			public static DegreeCelsius DegreesCelcius(this Int32 input) => new DegreeCelsius(input);
			public static DegreeCelsius DegreesCelcius(this Int64 input) => new DegreeCelsius(input);
			public static DegreeCelsius DegreesCelcius(this Single input) => new DegreeCelsius(input);
			public static DegreeCelsius DegreesCelcius(this Double input) => new DegreeCelsius(input);
			#endregion
		}
	}
}
