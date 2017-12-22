namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareFoot : Area
            {
                public SquareFoot(double value) : base(value, Conversion.SquareFoot, "FT^2") { }

                public static SquareFoot operator +(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
                {
                    return new SquareFoot((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static SquareFoot operator -(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
                {
                    return new SquareFoot((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static SquareFoot operator *(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
                {
                    return new SquareFoot((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static SquareFoot operator /(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
                {
                    return new SquareFoot((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static SquareFoot ToSquareFoots(this Measurement input) => new SquareFoot(input.ConvertToBase());

            public static SquareFoot SquareFoots(this byte input) => new SquareFoot(input);
            public static SquareFoot SquareFoots(this short input) => new SquareFoot(input);
            public static SquareFoot SquareFoots(this int input) => new SquareFoot(input);
            public static SquareFoot SquareFoots(this long input) => new SquareFoot(input);

            public static SquareFoot SquareFoots(this float input) => new SquareFoot((double)input);
            public static SquareFoot SquareFoots(this double input) => new SquareFoot((double)input);
        }
    }
}
