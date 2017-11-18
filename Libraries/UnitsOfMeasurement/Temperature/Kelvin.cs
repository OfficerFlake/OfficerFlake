namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Temperatures
        {
            public class Kelvin : Temperature
            {
                public Kelvin(decimal value) : base(value, "K") { Value = value; }

                public static Kelvin operator +(Kelvin firstMeasurement, Kelvin secondMeasurement)
                {
                    return new Kelvin((firstMeasurement.Value + secondMeasurement.Value));
                }
                public static Kelvin operator -(Kelvin firstMeasurement, Kelvin secondMeasurement)
                {
                    return new Kelvin((firstMeasurement.Value - secondMeasurement.Value));
                }
                public static Kelvin operator *(Kelvin firstMeasurement, Kelvin secondMeasurement)
                {
                    return new Kelvin((firstMeasurement.Value * secondMeasurement.Value));
                }
                public static Kelvin operator /(Kelvin firstMeasurement, Kelvin secondMeasurement)
                {
                    return new Kelvin((firstMeasurement.Value / secondMeasurement.Value));
                }
            }

            public static Fahrenheit ToFahrenheit(this Kelvin input) => new Fahrenheit(input.ToCelcius().ToFahrenheit());
            public static Celcius ToCelcius(this Kelvin input) => new Celcius((input + 273.15m));

            public static Kelvin Kelvins(this byte input) => new Kelvin(input);
            public static Kelvin Kelvins(this short input) => new Kelvin(input);
            public static Kelvin Kelvins(this int input) => new Kelvin(input);
            public static Kelvin Kelvins(this long input) => new Kelvin(input);

            public static Kelvin Kelvins(this float input) => new Kelvin((decimal)input);
            public static Kelvin Kelvins(this double input) => new Kelvin((decimal)input);
            public static Kelvin Kelvins(this decimal input) => new Kelvin(input);
        }
    }
}
