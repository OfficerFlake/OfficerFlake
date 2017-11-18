namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Powers
        {
            public class BTUsPerMinute : Power
            {
                public BTUsPerMinute(decimal value) : base(value, Conversion.BTUsPerMinute, "BTU/MIN") { }

                public static BTUsPerMinute operator +(BTUsPerMinute firstMeasurement, BTUsPerMinute secondMeasurement)
                {
                    return new BTUsPerMinute((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static BTUsPerMinute operator -(BTUsPerMinute firstMeasurement, BTUsPerMinute secondMeasurement)
                {
                    return new BTUsPerMinute((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static BTUsPerMinute operator *(BTUsPerMinute firstMeasurement, BTUsPerMinute secondMeasurement)
                {
                    return new BTUsPerMinute((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static BTUsPerMinute operator /(BTUsPerMinute firstMeasurement, BTUsPerMinute secondMeasurement)
                {
                    return new BTUsPerMinute((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static BTUsPerMinute ToBTUsPerMinutes(this Measurement input) => new BTUsPerMinute(input.ConvertToBase);

            public static BTUsPerMinute BTUsPerMinutes(this byte input) => new BTUsPerMinute(input);
            public static BTUsPerMinute BTUsPerMinutes(this short input) => new BTUsPerMinute(input);
            public static BTUsPerMinute BTUsPerMinutes(this int input) => new BTUsPerMinute(input);
            public static BTUsPerMinute BTUsPerMinutes(this long input) => new BTUsPerMinute(input);

            public static BTUsPerMinute BTUsPerMinutes(this float input) => new BTUsPerMinute((decimal)input);
            public static BTUsPerMinute BTUsPerMinutes(this double input) => new BTUsPerMinute((decimal)input);
            public static BTUsPerMinute BTUsPerMinutes(this decimal input) => new BTUsPerMinute(input);
        }
    }
}
