namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareInch : Area
            {
                public SquareInch(decimal value) : base(value, Conversion.SquareInch, "IN^2") { }

                public static SquareInch operator +(SquareInch firstMeasurement, SquareInch secondMeasurement)
                {
                    return new SquareInch((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static SquareInch operator -(SquareInch firstMeasurement, SquareInch secondMeasurement)
                {
                    return new SquareInch((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static SquareInch operator *(SquareInch firstMeasurement, SquareInch secondMeasurement)
                {
                    return new SquareInch((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static SquareInch operator /(SquareInch firstMeasurement, SquareInch secondMeasurement)
                {
                    return new SquareInch((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static SquareInch ToSquareInchs(this Measurement input) => new SquareInch(input.ConvertToBase);

            public static SquareInch SquareInchs(this byte input) => new SquareInch(input);
            public static SquareInch SquareInchs(this short input) => new SquareInch(input);
            public static SquareInch SquareInchs(this int input) => new SquareInch(input);
            public static SquareInch SquareInchs(this long input) => new SquareInch(input);

            public static SquareInch SquareInchs(this float input) => new SquareInch((decimal)input);
            public static SquareInch SquareInchs(this double input) => new SquareInch((decimal)input);
            public static SquareInch SquareInchs(this decimal input) => new SquareInch(input);
        }
    }
}
