namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class FootPound : Energy
            {
                public FootPound(double value) : base(value, Conversion.FootPounds, "FT.LB") { }

                public static FootPound operator +(FootPound firstMeasurement, FootPound secondMeasurement)
                {
                    return new FootPound((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static FootPound operator -(FootPound firstMeasurement, FootPound secondMeasurement)
                {
                    return new FootPound((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static FootPound operator *(FootPound firstMeasurement, FootPound secondMeasurement)
                {
                    return new FootPound((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static FootPound operator /(FootPound firstMeasurement, FootPound secondMeasurement)
                {
                    return new FootPound((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static FootPound ToFootPoundss(this Measurement input) => new FootPound(input.ConvertToBase());

            public static FootPound FootPounds(this byte input) => new FootPound(input);
            public static FootPound FootPounds(this short input) => new FootPound(input);
            public static FootPound FootPounds(this int input) => new FootPound(input);
            public static FootPound FootPounds(this long input) => new FootPound(input);

            public static FootPound FootPounds(this float input) => new FootPound((double)input);
            public static FootPound FootPounds(this double input) => new FootPound(input);

        }
    }
}
