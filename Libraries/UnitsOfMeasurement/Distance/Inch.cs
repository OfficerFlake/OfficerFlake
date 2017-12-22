namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Distances
		{
            public class Inch : Distance
			{
                public Inch(double value) : base(value, Conversion.Inch, "IN") { }

                public static Inch operator +(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static Inch operator -(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static Inch operator *(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static Inch operator /(Inch firstMeasurement, Inch secondMeasurement)
                {
                    return new Inch((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static Inch ToInches(this Measurement input) => new Inch(input.ConvertToBase());

            public static Inch Inches(this byte input) => new Inch(input);
            public static Inch Inches(this short input) => new Inch(input);
            public static Inch Inches(this int input) => new Inch(input);
            public static Inch Inches(this long input) => new Inch(input);

            public static Inch Inches(this float input) => new Inch((double)input);
            public static Inch Inches(this double input) => new Inch((double)input);
        }
    }
}
