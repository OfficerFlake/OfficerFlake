namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class FeetPerSecond : Speed
            {
                public FeetPerSecond(double value) : base(value, Conversion.FeetPerSecond, "FT/S") { }

                public static FeetPerSecond operator +(FeetPerSecond firstMeasurement, FeetPerSecond secondMeasurement)
                {
                    return new FeetPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static FeetPerSecond operator -(FeetPerSecond firstMeasurement, FeetPerSecond secondMeasurement)
                {
                    return new FeetPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static FeetPerSecond operator *(FeetPerSecond firstMeasurement, FeetPerSecond secondMeasurement)
                {
                    return new FeetPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static FeetPerSecond operator /(FeetPerSecond firstMeasurement, FeetPerSecond secondMeasurement)
                {
                    return new FeetPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static FeetPerSecond ToFeetPerSeconds(this Measurement input) => new FeetPerSecond(input.ConvertToBase());

            public static FeetPerSecond FeetPerSeconds(this byte input) => new FeetPerSecond(input);
            public static FeetPerSecond FeetPerSeconds(this short input) => new FeetPerSecond(input);
            public static FeetPerSecond FeetPerSeconds(this int input) => new FeetPerSecond(input);
            public static FeetPerSecond FeetPerSeconds(this long input) => new FeetPerSecond(input);

            public static FeetPerSecond FeetPerSeconds(this float input) => new FeetPerSecond((double)input);
            public static FeetPerSecond FeetPerSeconds(this double input) => new FeetPerSecond((double)input);
            public static FeetPerSecond FeetPerSeconds(this double input) => new FeetPerSecond(input);
        }
    }
}
