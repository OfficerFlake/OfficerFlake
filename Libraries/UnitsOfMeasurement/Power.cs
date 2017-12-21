using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Debug = System.Diagnostics.Debug;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Power : Measurement, IPower
    {
        #region CTOR

        protected Power(decimal value, decimal conversionRatio, string unitSuffix)
            : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators
        public static implicit operator byte(Power thisPower) => (byte)thisPower.ConvertToBase;
        public static implicit operator short(Power thisPower) => (short)thisPower.ConvertToBase;
        public static implicit operator int(Power thisPower) => (int)thisPower.ConvertToBase;
        public static implicit operator long(Power thisPower) => (long)thisPower.ConvertToBase;

        public static implicit operator float(Power thisPower) => (float)thisPower.ConvertToBase;
        public static implicit operator double(Power thisPower) => (double)thisPower.ConvertToBase;
        public static implicit operator decimal(Power thisPower) => thisPower.ConvertToBase;

        public static Power operator +(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Power operator -(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Power operator *(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Power operator /(Power firstMeasurement, Power secondMeasurement)
        {
            return new Power((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
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
            public const decimal Watt = 0.001m;
            public const decimal KiloWatt = 1m;
            public const decimal USHorsepower = 0.7457m;
            public const decimal FootPoundsPerMinute = 0.000023m;
            public const decimal BTUsPerMinute = 0.017584m;
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
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

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

                output = new Powers.FootPoundsPerMinute(conversion);
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
