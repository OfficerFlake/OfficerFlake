using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class MilliMeterOfMercury : Pressure, IMilliMeterOfMercury
			{
				#region CTOR
				public MilliMeterOfMercury(double value) : base(value, Conversion.MilliMeterOfMercury, Suffixes.MilliMeterOfMercury) { }
				#endregion
				#region Operators
				public static MilliMeterOfMercury operator +(MilliMeterOfMercury firstMeasurement, MilliMeterOfMercury secondMeasurement)
				{
					return new MilliMeterOfMercury((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MilliMeterOfMercury operator -(MilliMeterOfMercury firstMeasurement, MilliMeterOfMercury secondMeasurement)
				{
					return new MilliMeterOfMercury((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MilliMeterOfMercury operator *(MilliMeterOfMercury firstMeasurement, MilliMeterOfMercury secondMeasurement)
				{
					return new MilliMeterOfMercury((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MilliMeterOfMercury operator /(MilliMeterOfMercury firstMeasurement, MilliMeterOfMercury secondMeasurement)
				{
					return new MilliMeterOfMercury((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MilliMeterOfMercurys
			public static MilliMeterOfMercury MilliMeterOfMercurys(this Byte input) => new MilliMeterOfMercury(input);
			public static MilliMeterOfMercury MilliMeterOfMercurys(this Int16 input) => new MilliMeterOfMercury(input);
			public static MilliMeterOfMercury MilliMeterOfMercurys(this Int32 input) => new MilliMeterOfMercury(input);
			public static MilliMeterOfMercury MilliMeterOfMercurys(this Int64 input) => new MilliMeterOfMercury(input);
			public static MilliMeterOfMercury MilliMeterOfMercurys(this Single input) => new MilliMeterOfMercury(input);
			public static MilliMeterOfMercury MilliMeterOfMercurys(this Double input) => new MilliMeterOfMercury(input);
			#endregion
		}
	}
}
