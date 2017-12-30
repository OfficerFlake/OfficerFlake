using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class MilliMeter : Distance, IMilliMeter
			{
				#region CTOR
				public MilliMeter(double value) : base(value, Conversion.MilliMeter, Suffixes.MilliMeter) { }
				#endregion
				#region Operators
				public static MilliMeter operator +(MilliMeter firstMeasurement, MilliMeter secondMeasurement)
				{
					return new MilliMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MilliMeter operator -(MilliMeter firstMeasurement, MilliMeter secondMeasurement)
				{
					return new MilliMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MilliMeter operator *(MilliMeter firstMeasurement, MilliMeter secondMeasurement)
				{
					return new MilliMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MilliMeter operator /(MilliMeter firstMeasurement, MilliMeter secondMeasurement)
				{
					return new MilliMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MilliMeters
			public static MilliMeter MilliMeters(this Byte input) => new MilliMeter(input);
			public static MilliMeter MilliMeters(this Int16 input) => new MilliMeter(input);
			public static MilliMeter MilliMeters(this Int32 input) => new MilliMeter(input);
			public static MilliMeter MilliMeters(this Int64 input) => new MilliMeter(input);
			public static MilliMeter MilliMeters(this Single input) => new MilliMeter(input);
			public static MilliMeter MilliMeters(this Double input) => new MilliMeter(input);
			#endregion
		}
	}
}
