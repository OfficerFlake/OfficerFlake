namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Temperatures
        {
            public class Fahrenheit : Temperature
            {
                public Fahrenheit(decimal value) : base(value, "F") { }

                public static Fahrenheit operator +(Fahrenheit firstMeasurement, Fahrenheit secondMeasurement)
                {
                    return new Fahrenheit((firstMeasurement.Value + secondMeasurement.Value));
                }
                public static Fahrenheit operator -(Fahrenheit firstMeasurement, Fahrenheit secondMeasurement)
                {
                    return new Fahrenheit((firstMeasurement.Value - secondMeasurement.Value));
                }
                public static Fahrenheit operator *(Fahrenheit firstMeasurement, Fahrenheit secondMeasurement)
                {
                    return new Fahrenheit((firstMeasurement.Value * secondMeasurement.Value));
                }
                public static Fahrenheit operator /(Fahrenheit firstMeasurement, Fahrenheit secondMeasurement)
                {
                    return new Fahrenheit((firstMeasurement.Value / secondMeasurement.Value));
                }
            }

            public static Celcius ToCelcius(this Fahrenheit input) => new Celcius((input-32)*(5m/9m));
            public static Kelvin ToKelvin(this Fahrenheit input) => new Kelvin(input.ToCelcius().ToKelvin());

            public static Fahrenheit Fahrenheits(this byte input) => new Fahrenheit(input);
            public static Fahrenheit Fahrenheits(this short input) => new Fahrenheit(input);
            public static Fahrenheit Fahrenheits(this int input) => new Fahrenheit(input);
            public static Fahrenheit Fahrenheits(this long input) => new Fahrenheit(input);

            public static Fahrenheit Fahrenheits(this float input) => new Fahrenheit((decimal)input);
            public static Fahrenheit Fahrenheits(this double input) => new Fahrenheit((decimal)input);
            public static Fahrenheit Fahrenheits(this decimal input) => new Fahrenheit(input);
        }
    }
}
