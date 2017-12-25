using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Temperatures
		{
			public class DegreeCelcius : IDegreeCelcius
			{
				#region CTOR
				private double Value { get; set; }
				public DegreeCelcius(double value)
				{
					Value = value;
				}

				public IDegreeFahrenheit ToDegreeFahrenheit()
				{
					return new DegreeFahrenheit((Value*9/5)+32);
				}
				public IDegreeKelvin ToDegreeKelvin()
				{
					return new DegreeKelvin(Value-273.15);
				}
				#endregion
				#region Operators
				public static DegreeCelcius operator +(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
				{
					return new DegreeCelcius(firstMeasurement.Value + secondMeasurement.Value);
				}
				public static DegreeCelcius operator -(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
				{
					return new DegreeCelcius(firstMeasurement.Value - secondMeasurement.Value);
				}
				public static DegreeCelcius operator *(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
				{
					return new DegreeCelcius(firstMeasurement.Value * secondMeasurement.Value);
				}
				public static DegreeCelcius operator /(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
				{
					return new DegreeCelcius(firstMeasurement.Value / secondMeasurement.Value);
				}
				#endregion

				public override string ToString()
				{
					return Value + "*C";
				}
			}
			#region [Number].DegreesCelcius
			public static DegreeCelcius DegreesCelcius(this Byte input) => new DegreeCelcius(input);
			public static DegreeCelcius DegreesCelcius(this Int16 input) => new DegreeCelcius(input);
			public static DegreeCelcius DegreesCelcius(this Int32 input) => new DegreeCelcius(input);
			public static DegreeCelcius DegreesCelcius(this Int64 input) => new DegreeCelcius(input);
			public static DegreeCelcius DegreesCelcius(this Single input) => new DegreeCelcius(input);
			public static DegreeCelcius DegreesCelcius(this Double input) => new DegreeCelcius(input);
			#endregion
		}
	}
}
