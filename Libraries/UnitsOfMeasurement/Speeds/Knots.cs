namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class Knots : Speed
            {
                public Knots(decimal value) : base(value, Conversion.Knots, "KT") { }

                public static Knots operator +(Knots firstMeasurement, Knots secondMeasurement)
                {
                    return new Knots((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Knots operator -(Knots firstMeasurement, Knots secondMeasurement)
                {
                    return new Knots((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Knots operator *(Knots firstMeasurement, Knots secondMeasurement)
                {
                    return new Knots((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Knots operator /(Knots firstMeasurement, Knots secondMeasurement)
                {
                    return new Knots((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Knots ToKnotss(this Measurement input) => new Knots(input.ConvertToBase);

            public static Knots Knotss(this byte input) => new Knots(input);
            public static Knots Knotss(this short input) => new Knots(input);
            public static Knots Knotss(this int input) => new Knots(input);
            public static Knots Knotss(this long input) => new Knots(input);

            public static Knots Knotss(this float input) => new Knots((decimal)input);
            public static Knots Knotss(this double input) => new Knots((decimal)input);
            public static Knots Knotss(this decimal input) => new Knots(input);
        }
    }
}
