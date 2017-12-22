namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Durations
        {
            public class Minute : Duration
            {
                public Minute(double value) : base(value, Conversion.Minute, "D") { }

                public static Minute operator +(Minute firstMeasurement, Minute MinuteMeasurement)
                {
                    return new Minute((firstMeasurement.ConvertToBase() + MinuteMeasurement.ConvertToBase()));
                }
                public static Minute operator -(Minute firstMeasurement, Minute MinuteMeasurement)
                {
                    return new Minute((firstMeasurement.ConvertToBase() - MinuteMeasurement.ConvertToBase()));
                }
                public static Minute operator *(Minute firstMeasurement, Minute MinuteMeasurement)
                {
                    return new Minute((firstMeasurement.ConvertToBase() * MinuteMeasurement.ConvertToBase()));
                }
                public static Minute operator /(Minute firstMeasurement, Minute MinuteMeasurement)
                {
                    return new Minute((firstMeasurement.ConvertToBase() / MinuteMeasurement.ConvertToBase()));
                }
            }

            public static Minute ToMinutes(this Measurement input) => new Minute(input.ConvertToBase());

            public static Minute Minutes(this byte input) => new Minute(input);
            public static Minute Minutes(this short input) => new Minute(input);
            public static Minute Minutes(this int input) => new Minute(input);
            public static Minute Minutes(this long input) => new Minute(input);

            public static Minute Minutes(this float input) => new Minute((double)input);
            public static Minute Minutes(this double input) => new Minute((double)input);
        }
    }
}
