namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Week : Duration
            {
                public Week(double value) : base(value, Conversion.Week, "D") { }

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
            }

            public static Week ToWeeks(this Measurement input) => new Week(input.ConvertToBase());

            public static Week Weeks(this byte input) => new Week(input);
            public static Week Weeks(this short input) => new Week(input);
            public static Week Weeks(this int input) => new Week(input);
            public static Week Weeks(this long input) => new Week(input);

            public static Week Weeks(this float input) => new Week((double)input);
            public static Week Weeks(this double input) => new Week((double)input);
        }
    }
}
