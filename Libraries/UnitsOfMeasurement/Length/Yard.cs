namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Yard : Length
            {
                public Yard(decimal value) : base(value, Conversion.Yard, "YD") { }

                public static Yard operator +(Yard firstMeasurement, Yard secondMeasurement)
                {
                    return new Yard((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Yard operator -(Yard firstMeasurement, Yard secondMeasurement)
                {
                    return new Yard((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Yard operator *(Yard firstMeasurement, Yard secondMeasurement)
                {
                    return new Yard((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Yard operator /(Yard firstMeasurement, Yard secondMeasurement)
                {
                    return new Yard((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Yard ToYards(this Measurement input) => new Yard(input.ConvertToBase);

            public static Yard Yards(this byte input) => new Yard(input);
            public static Yard Yards(this short input) => new Yard(input);
            public static Yard Yards(this int input) => new Yard(input);
            public static Yard Yards(this long input) => new Yard(input);

            public static Yard Yards(this float input) => new Yard((decimal)input);
            public static Yard Yards(this double input) => new Yard((decimal)input);
            public static Yard Yards(this decimal input) => new Yard(input);
        }
    }
}
