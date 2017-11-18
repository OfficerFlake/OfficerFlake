namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Masses
        {
            public class Pound : Mass
            {
                public Pound(decimal value) : base(value, Conversion.Pound, "LB") { }

                public static Pound operator +(Pound firstMeasurement, Pound secondMeasurement)
                {
                    return new Pound((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Pound operator -(Pound firstMeasurement, Pound secondMeasurement)
                {
                    return new Pound((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Pound operator *(Pound firstMeasurement, Pound secondMeasurement)
                {
                    return new Pound((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Pound operator /(Pound firstMeasurement, Pound secondMeasurement)
                {
                    return new Pound((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Pound ToPounds(this Measurement input) => new Pound(input.ConvertToBase);

            public static Pound Pounds(this byte input) => new Pound(input);
            public static Pound Pounds(this short input) => new Pound(input);
            public static Pound Pounds(this int input) => new Pound(input);
            public static Pound Pounds(this long input) => new Pound(input);

            public static Pound Pounds(this float input) => new Pound((decimal)input);
            public static Pound Pounds(this double input) => new Pound((decimal)input);
            public static Pound Pounds(this decimal input) => new Pound(input);
        }
    }
}
