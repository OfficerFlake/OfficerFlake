namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class KiloPascal : Pressure
            {
                public KiloPascal(decimal value) : base(value, Conversion.KiloPascal, "KP") { }

                public static KiloPascal operator +(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
                {
                    return new KiloPascal((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static KiloPascal operator -(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
                {
                    return new KiloPascal((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static KiloPascal operator *(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
                {
                    return new KiloPascal((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static KiloPascal operator /(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
                {
                    return new KiloPascal((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static KiloPascal ToKiloPascals(this Measurement input) => new KiloPascal(input.ConvertToBase);

            public static KiloPascal KiloPascals(this byte input) => new KiloPascal(input);
            public static KiloPascal KiloPascals(this short input) => new KiloPascal(input);
            public static KiloPascal KiloPascals(this int input) => new KiloPascal(input);
            public static KiloPascal KiloPascals(this long input) => new KiloPascal(input);

            public static KiloPascal KiloPascals(this float input) => new KiloPascal((decimal)input);
            public static KiloPascal KiloPascals(this double input) => new KiloPascal((decimal)input);
            public static KiloPascal KiloPascals(this decimal input) => new KiloPascal(input);
        }
    }
}
