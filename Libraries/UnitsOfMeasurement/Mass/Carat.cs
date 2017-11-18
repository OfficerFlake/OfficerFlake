namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Carat : Mass
            {
                public Carat(decimal value) : base(value, Conversion.Carat, "CT") { }

                public static Carat operator +(Carat firstMeasurement, Carat secondMeasurement)
                {
                    return new Carat((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Carat operator -(Carat firstMeasurement, Carat secondMeasurement)
                {
                    return new Carat((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Carat operator *(Carat firstMeasurement, Carat secondMeasurement)
                {
                    return new Carat((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Carat operator /(Carat firstMeasurement, Carat secondMeasurement)
                {
                    return new Carat((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Carat ToCarats(this Measurement input) => new Carat(input.ConvertToBase);

            public static Carat Carats(this byte input) => new Carat(input);
            public static Carat Carats(this short input) => new Carat(input);
            public static Carat Carats(this int input) => new Carat(input);
            public static Carat Carats(this long input) => new Carat(input);

            public static Carat Carats(this float input) => new Carat((decimal)input);
            public static Carat Carats(this double input) => new Carat((decimal)input);
            public static Carat Carats(this decimal input) => new Carat(input);
        }
    }
}
