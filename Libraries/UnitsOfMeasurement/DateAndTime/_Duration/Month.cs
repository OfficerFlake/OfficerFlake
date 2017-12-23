using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Month : Duration, IMonth
            {
				#region CTOR
	            public Month(double value) : base(value, Conversion.Month, "M") { }
	            #endregion
	            #region Operators
	            public static Month operator +(Month firstMeasurement, Month secondMeasurement)
	            {
		            return new Month((firstMeasurement.RawValue + secondMeasurement.RawValue));
	            }
	            public static Month operator -(Month firstMeasurement, Month secondMeasurement)
	            {
		            return new Month((firstMeasurement.RawValue - secondMeasurement.RawValue));
	            }
	            public static bool operator >(Month firstMeasurement, Month secondMeasurement)
	            {
		            return firstMeasurement.RawValue > secondMeasurement.RawValue;
	            }
	            public static bool operator <(Month firstMeasurement, Month secondMeasurement)
	            {
		            return firstMeasurement.RawValue < secondMeasurement.RawValue;
	            }
	            #endregion
			}

			public static Month ToMonths(this Duration input) => new Month(input.ConvertToBase());

            public static Month Months(this byte input) => new Month(input);
            public static Month Months(this short input) => new Month(input);
            public static Month Months(this int input) => new Month(input);
            public static Month Months(this long input) => new Month(input);

            public static Month Months(this float input) => new Month((double)input);
            public static Month Months(this double input) => new Month((double)input);
        }
    }
}
