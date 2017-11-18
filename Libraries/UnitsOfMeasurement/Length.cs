using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Length : Measurement
    {
        #region CTOR

        protected Length(decimal value, decimal conversionRatio, string unitSuffix)
    : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators

        public static implicit operator byte(Length thisLength) => (byte)thisLength.ConvertToBase;
        public static implicit operator short(Length thisLength) => (short)thisLength.ConvertToBase;
        public static implicit operator int(Length thisLength) => (int)thisLength.ConvertToBase;
        public static implicit operator long(Length thisLength) => (long)thisLength.ConvertToBase;

        public static implicit operator float(Length thisLength) => (float)thisLength.ConvertToBase;
        public static implicit operator double(Length thisLength) => (double)thisLength.ConvertToBase;
        public static implicit operator decimal(Length thisLength) => thisLength.ConvertToBase;

        public static Length operator +(Length firstMeasurement, Length secondMeasurement)
        {
            return new Length((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1,
                DefaultSuffix);
        }

        public static Length operator -(Length firstMeasurement, Length secondMeasurement)
        {
            return new Length((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1,
                DefaultSuffix);
        }

        public static Length operator *(Length firstMeasurement, Length secondMeasurement)
        {
            return new Length((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }

        public static Length operator /(Length firstMeasurement, Length secondMeasurement)
        {
            return new Length((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }

        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        private static readonly string DefaultSuffix = "M";

        private struct Suffixes
        {
            public static readonly string[] Nanometer = new[] { "NANOMETER", "NM" };
            public static readonly string[] Micron = new[] { "MICRON", "MICROMETER", "µM" };

            public static readonly string[] Millimeter = new[] { "MILLIMETER", "MM" };
            public static readonly string[] Centimeter = new[] { "CENTIMETER", "CM" };
            public static readonly string[] Meter = new[] { "METER", "M" };
            public static readonly string[] Kilometer = new[] { "KILOMETER", "KM" };

            public static readonly string[] Inch = new[] { "INCH","IN" };
            public static readonly string[] Foot = new[] { "FEET", "FT" };
            public static readonly string[] Yard = new[] { "YARD", "YD" };
            public static readonly string[] Mile = new[] { "MILE", "MI" };

            public static readonly string[] NauticalMile = new[] { "NAUTICALMILE" };
        }

        protected struct Conversion
        {
            public const decimal Nanometer = 0.000000001m;
            public const decimal Micron = 0.000001m;

            public const decimal Millimeter = 0.001m;
            public const decimal Centimeter = 0.01m;
            public const decimal Meter = 1.00m;
            public const decimal Kilometer = 1000m;

            public const decimal Inch = 0.0254m;
            public const decimal Foot = 0.3048m;
            public const decimal Yard = 0.9144m;
            public const decimal Mile = 1609.34m;

            public const decimal NauticalMile = 1.00m;
        }

        #endregion
        public static bool TryParse(string input, out Length output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Lengths.Meter(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Nanometer))
            {

                output = new Lengths.Nanometer(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Micron))
            {

                output = new Lengths.Micron(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Millimeter))
            {

                output = new Lengths.Millimeter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Centimeter))
            {

                output = new Lengths.Centimeter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Meter))
            {

                output = new Lengths.Meter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Kilometer))
            {

                output = new Lengths.Kilometer(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Inch))
            {

                output = new Lengths.Inch(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Foot))
            {

                output = new Lengths.Foot(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Yard))
            {

                output = new Lengths.Yard(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Mile))
            {

                output = new Lengths.Mile(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.NauticalMile))
            {

                output = new Lengths.NauticalMile(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input length conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Lengths.Meter(conversion);
            return false;

        }
    }

    public static partial class Lengths
    {
        public static Length TryParse(this string input)
        {
            Length result;
            var success = Length.TryParse(input, out result);
            return result;
        }
    }
}