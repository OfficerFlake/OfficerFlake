namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Temperatures
        {
            public class DegreeFahrenheit : Temperature
            {
                public DegreeFahrenheit(double value) : base(value, "F") { }

                public static DegreeFahrenheit operator +(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
                {
                    return new DegreeFahrenheit((firstMeasurement.Value + secondMeasurement.Value));
                }
                public static DegreeFahrenheit operator -(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
                {
                    return new DegreeFahrenheit((firstMeasurement.Value - secondMeasurement.Value));
                }
                public static DegreeFahrenheit operator *(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
                {
                    return new DegreeFahrenheit((firstMeasurement.Value * secondMeasurement.Value));
                }
                public static DegreeFahrenheit operator /(DegreeFahrenheit firstMeasurement, DegreeFahrenheit secondMeasurement)
                {
                    return new DegreeFahrenheit((firstMeasurement.Value / secondMeasurement.Value));
                }
            }

            public static DegreeCelcius ToCelcius(this DegreeFahrenheit input) => new DegreeCelcius((input-32)*(5d/9d));
            public static DegreeKelvin ToKelvin(this DegreeFahrenheit input) => new DegreeKelvin(input.ToCelcius().ToKelvin());

            public static DegreeFahrenheit DegreesFahrenheit(this byte input) => new DegreeFahrenheit(input);
            public static DegreeFahrenheit DegreesFahrenheit(this short input) => new DegreeFahrenheit(input);
            public static DegreeFahrenheit DegreesFahrenheit(this int input) => new DegreeFahrenheit(input);
            public static DegreeFahrenheit DegreesFahrenheit(this long input) => new DegreeFahrenheit(input);

            public static DegreeFahrenheit DegreesFahrenheit(this float input) => new DegreeFahrenheit((double)input);
            public static DegreeFahrenheit DegreesFahrenheit(this double input) => new DegreeFahrenheit((double)input);
        }
    }
}
