namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Kilometer : Length
            {
                public Kilometer(decimal value) : base(value, Conversion.Kilometer, "KM") { }

                public static Kilometer operator +(Kilometer firstMeasurement, Kilometer secondMeasurement)
                {
                    return new Kilometer((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Kilometer operator -(Kilometer firstMeasurement, Kilometer secondMeasurement)
                {
                    return new Kilometer((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Kilometer operator *(Kilometer firstMeasurement, Kilometer secondMeasurement)
                {
                    return new Kilometer((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Kilometer operator /(Kilometer firstMeasurement, Kilometer secondMeasurement)
                {
                    return new Kilometer((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Kilometer ToKilometers(this Measurement input) => new Kilometer(input.ConvertToBase);

            public static Kilometer Kilometers(this byte input) => new Kilometer(input);
            public static Kilometer Kilometers(this short input) => new Kilometer(input);
            public static Kilometer Kilometers(this int input) => new Kilometer(input);
            public static Kilometer Kilometers(this long input) => new Kilometer(input);

            public static Kilometer Kilometers(this float input) => new Kilometer((decimal)input);
            public static Kilometer Kilometers(this double input) => new Kilometer((decimal)input);
            public static Kilometer Kilometers(this decimal input) => new Kilometer(input);
        }
    }
}
