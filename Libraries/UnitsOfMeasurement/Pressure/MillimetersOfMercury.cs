namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class MillimeterOfMercury : Pressure
            {
                public MillimeterOfMercury(double value) : base(value, Conversion.MillimetersOfMercury, "MMHG") { }

                public static MillimeterOfMercury operator +(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
                {
                    return new MillimeterOfMercury((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static MillimeterOfMercury operator -(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
                {
                    return new MillimeterOfMercury((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static MillimeterOfMercury operator *(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
                {
                    return new MillimeterOfMercury((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static MillimeterOfMercury operator /(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
                {
                    return new MillimeterOfMercury((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static MillimeterOfMercury ToMillimetersOfMercury(this Measurement input) => new MillimeterOfMercury(input.ConvertToBase());

            public static MillimeterOfMercury MillimetersOfMercury(this byte input) => new MillimeterOfMercury(input);
            public static MillimeterOfMercury MillimetersOfMercury(this short input) => new MillimeterOfMercury(input);
            public static MillimeterOfMercury MillimetersOfMercury(this int input) => new MillimeterOfMercury(input);
            public static MillimeterOfMercury MillimetersOfMercury(this long input) => new MillimeterOfMercury(input);

            public static MillimeterOfMercury MillimetersOfMercury(this float input) => new MillimeterOfMercury((double)input);
            public static MillimeterOfMercury MillimetersOfMercury(this double input) => new MillimeterOfMercury((double)input);
        }
    }
}
