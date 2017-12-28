using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Temperatures
		{
			public class DegreeKelvin : Temperature, IDegreeKelvin
			{
				#region CTOR
				public DegreeKelvin(double value) : base(value){ }
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
