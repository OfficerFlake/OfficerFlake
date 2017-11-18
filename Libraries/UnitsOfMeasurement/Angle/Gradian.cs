namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Angles
        {
            public class Gradian : Angle
            {
                public Gradian(decimal value) : base(value, Conversion.Gradian, "GRAD") { }

                public static Gradian operator +(Gradian firstMeasurement, Gradian secondMeasurement)
                {
                    return new Gradian((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Gradian operator -(Gradian firstMeasurement, Gradian secondMeasurement)
                {
                    return new Gradian((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Gradian operator *(Gradian firstMeasurement, Gradian secondMeasurement)
                {
                    return new Gradian((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Gradian operator /(Gradian firstMeasurement, Gradian secondMeasurement)
                {
                    return new Gradian((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Gradian ToGradians(this Measurement input) => new Gradian(input.ConvertToBase);

            public static Gradian Gradians(this byte input) => new Gradian(input);
            public static Gradian Gradians(this short input) => new Gradian(input);
            public static Gradian Gradians(this int input) => new Gradian(input);
            public static Gradian Gradians(this long input) => new Gradian(input);

            public static Gradian Gradians(this float input) => new Gradian((decimal)input);
            public static Gradian Gradians(this double input) => new Gradian((decimal)input);
            public static Gradian Gradians(this decimal input) => new Gradian(input);
        }
    }
}
