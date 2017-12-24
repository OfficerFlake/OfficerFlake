using System.Globalization;
using Com.OfficerFlake.Libraries.Extensions;
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
				public Day(double value) : base(value, Conversion.Day, "D") { }
				#endregion
				#region Operators
				public static Day operator +(Day firstMeasurement, Day secondMeasurement)
                {
                    return new Day((firstMeasurement.RawValue + secondMeasurement.RawValue));
                }
                public static Day operator -(Day firstMeasurement, Day secondMeasurement)
                {
					return new Day((firstMeasurement.RawValue - secondMeasurement.RawValue));
				}
                public static bool operator >(Day firstMeasurement, Day secondMeasurement)
                {
	                return firstMeasurement.RawValue > secondMeasurement.RawValue;
                }
                public static bool operator <(Day firstMeasurement, Day secondMeasurement)
                {
					return firstMeasurement.RawValue < secondMeasurement.RawValue;
				}
				#endregion
			}

            public static Day ToDays(this Duration input) => new Day(input.ConvertToBase());

            public static Day Days(this byte input) => new Day(input);
            public static Day Days(this short input) => new Day(input);
            public static Day Days(this int input) => new Day(input);
            public static Day Days(this long input) => new Day(input);

            public static Day Days(this float input) => new Day((double)input);
            public static Day Days(this double input) => new Day((double)input);
        }
    }
}
