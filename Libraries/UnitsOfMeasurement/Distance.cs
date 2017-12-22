using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Distance : Measurement, IDistance
    {
        #region CTOR

        protected Distance(double value, double conversionRatio, string unitSuffix)
    : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;
	    private double _rawValue;
	    private double _conversionRatio;

	    #region Operators
        public static implicit operator byte(Distance thisDistance) => (byte)thisDistance.ConvertToBase();
        public static implicit operator short(Distance thisDistance) => (short)thisDistance.ConvertToBase();
        public static implicit operator int(Distance thisDistance) => (int)thisDistance.ConvertToBase();
        public static implicit operator long(Distance thisDistance) => (long)thisDistance.ConvertToBase();

        public static implicit operator float(Distance thisDistance) => (float)thisDistance.ConvertToBase();
        public static implicit operator double(Distance thisDistance) => thisDistance.ConvertToBase();
        public static implicit operator decimal(Distance thisDistance) => (decimal)thisDistance.ConvertToBase();

        public static Distance operator +(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1,
                DefaultSuffix);
        }
        public static Distance operator -(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1,
                DefaultSuffix);
        }
        public static Distance operator *(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, DefaultSuffix);
        }
        public static Distance operator /(Distance firstMeasurement, Distance secondMeasurement)
        {
            return new Distance((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, DefaultSuffix);
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
            public const double Nanometer = 0.000000001d;
            public const double Micron = 0.000001d;

            public const double Millimeter = 0.001d;
            public const double Centimeter = 0.01d;
            public const double Meter = 1.00d;
            public const double Kilometer = 1000d;

            public const double Inch = 0.0254d;
            public const double Foot = 0.3048d;
            public const double Yard = 0.9144d;
            public const double Mile = 1609.34d;

            public const double NauticalMile = 1.00d;
        }

        #endregion
        public static bool TryParse(string input, out Distance output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            double conversion;
            var failed = !double.TryParse(extraction, out conversion);

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