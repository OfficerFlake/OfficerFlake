using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public abstract class Distance : Measurement, IDistance
    {
        #region CTOR

        protected Distance(decimal value, decimal conversionRatio, string unitSuffix)
    : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;
	    private double _rawValue;
	    private double _conversionRatio;

	    #region Operators
        public static implicit operator byte(Distance thisDistance) => (byte)thisDistance.ConvertToBase;
        public static implicit operator short(Distance thisDistance) => (short)thisDistance.ConvertToBase;
        public static implicit operator int(Distance thisDistance) => (int)thisDistance.ConvertToBase;
        public static implicit operator long(Distance thisDistance) => (long)thisDistance.ConvertToBase;

        public static implicit operator float(Distance thisDistance) => (float)thisDistance.ConvertToBase;
        public static implicit operator double(Distance thisDistance) => (double)thisDistance.ConvertToBase;
        public static implicit operator decimal(Distance thisDistance) => thisDistance.ConvertToBase;

        public static Distance operator +(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1,
                DefaultSuffix);
        }
        public static Distance operator -(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1,
                DefaultSuffix);
        }
        public static Distance operator *(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Distance operator /(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
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
        public static bool TryParse(string input, out Distance output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.AddWarningMessage("Measurement Input not successfully converted.");
                Debug.AddWarningMessage("----" + capInput);
                output = new Distances.Meter(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Nanometer))
            {

                output = new Distances.Nanometer(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Micron))
            {

                output = new Distances.Micron(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Millimeter))
            {

                output = new Distances.Millimeter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Centimeter))
            {

                output = new Distances.Centimeter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Meter))
            {

                output = new Distances.Meter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Kilometer))
            {

                output = new Distances.Kilometer(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Inch))
            {

                output = new Distances.Inch(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Foot))
            {

                output = new Distances.Foot(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Yard))
            {

                output = new Distances.Yard(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Mile))
            {

                output = new Distances.Mile(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.NauticalMile))
            {

                output = new Distances.NauticalMile(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.AddWarningMessage("No Type for input Distance conversion. Break here for details...");
            Debug.AddWarningMessage("----" + capInput);
            output = new Distances.Meter(conversion);
            return false;

        }
	}

    public static partial class Distances
    {
        public static Distance TryParse(this string input)
        {
            Distance result;
            var success = Distance.TryParse(input, out result);
            return result;
        }
    }
}