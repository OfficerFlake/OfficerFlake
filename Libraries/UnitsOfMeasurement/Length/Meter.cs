namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Lengths
        {
            public class Meter : Length
            {
                public Meter(decimal value) : base(value, Conversion.Meter, "M") { }

                public static Meter operator +(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Meter operator -(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Meter operator *(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Meter operator /(Meter firstMeasurement, Meter secondMeasurement)
                {
                    return new Meter((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Meter ToMeters(this Length input) => new Meter(input.ConvertToBase);

            public static Meter Meters(this byte input) => new Meter(input);
            public static Meter Meters(this short input) => new Meter(input);
            public static Meter Meters(this int input) => new Meter(input);
            public static Meter Meters(this long input) => new Meter(input);

            public static Meter Meters(this float input) => new Meter((decimal)input);
            public static Meter Meters(this double input) => new Meter((decimal)input);
            public static Meter Meters(this decimal input) => new Meter(input);
        }
    }
}
