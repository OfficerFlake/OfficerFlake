namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Decigram : Mass
            {
                public Decigram(double value) : base(value, Conversion.Decigram, "DiG") { }

                public static Decigram operator +(Decigram firstMeasurement, Decigram secondMeasurement)
                {
                    return new Decigram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Decigram operator -(Decigram firstMeasurement, Decigram secondMeasurement)
                {
                    return new Decigram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Decigram operator *(Decigram firstMeasurement, Decigram secondMeasurement)
                {
                    return new Decigram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Decigram operator /(Decigram firstMeasurement, Decigram secondMeasurement)
                {
                    return new Decigram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Decigram ToDecigrams(this Measurement input) => new Decigram(input.ConvertToBase());

            public static Decigram Decigrams(this byte input) => new Decigram(input);
            public static Decigram Decigrams(this short input) => new Decigram(input);
            public static Decigram Decigrams(this int input) => new Decigram(input);
            public static Decigram Decigrams(this long input) => new Decigram(input);

            public static Decigram Decigrams(this float input) => new Decigram((double)input);
            public static Decigram Decigrams(this double input) => new Decigram((double)input);
        }
    }
}
