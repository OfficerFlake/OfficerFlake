namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Pressures
        {
            public class Atmosphere : Pressure
            {
                public Atmosphere(double value) : base(value, Conversion.Atmosphere, "ATMOSPHERE") { }

                public static Atmosphere operator +(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
                {
                    return new Atmosphere((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Atmosphere operator -(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
                {
                    return new Atmosphere((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Atmosphere operator *(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
                {
                    return new Atmosphere((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Atmosphere operator /(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
                {
                    return new Atmosphere((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Atmosphere ToAtmospheres(this Measurement input) => new Atmosphere(input.ConvertToBase());

            public static Atmosphere Atmospheres(this byte input) => new Atmosphere(input);
            public static Atmosphere Atmospheres(this short input) => new Atmosphere(input);
            public static Atmosphere Atmospheres(this int input) => new Atmosphere(input);
            public static Atmosphere Atmospheres(this long input) => new Atmosphere(input);

            public static Atmosphere Atmospheres(this float input) => new Atmosphere((double)input);
            public static Atmosphere Atmospheres(this double input) => new Atmosphere((double)input);
        }
    }
}
