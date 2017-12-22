using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public class Temperature
        {
            #region CTOR

            protected Temperature(double value, string unitSuffix)
            {
                Value = value;
                _unitSuffix = unitSuffix;
            }

            #endregion
            public double Value { get; set; }
            private readonly string _unitSuffix;

            #region Operators

            public static implicit operator byte(Temperature thisTemperature) => (byte)thisTemperature.Value;
            public static implicit operator short(Temperature thisTemperature) => (short)thisTemperature.Value;
            public static implicit operator int(Temperature thisTemperature) => (int)thisTemperature.Value;
            public static implicit operator long(Temperature thisTemperature) => (long)thisTemperature.Value;

            public static implicit operator float(Temperature thisTemperature) => (float)thisTemperature.Value;
            public static implicit operator double(Temperature thisTemperature) => thisTemperature.Value;
            public static implicit operator decimal(Temperature thisTemperature) => (decimal)thisTemperature.Value;

            #endregion
            public override string ToString()
            {
                return Value.ToString();
            }

            #region Conversion

            private struct Suffixes
            {
                public static readonly string[] Celcius = new[] { "CELCIUS", "*C", "C" };
                public static readonly string[] Fahrenheit = new[] { "FAHRENHEIT", "*F", "F" };
                public static readonly string[] Kelvin = new[] { "KELVIN", "*K", "K" };
            }

            #endregion

            public static bool TryParse(string input, out Temperature output)
            {
                var capInput = input.ToUpperInvariant();
                var extraction = input.ExtractNumberComponentFromMeasurementString();
                double conversion;
                var failed = !double.TryParse(extraction, out conversion);

                if (failed)
                {
                    Debug.WriteLine("Measurement Input not successfully converted.");
                    Debug.WriteLine("----" + capInput);
                    output = new Temperatures.Celcius(0);
                    return false;
                }

                if (capInput.EndsWithAny(Suffixes.Celcius))
                {

                    output = new Temperatures.Celcius(conversion);
                    return true;
                }

                if (capInput.EndsWithAny(Suffixes.Fahrenheit))
                {

                    output = new Temperatures.Fahrenheit(conversion);
                    return true;
                }

                if (capInput.EndsWithAny(Suffixes.Kelvin))
                {

                    output = new Temperatures.Kelvin(conversion);
                    return true;
                }

                //Type Unrecognised.
                Debug.WriteLine("No Type for input temperature conversion. Break here for details...");
                Debug.WriteLine("----" + capInput);
                output = new Temperatures.Celcius(conversion);
                return false;

            }
        }

        public static partial class Temperatures
        {
            public static Temperature TryParse(this string input)
            {
                Temperature result;
                var success = Temperature.TryParse(input, out result);
                return result;
            }
        }
    }
}
