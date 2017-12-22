namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareMile : Area
            {
                public SquareMile(double value) : base(value, Conversion.SquareMile, "MI^2") { }

                public static SquareMile operator +(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static SquareMile operator -(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static SquareMile operator *(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static SquareMile operator /(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static SquareMile ToSquareMiles(this Measurement input) => new SquareMile(input.ConvertToBase());

            public static SquareMile SquareMiles(this byte input) => new SquareMile(input);
            public static SquareMile SquareMiles(this short input) => new SquareMile(input);
            public static SquareMile SquareMiles(this int input) => new SquareMile(input);
            public static SquareMile SquareMiles(this long input) => new SquareMile(input);

            public static SquareMile SquareMiles(this float input) => new SquareMile((double)input);
            public static SquareMile SquareMiles(this double input) => new SquareMile((double)input);
        }
    }
}
