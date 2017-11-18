namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Gram : Mass
            {
                public Gram(decimal value) : base(value, Conversion.Gram, "G") { }

                public static Gram operator +(Gram firstMeasurement, Gram secondMeasurement)
                {
                    return new Gram((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Gram operator -(Gram firstMeasurement, Gram secondMeasurement)
                {
                    return new Gram((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Gram operator *(Gram firstMeasurement, Gram secondMeasurement)
                {
                    return new Gram((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Gram operator /(Gram firstMeasurement, Gram secondMeasurement)
                {
                    return new Gram((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Gram ToGrams(this Measurement input) => new Gram(input.ConvertToBase);

            public static Gram Grams(this byte input) => new Gram(input);
            public static Gram Grams(this short input) => new Gram(input);
            public static Gram Grams(this int input) => new Gram(input);
            public static Gram Grams(this long input) => new Gram(input);

            public static Gram Grams(this float input) => new Gram((decimal)input);
            public static Gram Grams(this double input) => new Gram((decimal)input);
            public static Gram Grams(this decimal input) => new Gram(input);
        }
    }
}
