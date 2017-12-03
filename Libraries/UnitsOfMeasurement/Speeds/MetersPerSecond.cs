﻿namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Speeds
        {
            public class MeterPerSecond : Speed
            {
                public MeterPerSecond(decimal value) : base(value, Conversion.MetersPerSecond, "M/S") { }

                public static MeterPerSecond operator +(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static MeterPerSecond operator -(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static MeterPerSecond operator *(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static MeterPerSecond operator /(MeterPerSecond firstMeasurement, MeterPerSecond secondMeasurement)
                {
                    return new MeterPerSecond((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static MeterPerSecond ToMetersPerSeconds(this Measurement input) => new MeterPerSecond(input.ConvertToBase);

            public static MeterPerSecond MetersPerSeconds(this byte input) => new MeterPerSecond(input);
            public static MeterPerSecond MetersPerSeconds(this short input) => new MeterPerSecond(input);
            public static MeterPerSecond MetersPerSeconds(this int input) => new MeterPerSecond(input);
            public static MeterPerSecond MetersPerSeconds(this long input) => new MeterPerSecond(input);

            public static MeterPerSecond MetersPerSeconds(this float input) => new MeterPerSecond((decimal)input);
            public static MeterPerSecond MetersPerSeconds(this double input) => new MeterPerSecond((decimal)input);
            public static MeterPerSecond MetersPerSeconds(this decimal input) => new MeterPerSecond(input);
        }
    }
}
