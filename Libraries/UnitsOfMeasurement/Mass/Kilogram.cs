namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Kilogram : Mass
            {
                public Kilogram(decimal value) : base(value, Conversion.Kilogram, "KG") { }

                public static Kilogram operator +(Kilogram firstMeasurement, Kilogram secondMeasurement)
                {
                    return new Kilogram((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Kilogram operator -(Kilogram firstMeasurement, Kilogram secondMeasurement)
                {
                    return new Kilogram((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Kilogram operator *(Kilogram firstMeasurement, Kilogram secondMeasurement)
                {
                    return new Kilogram((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Kilogram operator /(Kilogram firstMeasurement, Kilogram secondMeasurement)
                {
                    return new Kilogram((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Kilogram ToKilograms(this Measurement input) => new Kilogram(input.ConvertToBase);

            public static Kilogram Kilograms(this byte input) => new Kilogram(input);
            public static Kilogram Kilograms(this short input) => new Kilogram(input);
            public static Kilogram Kilograms(this int input) => new Kilogram(input);
            public static Kilogram Kilograms(this long input) => new Kilogram(input);

            public static Kilogram Kilograms(this float input) => new Kilogram((decimal)input);
            public static Kilogram Kilograms(this double input) => new Kilogram((decimal)input);
            public static Kilogram Kilograms(this decimal input) => new Kilogram(input);
        }
    }
}
