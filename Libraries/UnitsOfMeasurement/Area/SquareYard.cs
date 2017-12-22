namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareYard : Area
            {
                public SquareYard(double value) : base(value, Conversion.SquareYard, "YD^2") { }

                public static SquareYard operator +(SquareYard firstMeasurement, SquareYard secondMeasurement)
                {
                    return new SquareYard((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static SquareYard operator -(SquareYard firstMeasurement, SquareYard secondMeasurement)
                {
                    return new SquareYard((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static SquareYard operator *(SquareYard firstMeasurement, SquareYard secondMeasurement)
                {
                    return new SquareYard((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static SquareYard operator /(SquareYard firstMeasurement, SquareYard secondMeasurement)
                {
                    return new SquareYard((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static SquareYard ToSquareYards(this Measurement input) => new SquareYard(input.ConvertToBase());

            public static SquareYard SquareYards(this byte input) => new SquareYard(input);
            public static SquareYard SquareYards(this short input) => new SquareYard(input);
            public static SquareYard SquareYards(this int input) => new SquareYard(input);
            public static SquareYard SquareYards(this long input) => new SquareYard(input);

            public static SquareYard SquareYards(this float input) => new SquareYard((double)input);
            public static SquareYard SquareYards(this double input) => new SquareYard((double)input);
        }
    }
}
