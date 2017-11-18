namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Angles
        {
            public class Degree : Angle
            {
                public Degree(decimal value) : base(value, Conversion.Degree, "DEG") { }

                public static Degree operator +(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Degree operator -(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Degree operator *(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Degree operator /(Degree firstMeasurement, Degree secondMeasurement)
                {
                    return new Degree((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Degree ToDegrees(this Measurement input) => new Degree(input.ConvertToBase);

            public static Degree Degrees(this byte input) => new Degree(input);
            public static Degree Degrees(this short input) => new Degree(input);
            public static Degree Degrees(this int input) => new Degree(input);
            public static Degree Degrees(this long input) => new Degree(input);

            public static Degree Degrees(this float input) => new Degree((decimal)input);
            public static Degree Degrees(this double input) => new Degree((decimal)input);
            public static Degree Degrees(this decimal input) => new Degree(input);
        }
    }
}
