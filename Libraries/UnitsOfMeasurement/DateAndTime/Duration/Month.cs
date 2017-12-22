namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Month : Duration
            {
                public Month(double value) : base(value, Conversion.Month, "D") { }

                public static Month operator +(Month firstMeasurement, Month secondMeasurement)
                {
                    return new Month((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Month operator -(Month firstMeasurement, Month secondMeasurement)
                {
                    return new Month((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Month operator *(Month firstMeasurement, Month secondMeasurement)
                {
                    return new Month((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Month operator /(Month firstMeasurement, Month secondMeasurement)
                {
                    return new Month((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Month ToMonths(this Measurement input) => new Month(input.ConvertToBase());

            public static Month Months(this byte input) => new Month(input);
            public static Month Months(this short input) => new Month(input);
            public static Month Months(this int input) => new Month(input);
            public static Month Months(this long input) => new Month(input);

            public static Month Months(this float input) => new Month((double)input);
            public static Month Months(this double input) => new Month((double)input);
        }
    }
}
