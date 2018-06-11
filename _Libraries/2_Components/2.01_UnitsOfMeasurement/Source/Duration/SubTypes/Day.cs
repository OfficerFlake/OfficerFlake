using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Day : Duration, IDay
			{
				#region CTOR
				public Day(double value) : base(value, Conversion.Day, Suffixes.Day) { }
				#endregion
				#region Operators
				public static Day operator +(Day firstMeasurement, Day secondMeasurement)
				{
					return new Day((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Day operator -(Day firstMeasurement, Day secondMeasurement)
				{
					return new Day((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Day operator *(Day firstMeasurement, Day secondMeasurement)
				{
					return new Day((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Day operator /(Day firstMeasurement, Day secondMeasurement)
				{
					return new Day((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Days
			public static Day Days(Byte input) => new Day(input);
			public static Day Days(Int16 input) => new Day(input);
			public static Day Days(Int32 input) => new Day(input);
			public static Day Days(Int64 input) => new Day(input);
			public static Day Days(Single input) => new Day(input);
			public static Day Days(Double input) => new Day(input);
			#endregion
		}
	}
}
