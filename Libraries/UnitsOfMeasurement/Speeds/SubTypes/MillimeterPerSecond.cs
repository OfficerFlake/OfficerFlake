using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class MilliMeterPerSecond : Speed, IMilliMeterPerSecond
			{
				#region CTOR
				public MilliMeterPerSecond(double value) : base(value, Conversion.MilliMeterPerSecond, Suffixes.MilliMeterPerSecond) { }
				#endregion
				#region Operators
				public static MilliMeterPerSecond operator +(MilliMeterPerSecond firstMeasurement, MilliMeterPerSecond secondMeasurement)
				{
					return new MilliMeterPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MilliMeterPerSecond operator -(MilliMeterPerSecond firstMeasurement, MilliMeterPerSecond secondMeasurement)
				{
					return new MilliMeterPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MilliMeterPerSecond operator *(MilliMeterPerSecond firstMeasurement, MilliMeterPerSecond secondMeasurement)
				{
					return new MilliMeterPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MilliMeterPerSecond operator /(MilliMeterPerSecond firstMeasurement, MilliMeterPerSecond secondMeasurement)
				{
					return new MilliMeterPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MilliMeterPerSeconds
			public static MilliMeterPerSecond MilliMeterPerSeconds(this Byte input) => new MilliMeterPerSecond(input);
			public static MilliMeterPerSecond MilliMeterPerSeconds(this Int16 input) => new MilliMeterPerSecond(input);
			public static MilliMeterPerSecond MilliMeterPerSeconds(this Int32 input) => new MilliMeterPerSecond(input);
			public static MilliMeterPerSecond MilliMeterPerSeconds(this Int64 input) => new MilliMeterPerSecond(input);
			public static MilliMeterPerSecond MilliMeterPerSeconds(this Single input) => new MilliMeterPerSecond(input);
			public static MilliMeterPerSecond MilliMeterPerSeconds(this Double input) => new MilliMeterPerSecond(input);
			#endregion
		}
	}
}
