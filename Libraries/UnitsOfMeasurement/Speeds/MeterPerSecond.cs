using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class MeterPerSecond : Speed, IMeterPerSecond
			{
				#region CTOR
				public MeterPerSecond(double value) : base(value, Conversion.MeterPerSecond, Suffixes.MeterPerSecond) { }
				#endregion
				#region Operators
				public static MeterPerSecond operator +(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
				{
					return new MeterPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MeterPerSecond operator -(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
				{
					return new MeterPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MeterPerSecond operator *(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
				{
					return new MeterPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MeterPerSecond operator /(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
				{
					return new MeterPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MeterPerSeconds
			public static MeterPerSecond MeterPerSeconds(this Byte input) => new MeterPerSecond(input);
			public static MeterPerSecond MeterPerSeconds(this Int16 input) => new MeterPerSecond(input);
			public static MeterPerSecond MeterPerSeconds(this Int32 input) => new MeterPerSecond(input);
			public static MeterPerSecond MeterPerSeconds(this Int64 input) => new MeterPerSecond(input);
			public static MeterPerSecond MeterPerSeconds(this Single input) => new MeterPerSecond(input);
			public static MeterPerSecond MeterPerSeconds(this Double input) => new MeterPerSecond(input);
			#endregion
		}
	}
}
