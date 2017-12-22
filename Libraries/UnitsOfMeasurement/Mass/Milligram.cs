namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Milligram : Mass
            {
                public Milligram(double value) : base(value, Conversion.Milligram, "MG") { }

                public static Milligram operator +(Milligram firstMeasurement, Milligram secondMeasurement)
                {
                    return new Milligram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Milligram operator -(Milligram firstMeasurement, Milligram secondMeasurement)
                {
                    return new Milligram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Milligram operator *(Milligram firstMeasurement, Milligram secondMeasurement)
                {
                    return new Milligram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Milligram operator /(Milligram firstMeasurement, Milligram secondMeasurement)
                {
                    return new Milligram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Milligram ToMilligrams(this Measurement input) => new Milligram(input.ConvertToBase());

            public static Milligram Milligrams(this byte input) => new Milligram(input);
            public static Milligram Milligrams(this short input) => new Milligram(input);
            public static Milligram Milligrams(this int input) => new Milligram(input);
            public static Milligram Milligrams(this long input) => new Milligram(input);

            public static Milligram Milligrams(this float input) => new Milligram((double)input);
            public static Milligram Milligrams(this double input) => new Milligram((double)input);
        }
    }
}
