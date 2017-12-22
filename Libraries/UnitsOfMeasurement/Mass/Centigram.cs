namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Centigram : Mass
            {
                public Centigram(double value) : base(value, Conversion.Centigram, "CG") { }

                public static Centigram operator +(Centigram firstMeasurement, Centigram secondMeasurement)
                {
                    return new Centigram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Centigram operator -(Centigram firstMeasurement, Centigram secondMeasurement)
                {
                    return new Centigram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Centigram operator *(Centigram firstMeasurement, Centigram secondMeasurement)
                {
                    return new Centigram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Centigram operator /(Centigram firstMeasurement, Centigram secondMeasurement)
                {
                    return new Centigram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Centigram ToCentigrams(this Measurement input) => new Centigram(input.ConvertToBase());

            public static Centigram Centigrams(this byte input) => new Centigram(input);
            public static Centigram Centigrams(this short input) => new Centigram(input);
            public static Centigram Centigrams(this int input) => new Centigram(input);
            public static Centigram Centigrams(this long input) => new Centigram(input);

            public static Centigram Centigrams(this float input) => new Centigram((double)input);
            public static Centigram Centigrams(this double input) => new Centigram((double)input);
        }
    }
}
