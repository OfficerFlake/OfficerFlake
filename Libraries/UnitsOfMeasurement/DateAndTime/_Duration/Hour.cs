using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Hour : Duration, IHour
            {
				#region CTOR
	            public Hour(double value) : base(value, Conversion.Hour, "h") { }
	            #endregion
	            #region Operators
	            public static Hour operator +(Hour firstMeasurement, Hour secondMeasurement)
	            {
		            return new Hour((firstMeasurement.RawValue + secondMeasurement.RawValue));
	            }
	            public static Hour operator -(Hour firstMeasurement, Hour secondMeasurement)
	            {
		            return new Hour((firstMeasurement.RawValue - secondMeasurement.RawValue));
	            }
	            public static bool operator >(Hour firstMeasurement, Hour secondMeasurement)
	            {
		            return firstMeasurement.RawValue > secondMeasurement.RawValue;
	            }
	            public static bool operator <(Hour firstMeasurement, Hour secondMeasurement)
	            {
		            return firstMeasurement.RawValue < secondMeasurement.RawValue;
	            }
	            #endregion
			}

			public static Hour ToHours(this Duration input) => new Hour(input.ConvertToBase());

            public static Hour Hours(this byte input) => new Hour(input);
            public static Hour Hours(this short input) => new Hour(input);
            public static Hour Hours(this int input) => new Hour(input);
            public static Hour Hours(this long input) => new Hour(input);

            public static Hour Hours(this float input) => new Hour((double)input);
            public static Hour Hours(this double input) => new Hour((double)input);
        }
    }
}
