using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Week : Duration, IWeek
			{
				#region CTOR
				public Week(double value) : base(value, Conversion.Week, Suffixes.Week) { }
				#endregion
				#region Operators
				public static Week operator +(Week firstMeasurement, Week secondMeasurement)
				{
					return new Week((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Week operator -(Week firstMeasurement, Week secondMeasurement)
				{
					return new Week((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Week operator *(Week firstMeasurement, Week secondMeasurement)
				{
					return new Week((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Week operator /(Week firstMeasurement, Week secondMeasurement)
				{
					return new Week((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Weeks
			public static Week Weeks(this Byte input) => new Week(input);
			public static Week Weeks(this Int16 input) => new Week(input);
			public static Week Weeks(this Int32 input) => new Week(input);
			public static Week Weeks(this Int64 input) => new Week(input);
			public static Week Weeks(this Single input) => new Week(input);
			public static Week Weeks(this Double input) => new Week(input);
			#endregion
		}
	}
}
