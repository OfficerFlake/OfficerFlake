using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Debug = System.Diagnostics.Debug;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Mass : Measurement, IMass
    {
        #region CTOR

        protected Mass(decimal value, decimal conversionRatio, string unitSuffix)
: base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators

        public static implicit operator byte(Mass thisMass) => (byte)thisMass.ConvertToBase;
        public static implicit operator short(Mass thisMass) => (short)thisMass.ConvertToBase;
        public static implicit operator int(Mass thisMass) => (int)thisMass.ConvertToBase;
        public static implicit operator long(Mass thisMass) => (long)thisMass.ConvertToBase;

        public static implicit operator float(Mass thisMass) => (float)thisMass.ConvertToBase;
        public static implicit operator double(Mass thisMass) => (double)thisMass.ConvertToBase;
        public static implicit operator decimal(Mass thisMass) => thisMass.ConvertToBase;

        public static Mass operator +(Mass firstMeasurement, Mass secondMeasurement)
        {
            return new Mass((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Mass operator -(Mass firstMeasurement, Mass secondMeasurement)
        {
            return new Mass((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Mass operator *(Mass firstMeasurement, Mass secondMeasurement)
        {
            return new Mass((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Mass operator /(Mass firstMeasurement, Mass secondMeasurement)
        {
            return new Mass((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }

        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        internal static readonly string DefaultSuffix = "KG";

        public struct Conversion
        {
            public const decimal Milligram = 0.000001m;
            public const decimal Centigram = 0.00001m;
            public const decimal Decigram = 0.0001m;
            public const decimal Gram = 0.001m;
            public const decimal Decagram = 0.01m;
            public const decimal Hectogram = 0.1m;
            public const decimal Kilogram = 1m;
            public const decimal MetricTonne = 1000m;

            public const decimal Carat = 0.0002m;
            public const decimal Ounce = 0.02835m;
            public const decimal Pound = 0.453592m;
            public const decimal Stone = 6.350293m;

            public const decimal USShortTon = 907.1847m;
            public const decimal UKLongTon = 1016.047m;
        }

        private struct Suffixes
        {
            public static readonly string[] Milligram = new[] { "MILLIGRAM", "MG" };
            public static readonly string[] Centigram = new[] { "CENTIGRAM" };
            public static readonly string[] Decigram = new[] { "DECIGRAM" };
            public static readonly string[] Gram = new[] { "GRAM", "G" };
            public static readonly string[] Decagram = new[] { "DECAGRAM" };
            public static readonly string[] Hectogram = new[] { "HECTOGRAM" };
            public static readonly string[] Kilogram = new[] { "KILOGRAM", "KG" };
            public static readonly string[] MetricTonne = new[] { "METRICTONNE", "TONNE", "T" };

            public static readonly string[] Carat = new[] { "CARAT", "CT" };
            public static readonly string[] Ounce = new[] { "OUNCE", "OZ" };
            public static readonly string[] Pound = new[] { "POUND", "LB" };
            public static readonly string[] Stone = new[] { "STONE", "ST" };

            public static readonly string[] USShortTon = new[] { "USSHORTTON", "SHORTTON", "USTON" };
            public static readonly string[] UKLongTon = new[] { "UKLONGTON", "LONGTON", "UKTON" };
        }

        #endregion
        public static bool TryParse(string input, out Mass output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Masses.Kilogram(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Milligram))
            {

                output = new Masses.Milligram(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Centigram))
            {

                output = new Masses.Centigram(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Decigram))
            {

                output = new Masses.Decigram(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Hectogram))
            {

                output = new Masses.Hectogram(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Kilogram))
            {

                output = new Masses.Kilogram(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.MetricTonne))
            {

                output = new Masses.MetricTonne(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Carat))
            {

                output = new Masses.Carat(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Pound))
            {

                output = new Masses.Pound(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Stone))
            {

                output = new Masses.Stone(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.USShortTon))
            {

                output = new Masses.USShortTon(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.UKLongTon))
            {

                output = new Masses.UKLongTon(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input mass conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Masses.Kilogram(conversion);
            return false;

        }
    }

    public static partial class Masses
    {
        public static Mass TryParse(this string input)
        {
            Mass result;
            var success = Mass.TryParse(input, out result);
            return result;
        }
    }
}
