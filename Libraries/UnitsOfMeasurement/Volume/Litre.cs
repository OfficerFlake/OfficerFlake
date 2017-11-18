namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Volumes
        {
            public class Litre : Volume
            {
                public Litre(decimal value) : base(value, Conversion.Litre, "L") { }

                public static Litre operator +(Litre firstMeasurement, Litre secondMeasurement)
                {
                    return new Litre((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase));
                }
                public static Litre operator -(Litre firstMeasurement, Litre secondMeasurement)
                {
                    return new Litre((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase));
                }
                public static Litre operator *(Litre firstMeasurement, Litre secondMeasurement)
                {
                    return new Litre((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase));
                }
                public static Litre operator /(Litre firstMeasurement, Litre secondMeasurement)
                {
                    return new Litre((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase));
                }
            }

            public static Litre ToLitres(this Measurement input) => new Litre(input.ConvertToBase);

            public static Litre Litres(this byte input) => new Litre(input);
            public static Litre Litres(this short input) => new Litre(input);
            public static Litre Litres(this int input) => new Litre(input);
            public static Litre Litres(this long input) => new Litre(input);

            public static Litre Litres(this float input) => new Litre((decimal)input);
            public static Litre Litres(this double input) => new Litre((decimal)input);
            public static Litre Litres(this decimal input) => new Litre(input);
        }
    }
}
