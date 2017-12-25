using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Temperatures
		{
			public class DegreeKelvin : IDegreeKelvin
			{
				#region CTOR
				private double Value { get; set; }
				public DegreeKelvin(double value)
				{
					Value = value;
				}

				public IDegreeFahrenheit ToDegreeFahrenheit()
				{
					return new DegreeFahrenheit(((Value+273.15) * 9 / 5) + 32);
				}
				public IDegreeCelcius ToDegreeCelcius()
				{
					return new DegreeCelcius(Value + 273.15);
				}
				#endregion
				#region Operators
				public static DegreeKelvin operator +(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
				{
					return new DegreeKelvin(firstMeasurement.Value + secondMeasurement.Value);
				}
				public static DegreeKelvin operator -(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
				{
					return new DegreeKelvin(firstMeasurement.Value - secondMeasurement.Value);
				}
				public static DegreeKelvin operator *(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
				{
					return new DegreeKelvin(firstMeasurement.Value * secondMeasurement.Value);
				}
				public static DegreeKelvin operator /(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
				{
					return new DegreeKelvin(firstMeasurement.Value / secondMeasurement.Value);
				}
				#endregion
				public override string ToString()
				{
					return Value + "*K";
				}
			}
			#region [Number].DegreesKelvin
			public static DegreeKelvin DegreesKelvin(this Byte input) => new DegreeKelvin(input);
			public static DegreeKelvin DegreesKelvin(this Int16 input) => new DegreeKelvin(input);
			public static DegreeKelvin DegreesKelvin(this Int32 input) => new DegreeKelvin(input);
			public static DegreeKelvin DegreesKelvin(this Int64 input) => new DegreeKelvin(input);
			public static DegreeKelvin DegreesKelvin(this Single input) => new DegreeKelvin(input);
			public static DegreeKelvin DegreesKelvin(this Double input) => new DegreeKelvin(input);
			#endregion
		}
	}
}
