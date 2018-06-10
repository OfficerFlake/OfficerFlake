using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareMilliMeter : Area, ISquareMilliMeter
			{
				#region CTOR
				public SquareMilliMeter(double value) : base(value, Conversion.SquareMilliMeter, Suffixes.SquareMilliMeter) { }
				#endregion
				#region Operators
				public static SquareMilliMeter operator +(SquareMilliMeter firstMeasurement, SquareMilliMeter secondMeasurement)
				{
					return new SquareMilliMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareMilliMeter operator -(SquareMilliMeter firstMeasurement, SquareMilliMeter secondMeasurement)
				{
					return new SquareMilliMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareMilliMeter operator *(SquareMilliMeter firstMeasurement, SquareMilliMeter secondMeasurement)
				{
					return new SquareMilliMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareMilliMeter operator /(SquareMilliMeter firstMeasurement, SquareMilliMeter secondMeasurement)
				{
					return new SquareMilliMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareMilliMeters
			public static SquareMilliMeter SquareMilliMeters(this Byte input) => new SquareMilliMeter(input);
			public static SquareMilliMeter SquareMilliMeters(this Int16 input) => new SquareMilliMeter(input);
			public static SquareMilliMeter SquareMilliMeters(this Int32 input) => new SquareMilliMeter(input);
			public static SquareMilliMeter SquareMilliMeters(this Int64 input) => new SquareMilliMeter(input);
			public static SquareMilliMeter SquareMilliMeters(this Single input) => new SquareMilliMeter(input);
			public static SquareMilliMeter SquareMilliMeters(this Double input) => new SquareMilliMeter(input);
			#endregion
		}
	}
}
