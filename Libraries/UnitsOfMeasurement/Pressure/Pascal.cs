namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class Pascal : Pressure
            {
                public Pascal(double value) : base(value, Conversion.Pascal, "P") { }

                public static Pascal operator +(Pascal firstMeasurement, Pascal secondMeasurement)
                {
                    return new Pascal((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Pascal operator -(Pascal firstMeasurement, Pascal secondMeasurement)
                {
                    return new Pascal((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Pascal operator *(Pascal firstMeasurement, Pascal secondMeasurement)
                {
                    return new Pascal((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Pascal operator /(Pascal firstMeasurement, Pascal secondMeasurement)
                {
                    return new Pascal((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Pascal ToPascals(this Measurement input) => new Pascal(input.ConvertToBase());

            public static Pascal Pascals(this byte input) => new Pascal(input);
            public static Pascal Pascals(this short input) => new Pascal(input);
            public static Pascal Pascals(this int input) => new Pascal(input);
            public static Pascal Pascals(this long input) => new Pascal(input);

            public static Pascal Pascals(this float input) => new Pascal((double)input);
            public static Pascal Pascals(this double input) => new Pascal((double)input);
        }
    }
}
