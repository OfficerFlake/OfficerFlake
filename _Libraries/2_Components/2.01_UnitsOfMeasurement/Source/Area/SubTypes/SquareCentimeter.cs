using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareCentiMeter : Area, ISquareCentiMeter
			{
				#region CTOR
				public SquareCentiMeter(double value) : base(value, Conversion.SquareCentiMeter, Suffixes.SquareCentiMeter) { }
				#endregion
				#region Operators
				public static SquareCentiMeter operator +(SquareCentiMeter firstMeasurement, SquareCentiMeter secondMeasurement)
				{
					return new SquareCentiMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareCentiMeter operator -(SquareCentiMeter firstMeasurement, SquareCentiMeter secondMeasurement)
				{
					return new SquareCentiMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareCentiMeter operator *(SquareCentiMeter firstMeasurement, SquareCentiMeter secondMeasurement)
				{
					return new SquareCentiMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareCentiMeter operator /(SquareCentiMeter firstMeasurement, SquareCentiMeter secondMeasurement)
				{
					return new SquareCentiMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareCentiMeters
			public static SquareCentiMeter SquareCentiMeters(this Byte input) => new SquareCentiMeter(input);
			public static SquareCentiMeter SquareCentiMeters(this Int16 input) => new SquareCentiMeter(input);
			public static SquareCentiMeter SquareCentiMeters(this Int32 input) => new SquareCentiMeter(input);
			public static SquareCentiMeter SquareCentiMeters(this Int64 input) => new SquareCentiMeter(input);
			public static SquareCentiMeter SquareCentiMeters(this Single input) => new SquareCentiMeter(input);
			public static SquareCentiMeter SquareCentiMeters(this Double input) => new SquareCentiMeter(input);
			#endregion
		}
	}
}
