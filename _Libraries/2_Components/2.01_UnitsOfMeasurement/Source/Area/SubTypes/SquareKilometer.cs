using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareKiloMeter : Area, ISquareKiloMeter
			{
				#region CTOR
				public SquareKiloMeter(double value) : base(value, Conversion.SquareKiloMeter, Suffixes.SquareKiloMeter) { }
				#endregion
				#region Operators
				public static SquareKiloMeter operator +(SquareKiloMeter firstMeasurement, SquareKiloMeter secondMeasurement)
				{
					return new SquareKiloMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareKiloMeter operator -(SquareKiloMeter firstMeasurement, SquareKiloMeter secondMeasurement)
				{
					return new SquareKiloMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareKiloMeter operator *(SquareKiloMeter firstMeasurement, SquareKiloMeter secondMeasurement)
				{
					return new SquareKiloMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareKiloMeter operator /(SquareKiloMeter firstMeasurement, SquareKiloMeter secondMeasurement)
				{
					return new SquareKiloMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareKiloMeters
			public static SquareKiloMeter SquareKiloMeters(this Byte input) => new SquareKiloMeter(input);
			public static SquareKiloMeter SquareKiloMeters(this Int16 input) => new SquareKiloMeter(input);
			public static SquareKiloMeter SquareKiloMeters(this Int32 input) => new SquareKiloMeter(input);
			public static SquareKiloMeter SquareKiloMeters(this Int64 input) => new SquareKiloMeter(input);
			public static SquareKiloMeter SquareKiloMeters(this Single input) => new SquareKiloMeter(input);
			public static SquareKiloMeter SquareKiloMeters(this Double input) => new SquareKiloMeter(input);
			#endregion
		}
	}
}
