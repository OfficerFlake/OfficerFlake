namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Decagram : Mass
            {
                public Decagram(decimal value) : base(value, Conversion.Decagram, "DaG") { }

                public static Decagram operator +(Decagram firstMeasurement, Decagram secondMeasurement)
                {
                    return new Decagram((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Decagram operator -(Decagram firstMeasurement, Decagram secondMeasurement)
                {
                    return new Decagram((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Decagram operator *(Decagram firstMeasurement, Decagram secondMeasurement)
                {
                    return new Decagram((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Decagram operator /(Decagram firstMeasurement, Decagram secondMeasurement)
                {
                    return new Decagram((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Decagram ToDecagrams(this Measurement input) => new Decagram(input.ConvertToBase);

            public static Decagram Decagrams(this byte input) => new Decagram(input);
            public static Decagram Decagrams(this short input) => new Decagram(input);
            public static Decagram Decagrams(this int input) => new Decagram(input);
            public static Decagram Decagrams(this long input) => new Decagram(input);

            public static Decagram Decagrams(this float input) => new Decagram((decimal)input);
            public static Decagram Decagrams(this double input) => new Decagram((decimal)input);
            public static Decagram Decagrams(this decimal input) => new Decagram(input);
        }
    }
}
