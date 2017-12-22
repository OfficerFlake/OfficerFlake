namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareCentimeter : Area
            {
                public SquareCentimeter(double value) : base(value, Conversion.SquareCentimeter, "CM^2") { }

                public static SquareCentimeter operator +(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
                {
                    return new SquareCentimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static SquareCentimeter operator -(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
                {
                    return new SquareCentimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static SquareCentimeter operator *(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
                {
                    return new SquareCentimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static SquareCentimeter operator /(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
                {
                    return new SquareCentimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static SquareCentimeter ToSquareCentimeters(this Measurement input) => new SquareCentimeter(input.ConvertToBase());

            public static SquareCentimeter SquareCentimeters(this byte input) => new SquareCentimeter(input);
            public static SquareCentimeter SquareCentimeters(this short input) => new SquareCentimeter(input);
            public static SquareCentimeter SquareCentimeters(this int input) => new SquareCentimeter(input);
            public static SquareCentimeter SquareCentimeters(this long input) => new SquareCentimeter(input);

            public static SquareCentimeter SquareCentimeters(this float input) => new SquareCentimeter((double)input);
            public static SquareCentimeter SquareCentimeters(this double input) => new SquareCentimeter((double)input);
        }
    }
}
