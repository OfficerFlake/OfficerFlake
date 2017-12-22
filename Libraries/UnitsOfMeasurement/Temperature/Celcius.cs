namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Temperatures
        {
            public class Celcius : Temperature
            {
                public Celcius(double value) : base(value, "C") { }

                public static Celcius operator +(Celcius firstMeasurement, Celcius secondMeasurement)
                {
                    return new Celcius((firstMeasurement.Value + secondMeasurement.Value));
                }
                public static Celcius operator -(Celcius firstMeasurement, Celcius secondMeasurement)
                {
                    return new Celcius((firstMeasurement.Value - secondMeasurement.Value));
                }
                public static Celcius operator *(Celcius firstMeasurement, Celcius secondMeasurement)
                {
                    return new Celcius((firstMeasurement.Value * secondMeasurement.Value));
                }
                public static Celcius operator /(Celcius firstMeasurement, Celcius secondMeasurement)
                {
                    return new Celcius((firstMeasurement.Value / secondMeasurement.Value));
                }
            }

            public static Fahrenheit ToFahrenheit(this Celcius input) => new Fahrenheit((input*9m/5m)+32);
            public static Kelvin ToKelvin(this Celcius input) => new Kelvin((input - 273.15m));

            public static Celcius Celciuss(this byte input) => new Celcius(input);
            public static Celcius Celciuss(this short input) => new Celcius(input);
            public static Celcius Celciuss(this int input) => new Celcius(input);
            public static Celcius Celciuss(this long input) => new Celcius(input);

            public static Celcius Celciuss(this float input) => new Celcius((double)input);
            public static Celcius Celciuss(this double input) => new Celcius((double)input);
            public static Celcius Celciuss(this double input) => new Celcius(input);
        }
    }
}
