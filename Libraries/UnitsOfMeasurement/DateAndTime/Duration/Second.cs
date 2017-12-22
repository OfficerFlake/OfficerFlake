namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Second : Duration
            {
                public Second(double value) : base(value, Conversion.Second, "D") { }

                public static Second operator +(Second firstMeasurement, Second secondMeasurement)
                {
                    return new Second((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Second operator -(Second firstMeasurement, Second secondMeasurement)
                {
                    return new Second((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Second operator *(Second firstMeasurement, Second secondMeasurement)
                {
                    return new Second((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Second operator /(Second firstMeasurement, Second secondMeasurement)
                {
                    return new Second((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Second ToSeconds(this Measurement input) => new Second(input.ConvertToBase());

            public static Second Seconds(this byte input) => new Second(input);
            public static Second Seconds(this short input) => new Second(input);
            public static Second Seconds(this int input) => new Second(input);
            public static Second Seconds(this long input) => new Second(input);

            public static Second Seconds(this float input) => new Second((double)input);
            public static Second Seconds(this double input) => new Second((double)input);
        }
    }
}
