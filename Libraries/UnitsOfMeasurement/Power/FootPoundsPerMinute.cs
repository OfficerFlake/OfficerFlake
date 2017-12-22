namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Powers
        {
            public class FootPoundPerMinute : Power
            {
                public FootPoundPerMinute(double value) : base(value, Conversion.FootPoundsPerMinute, "FT.LB/MIN") { }

                public static FootPoundPerMinute operator +(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
                {
                    return new FootPoundPerMinute((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static FootPoundPerMinute operator -(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
                {
                    return new FootPoundPerMinute((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static FootPoundPerMinute operator *(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
                {
                    return new FootPoundPerMinute((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static FootPoundPerMinute operator /(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
                {
                    return new FootPoundPerMinute((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static FootPoundPerMinute ToFootPoundsPerMinutes(this Measurement input) => new FootPoundPerMinute(input.ConvertToBase());

            public static FootPoundPerMinute FootPoundsPerMinute(this byte input) => new FootPoundPerMinute(input);
            public static FootPoundPerMinute FootPoundsPerMinute(this short input) => new FootPoundPerMinute(input);
            public static FootPoundPerMinute FootPoundsPerMinute(this int input) => new FootPoundPerMinute(input);
            public static FootPoundPerMinute FootPoundsPerMinute(this long input) => new FootPoundPerMinute(input);

            public static FootPoundPerMinute FootPoundsPerMinute(this float input) => new FootPoundPerMinute((double)input);
            public static FootPoundPerMinute FootPoundsPerMinute(this double input) => new FootPoundPerMinute((double)input);
        }
    }
}
