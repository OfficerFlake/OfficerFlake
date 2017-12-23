using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Year : Duration, IYear
            {
				#region CTOR
	            public Year(double value) : base(value, Conversion.Year, "Y") { }
	            #endregion
	            #region Operators
	            public static Year operator +(Year firstMeasurement, Year secondMeasurement)
	            {
		            return new Year((firstMeasurement.RawValue + secondMeasurement.RawValue));
	            }
	            public static Year operator -(Year firstMeasurement, Year secondMeasurement)
	            {
		            return new Year((firstMeasurement.RawValue - secondMeasurement.RawValue));
	            }
	            public static bool operator >(Year firstMeasurement, Year secondMeasurement)
	            {
		            return firstMeasurement.RawValue > secondMeasurement.RawValue;
	            }
	            public static bool operator <(Year firstMeasurement, Year secondMeasurement)
	            {
		            return firstMeasurement.RawValue < secondMeasurement.RawValue;
	            }
	            #endregion
			}

			public static Year ToYears(this Duration input) => new Year(input.ConvertToBase());

            public static Year Years(this byte input) => new Year(input);
            public static Year Years(this short input) => new Year(input);
            public static Year Years(this int input) => new Year(input);
            public static Year Years(this long input) => new Year(input);

            public static Year Years(this float input) => new Year((double)input);
            public static Year Years(this double input) => new Year((double)input);
        }
    }
}
