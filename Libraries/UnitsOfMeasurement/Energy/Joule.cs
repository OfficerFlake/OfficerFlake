namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Energys
        {
            public class Joule : Energy
            {
                public Joule(decimal value) : base(value, Conversion.Joule, "J") { }

                public static Joule operator +(Joule firstMeasurement, Joule secondMeasurement)
                {
                    return new Joule((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Joule operator -(Joule firstMeasurement, Joule secondMeasurement)
                {
                    return new Joule((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Joule operator *(Joule firstMeasurement, Joule secondMeasurement)
                {
                    return new Joule((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Joule operator /(Joule firstMeasurement, Joule secondMeasurement)
                {
                    return new Joule((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Joule ToJoules(this Measurement input) => new Joule(input.ConvertToBase);

            public static Joule Joules(this byte input) => new Joule(input);
            public static Joule Joules(this short input) => new Joule(input);
            public static Joule Joules(this int input) => new Joule(input);
            public static Joule Joules(this long input) => new Joule(input);

            public static Joule Joules(this float input) => new Joule((decimal)input);
            public static Joule Joules(this double input) => new Joule((decimal)input);
            public static Joule Joules(this decimal input) => new Joule(input);
        }
    }
}
