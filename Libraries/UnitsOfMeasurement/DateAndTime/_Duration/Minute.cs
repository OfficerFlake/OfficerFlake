using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Minute : Duration, IMinute
            {
				#region CTOR
	            public Minute(double value) : base(value, Conversion.Minute, "m") { }
	            #endregion
	            #region Operators
	            public static Minute operator +(Minute firstMeasurement, Minute secondMeasurement)
	            {
		            return new Minute((firstMeasurement.RawValue + secondMeasurement.RawValue));
	            }
	            public static Minute operator -(Minute firstMeasurement, Minute secondMeasurement)
	            {
		            return new Minute((firstMeasurement.RawValue - secondMeasurement.RawValue));
	            }
	            public static bool operator >(Minute firstMeasurement, Minute secondMeasurement)
	            {
		            return firstMeasurement.RawValue > secondMeasurement.RawValue;
	            }
	            public static bool operator <(Minute firstMeasurement, Minute secondMeasurement)
	            {
		            return firstMeasurement.RawValue < secondMeasurement.RawValue;
	            }
	            #endregion
			}

			public static Minute ToMinutes(this Duration input) => new Minute(input.ConvertToBase());

            public static Minute Minutes(this byte input) => new Minute(input);
            public static Minute Minutes(this short input) => new Minute(input);
            public static Minute Minutes(this int input) => new Minute(input);
            public static Minute Minutes(this long input) => new Minute(input);

            public static Minute Minutes(this float input) => new Minute((double)input);
            public static Minute Minutes(this double input) => new Minute((double)input);
        }
    }
}
