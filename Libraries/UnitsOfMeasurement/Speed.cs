using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Speed : Measurement
    {
        #region CTOR

        protected Speed(decimal value, decimal conversionRatio, string unitSuffix)
: base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators

        public static implicit operator byte(Speed thisSpeed) => (byte)thisSpeed.ConvertToBase;
        public static implicit operator short(Speed thisSpeed) => (short)thisSpeed.ConvertToBase;
        public static implicit operator int(Speed thisSpeed) => (int)thisSpeed.ConvertToBase;
        public static implicit operator long(Speed thisSpeed) => (long)thisSpeed.ConvertToBase;

        public static implicit operator float(Speed thisSpeed) => (float)thisSpeed.ConvertToBase;
        public static implicit operator double(Speed thisSpeed) => (double)thisSpeed.ConvertToBase;
        public static implicit operator decimal(Speed thisSpeed) => thisSpeed.ConvertToBase;

        public static Speed operator +(Speed firstMeasurement, Speed secondMeasurement)
        {
            return new Speed((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Speed operator -(Speed firstMeasurement, Speed secondMeasurement)
        {
            return new Speed((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Speed operator *(Speed firstMeasurement, Speed secondMeasurement)
        {
            return new Speed((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Speed operator /(Speed firstMeasurement, Speed secondMeasurement)
        {
            return new Speed((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }

        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        internal static readonly string DefaultSuffix = "M/S";

        public struct Conversion
        {
            public const decimal MillimetersPerSecond = 0.001m;
            public const decimal CentimetersPerSecond = 0.01m;
            public const decimal MetersPerSecond = 1m;
            public const decimal KilometersPerHour = 0.277778m;
            public const decimal FeetPerSecond = 0.3048m;
            public const decimal MilesPerHour = 0.447m;
            public const decimal Knots = 0.5144m;
            public const decimal MachAtSeaLevel = 340.3m;
        }

        private struct Suffixes
        {
            public static readonly string[] MillimetersPerSecond = new[] {"MM/SEC", "MM/S" };
            public static readonly string[] CentimetersPerSecond = new[] { "CM/SEC", "CM/S" };
            public static readonly string[] MetersPerSecond = new[] { "M/SEC", "M/S" };
            public static readonly string[] KilometersPerHour = new[] { "KM/SEC", "KPH", "KM/H", "KMPH" };
            public static readonly string[] FeetPerSecond = new[] { "FT/SEC", "FPS", "FT/S" };
            public static readonly string[] MilesPerHour = new[] { "MI/HR", "MPH", "MI/H" };
            public static readonly string[] Knots = new[] { "KNOTS", "KT" };
            public static readonly string[] MachAtSeaLevel = new[] { "MACH" };
        }

        #endregion
        public static bool TryParse(string input, out Speed output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Speeds.MetersPerSecond(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.MillimetersPerSecond))
            {

                output = new Speeds.MillimetersPerSecond(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.CentimetersPerSecond))
            {

                output = new Speeds.CentimetersPerSecond(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.MetersPerSecond))
            {

                output = new Speeds.MetersPerSecond(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.KilometersPerHour))
            {

                output = new Speeds.KilometersPerHour(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.FeetPerSecond))
            {

                output = new Speeds.FeetPerSecond(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.MilesPerHour))
            {

                output = new Speeds.MilesPerHour(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Knots))
            {

                output = new Speeds.Knots(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.MachAtSeaLevel))
            {

                output = new Speeds.MachAtSeaLevel(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input speed conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Speeds.MetersPerSecond(conversion);
            return false;

        }
    }

    public static partial class Speeds
    {
        public static Speed TryParse(this string input)
        {
            Speed result;
            var success = Speed.TryParse(input, out result);
            return result;
        }
    }
}
