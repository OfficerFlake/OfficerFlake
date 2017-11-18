namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Ounce : Mass
            {
                public Ounce(decimal value) : base(value, Conversion.Ounce, "OZ") { }

                public static Ounce operator +(Ounce firstMeasurement, Ounce secondMeasurement)
                {
                    return new Ounce((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Ounce operator -(Ounce firstMeasurement, Ounce secondMeasurement)
                {
                    return new Ounce((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Ounce operator *(Ounce firstMeasurement, Ounce secondMeasurement)
                {
                    return new Ounce((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Ounce operator /(Ounce firstMeasurement, Ounce secondMeasurement)
                {
                    return new Ounce((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Ounce ToOunces(this Measurement input) => new Ounce(input.ConvertToBase);

            public static Ounce Ounces(this byte input) => new Ounce(input);
            public static Ounce Ounces(this short input) => new Ounce(input);
            public static Ounce Ounces(this int input) => new Ounce(input);
            public static Ounce Ounces(this long input) => new Ounce(input);

            public static Ounce Ounces(this float input) => new Ounce((decimal)input);
            public static Ounce Ounces(this double input) => new Ounce((decimal)input);
            public static Ounce Ounces(this decimal input) => new Ounce(input);
        }
    }
}
