namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Hour : Duration
            {
                public Hour(decimal value) : base(value, Conversion.Hour, "D") { }

                public static Hour operator +(Hour firstMeasurement, Hour HourMeasurement)
                {
                    return new Hour((firstMeasurement.ConvertToBase + HourMeasurement.ConvertToBase));
                }
                public static Hour operator -(Hour firstMeasurement, Hour HourMeasurement)
                {
                    return new Hour((firstMeasurement.ConvertToBase - HourMeasurement.ConvertToBase));
                }
                public static Hour operator *(Hour firstMeasurement, Hour HourMeasurement)
                {
                    return new Hour((firstMeasurement.ConvertToBase * HourMeasurement.ConvertToBase));
                }
                public static Hour operator /(Hour firstMeasurement, Hour HourMeasurement)
                {
                    return new Hour((firstMeasurement.ConvertToBase / HourMeasurement.ConvertToBase));
                }
            }

            public static Hour ToHours(this Measurement input) => new Hour(input.ConvertToBase);

            public static Hour Hours(this byte input) => new Hour(input);
            public static Hour Hours(this short input) => new Hour(input);
            public static Hour Hours(this int input) => new Hour(input);
            public static Hour Hours(this long input) => new Hour(input);

            public static Hour Hours(this float input) => new Hour((decimal)input);
            public static Hour Hours(this double input) => new Hour((decimal)input);
            public static Hour Hours(this decimal input) => new Hour(input);
        }
    }
}
