namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Hectogram : Mass
            {
                public Hectogram(decimal value) : base(value, Conversion.Hectogram, "HG") { }

                public static Hectogram operator +(Hectogram firstMeasurement, Hectogram secondMeasurement)
                {
                    return new Hectogram((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Hectogram operator -(Hectogram firstMeasurement, Hectogram secondMeasurement)
                {
                    return new Hectogram((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Hectogram operator *(Hectogram firstMeasurement, Hectogram secondMeasurement)
                {
                    return new Hectogram((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Hectogram operator /(Hectogram firstMeasurement, Hectogram secondMeasurement)
                {
                    return new Hectogram((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Hectogram ToHectograms(this Measurement input) => new Hectogram(input.ConvertToBase);

            public static Hectogram Hectograms(this byte input) => new Hectogram(input);
            public static Hectogram Hectograms(this short input) => new Hectogram(input);
            public static Hectogram Hectograms(this int input) => new Hectogram(input);
            public static Hectogram Hectograms(this long input) => new Hectogram(input);

            public static Hectogram Hectograms(this float input) => new Hectogram((decimal)input);
            public static Hectogram Hectograms(this double input) => new Hectogram((decimal)input);
            public static Hectogram Hectograms(this decimal input) => new Hectogram(input);
        }
    }
}
