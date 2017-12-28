using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class MillimeterPerSecond : Speed, IMillimeterPerSecond
			{
				#region CTOR
				public MillimeterPerSecond(double value) : base(value, Conversion.MillimeterPerSecond, Suffixes.MillimeterPerSecond) { }
				#endregion
				#region Operators
				public static MillimeterPerSecond operator +(MillimeterPerSecond firstMeasurement, MillimeterPerSecond secondMeasurement)
				{
					return new MillimeterPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MillimeterPerSecond operator -(MillimeterPerSecond firstMeasurement, MillimeterPerSecond secondMeasurement)
				{
					return new MillimeterPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MillimeterPerSecond operator *(MillimeterPerSecond firstMeasurement, MillimeterPerSecond secondMeasurement)
				{
					return new MillimeterPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MillimeterPerSecond operator /(MillimeterPerSecond firstMeasurement, MillimeterPerSecond secondMeasurement)
				{
					return new MillimeterPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MillimeterPerSeconds
			public static MillimeterPerSecond MillimeterPerSeconds(this Byte input) => new MillimeterPerSecond(input);
			public static MillimeterPerSecond MillimeterPerSeconds(this Int16 input) => new MillimeterPerSecond(input);
			public static MillimeterPerSecond MillimeterPerSeconds(this Int32 input) => new MillimeterPerSecond(input);
			public static MillimeterPerSecond MillimeterPerSeconds(this Int64 input) => new MillimeterPerSecond(input);
			public static MillimeterPerSecond MillimeterPerSeconds(this Single input) => new MillimeterPerSecond(input);
			public static MillimeterPerSecond MillimeterPerSeconds(this Double input) => new MillimeterPerSecond(input);
			#endregion
		}
	}
}
