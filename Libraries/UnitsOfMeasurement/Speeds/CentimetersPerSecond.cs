namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class CentimetersPerSecond : Speed
            {
                public CentimetersPerSecond(decimal value) : base(value, Conversion.CentimetersPerSecond, "CM/S") { }

                public static CentimetersPerSecond operator +(CentimetersPerSecond firstMeasurement, CentimetersPerSecond secondMeasurement)
                {
                    return new CentimetersPerSecond((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static CentimetersPerSecond operator -(CentimetersPerSecond firstMeasurement, CentimetersPerSecond secondMeasurement)
                {
                    return new CentimetersPerSecond((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static CentimetersPerSecond operator *(CentimetersPerSecond firstMeasurement, CentimetersPerSecond secondMeasurement)
                {
                    return new CentimetersPerSecond((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static CentimetersPerSecond operator /(CentimetersPerSecond firstMeasurement, CentimetersPerSecond secondMeasurement)
                {
                    return new CentimetersPerSecond((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static CentimetersPerSecond ToCentimetersPerSeconds(this Measurement input) => new CentimetersPerSecond(input.ConvertToBase);

            public static CentimetersPerSecond CentimetersPerSeconds(this byte input) => new CentimetersPerSecond(input);
            public static CentimetersPerSecond CentimetersPerSeconds(this short input) => new CentimetersPerSecond(input);
            public static CentimetersPerSecond CentimetersPerSeconds(this int input) => new CentimetersPerSecond(input);
            public static CentimetersPerSecond CentimetersPerSeconds(this long input) => new CentimetersPerSecond(input);

            public static CentimetersPerSecond CentimetersPerSeconds(this float input) => new CentimetersPerSecond((decimal)input);
            public static CentimetersPerSecond CentimetersPerSeconds(this double input) => new CentimetersPerSecond((decimal)input);
            public static CentimetersPerSecond CentimetersPerSeconds(this decimal input) => new CentimetersPerSecond(input);
        }
    }
}
