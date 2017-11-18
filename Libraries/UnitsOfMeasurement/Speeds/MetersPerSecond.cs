namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class MetersPerSecond : Speed
            {
                public MetersPerSecond(decimal value) : base(value, Conversion.MetersPerSecond, "M/S") { }

                public static MetersPerSecond operator +(MetersPerSecond firstMeasurement, MetersPerSecond secondMeasurement)
                {
                    return new MetersPerSecond((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static MetersPerSecond operator -(MetersPerSecond firstMeasurement, MetersPerSecond secondMeasurement)
                {
                    return new MetersPerSecond((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static MetersPerSecond operator *(MetersPerSecond firstMeasurement, MetersPerSecond secondMeasurement)
                {
                    return new MetersPerSecond((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static MetersPerSecond operator /(MetersPerSecond firstMeasurement, MetersPerSecond secondMeasurement)
                {
                    return new MetersPerSecond((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static MetersPerSecond ToMetersPerSeconds(this Measurement input) => new MetersPerSecond(input.ConvertToBase);

            public static MetersPerSecond MetersPerSeconds(this byte input) => new MetersPerSecond(input);
            public static MetersPerSecond MetersPerSeconds(this short input) => new MetersPerSecond(input);
            public static MetersPerSecond MetersPerSeconds(this int input) => new MetersPerSecond(input);
            public static MetersPerSecond MetersPerSeconds(this long input) => new MetersPerSecond(input);

            public static MetersPerSecond MetersPerSeconds(this float input) => new MetersPerSecond((decimal)input);
            public static MetersPerSecond MetersPerSeconds(this double input) => new MetersPerSecond((decimal)input);
            public static MetersPerSecond MetersPerSeconds(this decimal input) => new MetersPerSecond(input);
        }
    }
}
