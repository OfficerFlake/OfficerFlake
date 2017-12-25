using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class CubicMeter : Volume, ICubicMeter
			{
				#region CTOR
				public CubicMeter(double value) : base(value, Conversion.CubicMeter, Suffixes.CubicMeter) { }
				#endregion
				#region Operators
				public static CubicMeter operator +(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
				{
					return new CubicMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CubicMeter operator -(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
				{
					return new CubicMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CubicMeter operator *(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
				{
					return new CubicMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CubicMeter operator /(CubicMeter firstMeasurement, CubicMeter secondMeasurement)
				{
					return new CubicMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CubicMeters
			public static CubicMeter CubicMeters(this Byte input) => new CubicMeter(input);
			public static CubicMeter CubicMeters(this Int16 input) => new CubicMeter(input);
			public static CubicMeter CubicMeters(this Int32 input) => new CubicMeter(input);
			public static CubicMeter CubicMeters(this Int64 input) => new CubicMeter(input);
			public static CubicMeter CubicMeters(this Single input) => new CubicMeter(input);
			public static CubicMeter CubicMeters(this Double input) => new CubicMeter(input);
			#endregion
		}
	}
}
