using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Second : Duration, ISecond
            {
				#region CTOR
	            public Second(double value) : base(value, Conversion.Second, "s") { }
	            #endregion
	            #region Operators
	            public static Second operator +(Second firstMeasurement, Second secondMeasurement)
	            {
		            return new Second((firstMeasurement.RawValue + secondMeasurement.RawValue));
	            }
	            public static Second operator -(Second firstMeasurement, Second secondMeasurement)
	            {
		            return new Second((firstMeasurement.RawValue - secondMeasurement.RawValue));
	            }
	            public static bool operator >(Second firstMeasurement, Second secondMeasurement)
	            {
		            return firstMeasurement.RawValue > secondMeasurement.RawValue;
	            }
	            public static bool operator <(Second firstMeasurement, Second secondMeasurement)
	            {
		            return firstMeasurement.RawValue < secondMeasurement.RawValue;
	            }
	            #endregion
			}

			public static Second ToSeconds(this Duration input) => new Second(input.ConvertToBase());

            public static Second Seconds(this byte input) => new Second(input);
            public static Second Seconds(this short input) => new Second(input);
            public static Second Seconds(this int input) => new Second(input);
            public static Second Seconds(this long input) => new Second(input);

            public static Second Seconds(this float input) => new Second((double)input);
            public static Second Seconds(this double input) => new Second((double)input);
        }
    }
}
