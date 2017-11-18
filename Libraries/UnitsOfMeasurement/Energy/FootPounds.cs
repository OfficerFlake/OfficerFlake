namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class FootPounds : Energy
            {
                public FootPounds(decimal value) : base(value, Conversion.FootPounds, "FT.LB") { }

                public static FootPounds operator +(FootPounds firstMeasurement, FootPounds secondMeasurement)
                {
                    return new FootPounds((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static FootPounds operator -(FootPounds firstMeasurement, FootPounds secondMeasurement)
                {
                    return new FootPounds((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static FootPounds operator *(FootPounds firstMeasurement, FootPounds secondMeasurement)
                {
                    return new FootPounds((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static FootPounds operator /(FootPounds firstMeasurement, FootPounds secondMeasurement)
                {
                    return new FootPounds((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static FootPounds ToFootPoundss(this Measurement input) => new FootPounds(input.ConvertToBase);

            public static FootPounds FootPoundss(this byte input) => new FootPounds(input);
            public static FootPounds FootPoundss(this short input) => new FootPounds(input);
            public static FootPounds FootPoundss(this int input) => new FootPounds(input);
            public static FootPounds FootPoundss(this long input) => new FootPounds(input);

            public static FootPounds FootPoundss(this float input) => new FootPounds((decimal)input);
            public static FootPounds FootPoundss(this double input) => new FootPounds((decimal)input);
            public static FootPounds FootPoundss(this decimal input) => new FootPounds(input);
        }
    }
}
