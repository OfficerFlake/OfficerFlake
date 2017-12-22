namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public static partial class Temperatures
        {
            public class DegreeKelvin : Temperature
            {
                public DegreeKelvin(double value) : base(value, "K") { Value = value; }

                public static DegreeKelvin operator +(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
                {
                    return new DegreeKelvin((firstMeasurement.Value + secondMeasurement.Value));
                }
                public static DegreeKelvin operator -(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
                {
                    return new DegreeKelvin((firstMeasurement.Value - secondMeasurement.Value));
                }
                public static DegreeKelvin operator *(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
                {
                    return new DegreeKelvin((firstMeasurement.Value * secondMeasurement.Value));
                }
                public static DegreeKelvin operator /(DegreeKelvin firstMeasurement, DegreeKelvin secondMeasurement)
                {
                    return new DegreeKelvin((firstMeasurement.Value / secondMeasurement.Value));
                }
            }

            public static DegreeFahrenheit ToFahrenheit(this DegreeKelvin input) => new DegreeFahrenheit(input.ToCelcius().ToFahrenheit());
            public static DegreeCelcius ToCelcius(this DegreeKelvin input) => new DegreeCelcius((input + 273.15d));

            public static DegreeKelvin DegreesKelvin(this byte input) => new DegreeKelvin(input);
            public static DegreeKelvin DegreesKelvin(this short input) => new DegreeKelvin(input);
            public static DegreeKelvin DegreesKelvin(this int input) => new DegreeKelvin(input);
            public static DegreeKelvin DegreesKelvin(this long input) => new DegreeKelvin(input);

            public static DegreeKelvin DegreesKelvin(this float input) => new DegreeKelvin((double)input);
            public static DegreeKelvin DegreesKelvin(this double input) => new DegreeKelvin((double)input);
        }
    }
}
