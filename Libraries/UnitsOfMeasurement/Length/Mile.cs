namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Mile : Length
            {
                public Mile(decimal value) : base(value, Conversion.Mile, "MI") { }

                public static Mile operator +(Mile firstMeasurement, Mile secondMeasurement)
                {
                    return new Mile((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Mile operator -(Mile firstMeasurement, Mile secondMeasurement)
                {
                    return new Mile((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Mile operator *(Mile firstMeasurement, Mile secondMeasurement)
                {
                    return new Mile((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Mile operator /(Mile firstMeasurement, Mile secondMeasurement)
                {
                    return new Mile((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Mile ToMiles(this Measurement input) => new Mile(input.ConvertToBase);

            public static Mile Miles(this byte input) => new Mile(input);
            public static Mile Miles(this short input) => new Mile(input);
            public static Mile Miles(this int input) => new Mile(input);
            public static Mile Miles(this long input) => new Mile(input);

            public static Mile Miles(this float input) => new Mile((decimal)input);
            public static Mile Miles(this double input) => new Mile((decimal)input);
            public static Mile Miles(this decimal input) => new Mile(input);
        }
    }
}
