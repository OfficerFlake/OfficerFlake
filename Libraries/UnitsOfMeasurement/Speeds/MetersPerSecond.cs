namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class MeterPerSecond : Speed
            {
                public MeterPerSecond(double value) : base(value, Conversion.MetersPerSecond, "M/S") { }

                public static MeterPerSecond operator +(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
                }
                public static MeterPerSecond operator -(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
                }
                public static MeterPerSecond operator *(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
                }
                public static MeterPerSecond operator /(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
                }
            }

            public static MeterPerSecond ToMetersPerSeconds(this Measurement input) => new MeterPerSecond(input.ConvertToBase());

            public static MeterPerSecond MetersPerSecond(this byte input) => new MeterPerSecond(input);
            public static MeterPerSecond MetersPerSecond(this short input) => new MeterPerSecond(input);
            public static MeterPerSecond MetersPerSecond(this int input) => new MeterPerSecond(input);
            public static MeterPerSecond MetersPerSecond(this long input) => new MeterPerSecond(input);

            public static MeterPerSecond MetersPerSecond(this float input) => new MeterPerSecond((double)input);
            public static MeterPerSecond MetersPerSecond(this double input) => new MeterPerSecond((double)input);
            public static MeterPerSecond MetersPerSecond(this double input) => new MeterPerSecond(input);
        }
    }
}
