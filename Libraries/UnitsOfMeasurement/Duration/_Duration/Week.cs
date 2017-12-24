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
	            public Week(double value) : base(value, Conversion.Week, "W") { }
	            #endregion
	            #region Operators
	            public static Week operator +(Week firstMeasurement, Week secondMeasurement)
	            {
		            return new Week((firstMeasurement.RawValue + secondMeasurement.RawValue));
	            }
	            public static Week operator -(Week firstMeasurement, Week secondMeasurement)
	            {
		            return new Week((firstMeasurement.RawValue - secondMeasurement.RawValue));
	            }
	            public static bool operator >(Week firstMeasurement, Week secondMeasurement)
	            {
		            return firstMeasurement.RawValue > secondMeasurement.RawValue;
	            }
	            public static bool operator <(Week firstMeasurement, Week secondMeasurement)
	            {
		            return firstMeasurement.RawValue < secondMeasurement.RawValue;
	            }
	            #endregion
			}

			public static Week ToWeeks(this Duration input) => new Week(input.ConvertToBase());

            public static Week Weeks(this byte input) => new Week(input);
            public static Week Weeks(this short input) => new Week(input);
            public static Week Weeks(this int input) => new Week(input);
            public static Week Weeks(this long input) => new Week(input);

            public static Week Weeks(this float input) => new Week((double)input);
            public static Week Weeks(this double input) => new Week((double)input);
        }
    }
}
