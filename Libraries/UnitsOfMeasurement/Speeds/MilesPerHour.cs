namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class MilesPerHour : Speed
            {
                public MilesPerHour(decimal value) : base(value, Conversion.MilesPerHour, "MPH") { }

                public static MilesPerHour operator +(MilesPerHour firstMeasurement, MilesPerHour secondMeasurement)
                {
                    return new MilesPerHour((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static MilesPerHour operator -(MilesPerHour firstMeasurement, MilesPerHour secondMeasurement)
                {
                    return new MilesPerHour((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static MilesPerHour operator *(MilesPerHour firstMeasurement, MilesPerHour secondMeasurement)
                {
                    return new MilesPerHour((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static MilesPerHour operator /(MilesPerHour firstMeasurement, MilesPerHour secondMeasurement)
                {
                    return new MilesPerHour((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static MilesPerHour ToMilesPerHours(this Measurement input) => new MilesPerHour(input.ConvertToBase);

            public static MilesPerHour MilesPerHours(this byte input) => new MilesPerHour(input);
            public static MilesPerHour MilesPerHours(this short input) => new MilesPerHour(input);
            public static MilesPerHour MilesPerHours(this int input) => new MilesPerHour(input);
            public static MilesPerHour MilesPerHours(this long input) => new MilesPerHour(input);

            public static MilesPerHour MilesPerHours(this float input) => new MilesPerHour((decimal)input);
            public static MilesPerHour MilesPerHours(this double input) => new MilesPerHour((decimal)input);
            public static MilesPerHour MilesPerHours(this decimal input) => new MilesPerHour(input);
        }
    }
}
