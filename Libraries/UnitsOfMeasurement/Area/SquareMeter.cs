namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareMeter : Area
            {
                public SquareMeter(double value) : base(value, Conversion.SquareMeter, "M^2") { }

                public static SquareMeter operator +(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
                {
                    return new SquareMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static SquareMeter operator -(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
                {
                    return new SquareMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static SquareMeter operator *(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
                {
                    return new SquareMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static SquareMeter operator /(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
                {
                    return new SquareMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static SquareMeter ToSquareMeters(this Measurement input) => new SquareMeter(input.ConvertToBase());

            public static SquareMeter SquareMeters(this byte input) => new SquareMeter(input);
            public static SquareMeter SquareMeters(this short input) => new SquareMeter(input);
            public static SquareMeter SquareMeters(this int input) => new SquareMeter(input);
            public static SquareMeter SquareMeters(this long input) => new SquareMeter(input);

            public static SquareMeter SquareMeters(this float input) => new SquareMeter((double)input);
	        public static SquareMeter SquareMeters(this double input) => new SquareMeter((double) input);
        }
    }
}
