namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Areas
        {
            public class SquareMile : Area
            {
                public SquareMile(decimal value) : base(value, Conversion.SquareMile, "MI^2") { }

                public static SquareMile operator +(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static SquareMile operator -(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static SquareMile operator *(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static SquareMile operator /(SquareMile firstMeasurement, SquareMile secondMeasurement)
                {
                    return new SquareMile((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static SquareMile ToSquareMiles(this Measurement input) => new SquareMile(input.ConvertToBase);

            public static SquareMile SquareMiles(this byte input) => new SquareMile(input);
            public static SquareMile SquareMiles(this short input) => new SquareMile(input);
            public static SquareMile SquareMiles(this int input) => new SquareMile(input);
            public static SquareMile SquareMiles(this long input) => new SquareMile(input);

            public static SquareMile SquareMiles(this float input) => new SquareMile((decimal)input);
            public static SquareMile SquareMiles(this double input) => new SquareMile((decimal)input);
            public static SquareMile SquareMiles(this decimal input) => new SquareMile(input);
        }
    }
}
