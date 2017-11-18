namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class MillimetersOfMercury : Pressure
            {
                public MillimetersOfMercury(decimal value) : base(value, Conversion.MillimetersOfMercury, "MMHG") { }

                public static MillimetersOfMercury operator +(MillimetersOfMercury firstMeasurement, MillimetersOfMercury secondMeasurement)
                {
                    return new MillimetersOfMercury((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static MillimetersOfMercury operator -(MillimetersOfMercury firstMeasurement, MillimetersOfMercury secondMeasurement)
                {
                    return new MillimetersOfMercury((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static MillimetersOfMercury operator *(MillimetersOfMercury firstMeasurement, MillimetersOfMercury secondMeasurement)
                {
                    return new MillimetersOfMercury((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static MillimetersOfMercury operator /(MillimetersOfMercury firstMeasurement, MillimetersOfMercury secondMeasurement)
                {
                    return new MillimetersOfMercury((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static MillimetersOfMercury ToMillimetersOfMercurys(this Measurement input) => new MillimetersOfMercury(input.ConvertToBase);

            public static MillimetersOfMercury MillimetersOfMercurys(this byte input) => new MillimetersOfMercury(input);
            public static MillimetersOfMercury MillimetersOfMercurys(this short input) => new MillimetersOfMercury(input);
            public static MillimetersOfMercury MillimetersOfMercurys(this int input) => new MillimetersOfMercury(input);
            public static MillimetersOfMercury MillimetersOfMercurys(this long input) => new MillimetersOfMercury(input);

            public static MillimetersOfMercury MillimetersOfMercurys(this float input) => new MillimetersOfMercury((decimal)input);
            public static MillimetersOfMercury MillimetersOfMercurys(this double input) => new MillimetersOfMercury((decimal)input);
            public static MillimetersOfMercury MillimetersOfMercurys(this decimal input) => new MillimetersOfMercury(input);
        }
    }
}
