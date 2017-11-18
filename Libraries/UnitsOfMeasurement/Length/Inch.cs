namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Inch : Length
            {
                public Inch(decimal value) : base(value, Conversion.Inch, "IN") { }

                public static Inch operator +(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Inch operator -(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Inch operator *(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Inch operator /(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Inch ToInches(this Measurement input) => new Inch(input.ConvertToBase);

            public static Inch Inches(this byte input) => new Inch(input);
            public static Inch Inches(this short input) => new Inch(input);
            public static Inch Inches(this int input) => new Inch(input);
            public static Inch Inches(this long input) => new Inch(input);

            public static Inch Inches(this float input) => new Inch((decimal)input);
            public static Inch Inches(this double input) => new Inch((decimal)input);
            public static Inch Inches(this decimal input) => new Inch(input);
        }
    }
}
