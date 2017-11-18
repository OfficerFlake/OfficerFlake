namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class MillimetersPerSecond : Speed
            {
                public MillimetersPerSecond(decimal value) : base(value, Conversion.MillimetersPerSecond, "MM/S") { }

                public static MillimetersPerSecond operator +(MillimetersPerSecond firstMeasurement, MillimetersPerSecond secondMeasurement)
                {
                    return new MillimetersPerSecond((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static MillimetersPerSecond operator -(MillimetersPerSecond firstMeasurement, MillimetersPerSecond secondMeasurement)
                {
                    return new MillimetersPerSecond((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static MillimetersPerSecond operator *(MillimetersPerSecond firstMeasurement, MillimetersPerSecond secondMeasurement)
                {
                    return new MillimetersPerSecond((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static MillimetersPerSecond operator /(MillimetersPerSecond firstMeasurement, MillimetersPerSecond secondMeasurement)
                {
                    return new MillimetersPerSecond((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static MillimetersPerSecond ToMillimetersPerSeconds(this Measurement input) => new MillimetersPerSecond(input.ConvertToBase);

            public static MillimetersPerSecond MillimetersPerSeconds(this byte input) => new MillimetersPerSecond(input);
            public static MillimetersPerSecond MillimetersPerSeconds(this short input) => new MillimetersPerSecond(input);
            public static MillimetersPerSecond MillimetersPerSeconds(this int input) => new MillimetersPerSecond(input);
            public static MillimetersPerSecond MillimetersPerSeconds(this long input) => new MillimetersPerSecond(input);

            public static MillimetersPerSecond MillimetersPerSeconds(this float input) => new MillimetersPerSecond((decimal)input);
            public static MillimetersPerSecond MillimetersPerSeconds(this double input) => new MillimetersPerSecond((decimal)input);
            public static MillimetersPerSecond MillimetersPerSeconds(this decimal input) => new MillimetersPerSecond(input);
        }
    }
}
