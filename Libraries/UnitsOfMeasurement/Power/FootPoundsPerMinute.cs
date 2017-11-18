namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Powers
        {
            public class FootPoundsPerMinute : Power
            {
                public FootPoundsPerMinute(decimal value) : base(value, Conversion.FootPoundsPerMinute, "FT.LB/MIN") { }

                public static FootPoundsPerMinute operator +(FootPoundsPerMinute firstMeasurement, FootPoundsPerMinute secondMeasurement)
                {
                    return new FootPoundsPerMinute((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static FootPoundsPerMinute operator -(FootPoundsPerMinute firstMeasurement, FootPoundsPerMinute secondMeasurement)
                {
                    return new FootPoundsPerMinute((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static FootPoundsPerMinute operator *(FootPoundsPerMinute firstMeasurement, FootPoundsPerMinute secondMeasurement)
                {
                    return new FootPoundsPerMinute((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static FootPoundsPerMinute operator /(FootPoundsPerMinute firstMeasurement, FootPoundsPerMinute secondMeasurement)
                {
                    return new FootPoundsPerMinute((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static FootPoundsPerMinute ToFootPoundsPerMinutes(this Measurement input) => new FootPoundsPerMinute(input.ConvertToBase);

            public static FootPoundsPerMinute FootPoundsPerMinutes(this byte input) => new FootPoundsPerMinute(input);
            public static FootPoundsPerMinute FootPoundsPerMinutes(this short input) => new FootPoundsPerMinute(input);
            public static FootPoundsPerMinute FootPoundsPerMinutes(this int input) => new FootPoundsPerMinute(input);
            public static FootPoundsPerMinute FootPoundsPerMinutes(this long input) => new FootPoundsPerMinute(input);

            public static FootPoundsPerMinute FootPoundsPerMinutes(this float input) => new FootPoundsPerMinute((decimal)input);
            public static FootPoundsPerMinute FootPoundsPerMinutes(this double input) => new FootPoundsPerMinute((decimal)input);
            public static FootPoundsPerMinute FootPoundsPerMinutes(this decimal input) => new FootPoundsPerMinute(input);
        }
    }
}
