using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class CubicCentiMeter : Volume, ICubicCentiMeter
			{
				#region CTOR
				public CubicCentiMeter(double value) : base(value, Conversion.CubicCentiMeter, Suffixes.CubicCentiMeter) { }
				#endregion
				#region Operators
				public static CubicCentiMeter operator +(CubicCentiMeter firstMeasurement, CubicCentiMeter secondMeasurement)
				{
					return new CubicCentiMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CubicCentiMeter operator -(CubicCentiMeter firstMeasurement, CubicCentiMeter secondMeasurement)
				{
					return new CubicCentiMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CubicCentiMeter operator *(CubicCentiMeter firstMeasurement, CubicCentiMeter secondMeasurement)
				{
					return new CubicCentiMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CubicCentiMeter operator /(CubicCentiMeter firstMeasurement, CubicCentiMeter secondMeasurement)
				{
					return new CubicCentiMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CubicCentiMeters
			public static CubicCentiMeter CubicCentiMeters(this Byte input) => new CubicCentiMeter(input);
			public static CubicCentiMeter CubicCentiMeters(this Int16 input) => new CubicCentiMeter(input);
			public static CubicCentiMeter CubicCentiMeters(this Int32 input) => new CubicCentiMeter(input);
			public static CubicCentiMeter CubicCentiMeters(this Int64 input) => new CubicCentiMeter(input);
			public static CubicCentiMeter CubicCentiMeters(this Single input) => new CubicCentiMeter(input);
			public static CubicCentiMeter CubicCentiMeters(this Double input) => new CubicCentiMeter(input);
			#endregion
		}
	}
}
