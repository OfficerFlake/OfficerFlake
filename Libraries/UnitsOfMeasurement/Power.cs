using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Debug = System.Diagnostics.Debug;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Power : Measurement, IPower
    {
        #region CTOR

        protected Power(double value, double conversionRatio, string unitSuffix)
            : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators
        public static implicit operator byte(Power thisPower) => (byte)thisPower.ConvertToBase();
        public static implicit operator short(Power thisPower) => (short)thisPower.ConvertToBase();
        public static implicit operator int(Power thisPower) => (int)thisPower.ConvertToBase();
        public static implicit operator long(Power thisPower) => (long)thisPower.ConvertToBase();

        public static implicit operator float(Power thisPower) => (float)thisPower.ConvertToBase();
        public static implicit operator double(Power thisPower) => thisPower.ConvertToBase();
        public static implicit operator decimal(Power thisPower) => (decimal)thisPower.ConvertToBase();

        public static Power operator +(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, DefaultSuffix);
        }
        public static Power operator -(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, DefaultSuffix);
        }
        public static Power operator *(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, DefaultSuffix);
        }
        public static Power operator /(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, DefaultSuffix);
        }
        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        internal static readonly string DefaultSuffix = "KW";

        public struct Conversion
        {
            public const double Watt = 0.001d;
            public const double KiloWatt = 1d;
            public const double USHorsepower = 0.7457d;
	        public const double FootPoundsPerMinute = 0.000023d;
            public const double BTUsPerMinute = 0.017584d;
        }

        private struct Suffixes
        {
            public static readonly string[] Watt = new[] { "WATT", "W" };
            public static readonly string[] KiloWatt = new[] { "KILOWATT", "KW" };
            public static readonly string[] USHorsepower = new[] { "USHORSEPOWER", "HORSEPOWER", "HP" };
            public static readonly string[] FootPoundsPerMinute = new[] { "FT.LB/MIN", "FT*LB/MIN" };
            public static readonly string[] BTUsPerMinute = new[] { "BTU/MIN", };
        }

        #endregion
        public static bool TryParse(string input, out Power output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            double conversion;
            var failed = !double.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Powers.KiloWatt(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Watt))
            {

                output = new Powers.Watt(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.KiloWatt))
            {

                output = new Powers.KiloWatt(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.USHorsepower))
            {

                output = new Powers.USHorsepower(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.FootPoundsPerMinute))
            {

                output = new Powers.FootPoundPerMinute(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.BTUsPerMinute))
            {

                output = new Powers.BTUsPerMinute(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input power conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Powers.KiloWatt(conversion);
            return false;

        }
    }

    public static partial class Powers
    {
        public static Power TryParse(this string input)
        {
            Power result;
            var success = Power.TryParse(input, out result);
            return result;
        }
    }
}
