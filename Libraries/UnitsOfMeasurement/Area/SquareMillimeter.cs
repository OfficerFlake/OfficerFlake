namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareMillimeter : Area
            {
                public SquareMillimeter(double value) : base(value, Conversion.SquareMillimeter, "MM^2") { }

                public static SquareMillimeter operator +(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
                {
                    return new SquareMillimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static SquareMillimeter operator -(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
                {
                    return new SquareMillimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static SquareMillimeter operator *(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
                {
                    return new SquareMillimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static SquareMillimeter operator /(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
                {
                    return new SquareMillimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static SquareMillimeter ToSquareMillimeters(this Measurement input) => new SquareMillimeter(input.ConvertToBase());

            public static SquareMillimeter SquareMillimeters(this byte input) => new SquareMillimeter(input);
            public static SquareMillimeter SquareMillimeters(this short input) => new SquareMillimeter(input);
            public static SquareMillimeter SquareMillimeters(this int input) => new SquareMillimeter(input);
            public static SquareMillimeter SquareMillimeters(this long input) => new SquareMillimeter(input);

            public static SquareMillimeter SquareMillimeters(this float input) => new SquareMillimeter((double)input);
            public static SquareMillimeter SquareMillimeters(this double input) => new SquareMillimeter((double)input);
        }
    }
}
