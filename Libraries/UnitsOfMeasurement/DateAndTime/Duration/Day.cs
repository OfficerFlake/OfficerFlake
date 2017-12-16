namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Day : Duration
            {
                public Day(decimal value) : base(value, Conversion.Day, "D") { }

                public static Day operator +(Day firstMeasurement, Day secondMeasurement)
                {
                    return new Day((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Day operator -(Day firstMeasurement, Day secondMeasurement)
                {
                    return new Day((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Day operator *(Day firstMeasurement, Day secondMeasurement)
                {
                    return new Day((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Day operator /(Day firstMeasurement, Day secondMeasurement)
                {
                    return new Day((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Day ToDays(this Measurement input) => new Day(input.ConvertToBase);

            public static Day Days(this byte input) => new Day(input);
            public static Day Days(this short input) => new Day(input);
            public static Day Days(this int input) => new Day(input);
            public static Day Days(this long input) => new Day(input);

            public static Day Days(this float input) => new Day((decimal)input);
            public static Day Days(this double input) => new Day((decimal)input);
            public static Day Days(this decimal input) => new Day(input);
        }
    }
}
