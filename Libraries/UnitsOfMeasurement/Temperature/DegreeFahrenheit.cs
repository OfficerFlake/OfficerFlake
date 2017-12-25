using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Temperatures
		{
			public class DegreeFahrenheit : IDegreeFahrenheit
			{
				#region CTOR
				private double Value { get; set; }
				public DegreeFahrenheit(double value)
				{
					Value = value;
				}

				public IDegreeCelcius ToDegreeCelcius()
				{
					return new DegreeCelcius((Value-32) * 5 / 9);
				}
				public IDegreeKelvin ToDegreeKelvin()
				{
					return new DegreeKelvin(((Value - 32) * 5 / 9) - 273.15);
				}
				#endregion
				#region Operators
				public static DegreeFahrenheit operator +(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
				{
					return new DegreeFahrenheit(firstMeasurement.Value + secondMeasurement.Value);
				}
				public static DegreeFahrenheit operator -(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
				{
					return new DegreeFahrenheit(firstMeasurement.Value - secondMeasurement.Value);
				}
				public static DegreeFahrenheit operator *(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
				{
					return new DegreeFahrenheit(firstMeasurement.Value * secondMeasurement.Value);
				}
				public static DegreeFahrenheit operator /(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
				{
					return new DegreeFahrenheit(firstMeasurement.Value / secondMeasurement.Value);
				}
				#endregion
				public override string ToString()
				{
					return Value + "*F";
				}
			}
			#region [Number].DegreesFahrenheit
			public static DegreeFahrenheit DegreesFahrenheit(this Byte input) => new DegreeFahrenheit(input);
			public static DegreeFahrenheit DegreesFahrenheit(this Int16 input) => new DegreeFahrenheit(input);
			public static DegreeFahrenheit DegreesFahrenheit(this Int32 input) => new DegreeFahrenheit(input);
			public static DegreeFahrenheit DegreesFahrenheit(this Int64 input) => new DegreeFahrenheit(input);
			public static DegreeFahrenheit DegreesFahrenheit(this Single input) => new DegreeFahrenheit(input);
			public static DegreeFahrenheit DegreesFahrenheit(this Double input) => new DegreeFahrenheit(input);
			#endregion
		}
	}
}
