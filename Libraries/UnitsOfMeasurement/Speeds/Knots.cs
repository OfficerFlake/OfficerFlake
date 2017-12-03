namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class Knot : Speed
            {
                public Knot(decimal value) : base(value, Conversion.Knots, "KT") { }

                public static Knot operator +(Knot firstMeasurement, Knot secondMeasurement)
                {
                    return new Knot((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Knot operator -(Knot firstMeasurement, Knot secondMeasurement)
                {
                    return new Knot((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Knot operator *(Knot firstMeasurement, Knot secondMeasurement)
                {
                    return new Knot((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Knot operator /(Knot firstMeasurement, Knot secondMeasurement)
                {
                    return new Knot((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Knot ToKnots(this Measurement input) => new Knot(input.ConvertToBase);

            public static Knot Knots(this byte input) => new Knot(input);
            public static Knot Knots(this short input) => new Knot(input);
            public static Knot Knots(this int input) => new Knot(input);
            public static Knot Knots(this long input) => new Knot(input);

            public static Knot Knots(this float input) => new Knot((decimal)input);
            public static Knot Knots(this double input) => new Knot((decimal)input);
            public static Knot Knots(this decimal input) => new Knot(input);
        }
    }
}
