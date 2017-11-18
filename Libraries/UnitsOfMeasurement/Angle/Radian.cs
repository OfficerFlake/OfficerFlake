namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Angles
        {
            public class Radian : Angle
            {
                public Radian(decimal value) : base(value, Conversion.Radian, "RAD") { }

                public static Radian operator +(Radian firstMeasurement, Radian secondMeasurement)
                {
                    return new Radian((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Radian operator -(Radian firstMeasurement, Radian secondMeasurement)
                {
                    return new Radian((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Radian operator *(Radian firstMeasurement, Radian secondMeasurement)
                {
                    return new Radian((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Radian operator /(Radian firstMeasurement, Radian secondMeasurement)
                {
                    return new Radian((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Radian ToRadians(this Measurement input) => new Radian(input.ConvertToBase);

            public static Radian Radians(this byte input) => new Radian(input);
            public static Radian Radians(this short input) => new Radian(input);
            public static Radian Radians(this int input) => new Radian(input);
            public static Radian Radians(this long input) => new Radian(input);

            public static Radian Radians(this float input) => new Radian((decimal)input);
            public static Radian Radians(this double input) => new Radian((decimal)input);
            public static Radian Radians(this decimal input) => new Radian(input);
        }
    }
}
