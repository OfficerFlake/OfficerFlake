namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Temperatures
        {
            public class DegreeCelcius : Temperature
            {
                public DegreeCelcius(double value) : base(value, "C") { }

                public static DegreeCelcius operator +(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
                {
                    return new DegreeCelcius((firstMeasurement.Value + secondMeasurement.Value));
                }
                public static DegreeCelcius operator -(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
                {
                    return new DegreeCelcius((firstMeasurement.Value - secondMeasurement.Value));
                }
                public static DegreeCelcius operator *(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
                {
                    return new DegreeCelcius((firstMeasurement.Value * secondMeasurement.Value));
                }
                public static DegreeCelcius operator /(DegreeCelcius firstMeasurement, DegreeCelcius secondMeasurement)
                {
                    return new DegreeCelcius((firstMeasurement.Value / secondMeasurement.Value));
                }
            }

            public static DegreeFahrenheit ToFahrenheit(this DegreeCelcius input) => new DegreeFahrenheit((input*9d/5d)+32);
            public static DegreeKelvin ToKelvin(this DegreeCelcius input) => new DegreeKelvin((input - 273.15d));

            public static DegreeCelcius DegreesCelcius(this byte input) => new DegreeCelcius(input);
            public static DegreeCelcius DegreesCelcius(this short input) => new DegreeCelcius(input);
            public static DegreeCelcius DegreesCelcius(this int input) => new DegreeCelcius(input);
            public static DegreeCelcius DegreesCelcius(this long input) => new DegreeCelcius(input);

            public static DegreeCelcius DegreesCelcius(this float input) => new DegreeCelcius((double)input);
            public static DegreeCelcius DegreesCelcius(this double input) => new DegreeCelcius((double)input);
        }
    }
}
