using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Volume : Measurement
    {
        #region CTOR

        protected Volume(double value, double conversionRatio, string unitSuffix)
            : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators

        public static implicit operator byte(Volume thisVolume) => (byte) thisVolume.ConvertToBase();
        public static implicit operator short(Volume thisVolume) => (short) thisVolume.ConvertToBase();
        public static implicit operator int(Volume thisVolume) => (int) thisVolume.ConvertToBase();
        public static implicit operator long(Volume thisVolume) => (long) thisVolume.ConvertToBase();

        public static implicit operator float(Volume thisVolume) => (float) thisVolume.ConvertToBase();
        public static implicit operator double(Volume thisVolume) => thisVolume.ConvertToBase();
        public static implicit operator decimal(Volume thisVolume) => (decimal)thisVolume.ConvertToBase();

        public static Volume operator +(Volume firstMeasurement, Volume secondMeasurement)
        {
            return new Volume((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1,
                DefaultSuffix);
        }

        public static Volume operator -(Volume firstMeasurement, Volume secondMeasurement)
        {
            return new Volume((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1,
                DefaultSuffix);
        }

        public static Volume operator *(Volume firstMeasurement, Volume secondMeasurement)
        {
            return new Volume((firstMeasurement.ConvertToBase()*secondMeasurement.ConvertToBase()), 1,
                DefaultSuffix);
        }

        public static Volume operator /(Volume firstMeasurement, Volume secondMeasurement)
        {
            return new Volume((firstMeasurement.ConvertToBase()/secondMeasurement.ConvertToBase()), 1,
                DefaultSuffix);
        }

        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        internal static readonly string DefaultSuffix = "L";

        protected struct Conversion
        {
            public const double Millilitre = 0.001d;
            public const double Litre = 1.00d;

            public const double CubicCentimeter = 0.001d;
            public const double CubicMeter = 1000d;

            public const double CubicInch = 0.016387d;
            public const double CubicFoot = 28.31685d;
            public const double CubicYard = 764.5549d;

            public struct US
            {
                public const double TeaSpoon = 0.004929d;
                public const double TableSpoon = 0.014787d;
                public const double Cup = 0.236588d;
                public const double Pint = 0.473176d;
                public const double Quart = 0.946353d;
                public const double Gallon = 3.785412d;
            }

            public struct UK
            {
                public const double TeaSpoon = 0.005919d;
                public const double TableSpoon = 0.017758d;
                public const double FluidOunce = 0.028413d;
                public const double Pint = 0.568261d;
                public const double Quart = 1.136523d;
                public const double Gallon = 4.54609d;
            }
        }

        private struct Suffixes
        {
            public static readonly string[] Millilitre = {"MILLILITRE", "ML"};
            public static readonly string[] Litre = {"LITRE", "L"};

            public static readonly string[] CubicCentimeter = {"CM^3"};
            public static readonly string[] CubicMeter = {"M^3"};

            public static readonly string[] CubicInch = {"IN^3"};
            public static readonly string[] CubicFoot = {"FT^3"};
            public static readonly string[] CubicYard = {"YD^3"};

            public struct US
            {
                public static readonly string[] TeaSpoon = {"TSP"};
                public static readonly string[] TableSpoon = {"TBLSP"};
                public static readonly string[] Cup = {"CUP"};
                public static readonly string[] Pint = {"PINT"};
                public static readonly string[] Quart = {"QUART", "QT"};
                public static readonly string[] Gallon = {"GALLON", "GAL"};
            }

            public struct UK
            {
                public static readonly string[] TeaSpoon = {"UKTSP"};
                public static readonly string[] TableSpoon = {"UKTBLSP"};
                public static readonly string[] FluidOunce = {"FLOZ"};
                public static readonly string[] Pint = {"UKPINT"};
                public static readonly string[] Quart = {"UKQUART", "UKQT"};
                public static readonly string[] Gallon = {"UKGALLON", "UKGAL"};
            }
        }

        #endregion

        public static bool TryParse(string input, out Volume output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            double conversion;
            var failed = !double.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Volumes.CubicMeter(0);
                return false;
            }

            if (capInput.EndsWith("ML"))
            {

                output = new Volumes.Millilitre(conversion);
                return true;
            }
            if (capInput.EndsWithAny("LITRES"))
            {

                output = new Volumes.Litre(conversion);
                return true;
            }

            if (capInput.EndsWithAny("CM^3"))
            {

                output = new Volumes.CubicCentimeter(conversion);
                return true;
            }
            if (capInput.EndsWithAny("M^3"))
            {

                output = new Volumes.CubicMeter(conversion);
                return true;
            }
            if (capInput.EndsWithAny("IN^3"))
            {

                output = new Volumes.CubicInch(conversion);
                return true;
            }
            if (capInput.EndsWithAny("FT^3"))
            {

                output = new Volumes.CubicFoot(conversion);
                return true;
            }
            if (capInput.EndsWithAny("YD^3"))
            {

                output = new Volumes.CubicYard(conversion);
                return true;
            }

            if (capInput.EndsWith("TSP"))
            {

                output = new Volumes.USTeaSpoon(conversion);
                return true;
            }
            if (capInput.EndsWith("TBLSP"))
            {

                output = new Volumes.USTableSpoon(conversion);
                return true;
            }
            if (capInput.EndsWithAny("CUPS"))
            {

                output = new Volumes.USCup(conversion);
                return true;
            }
            if (capInput.EndsWithAny("PINTS"))
            {

                output = new Volumes.USPint(conversion);
                return true;
            }
            if (capInput.EndsWithAny("QUARTS"))
            {

                output = new Volumes.USQuart(conversion);
                return true;
            }
            if (capInput.EndsWithAny("GALLONS"))
            {

                output = new Volumes.USGallon(conversion);
                return true;
            }
            if (capInput.EndsWith("UKTSP"))
            {

                output = new Volumes.UKTeaSpoon(conversion);
                return true;
            }
            if (capInput.EndsWith("UKTBLSP"))
            {

                output = new Volumes.UKTableSpoon(conversion);
                return true;
            }
            if (capInput.EndsWith("UKFLUIDOZ"))
            {

                output = new Volumes.UKFluidOunce(conversion);
                return true;
            }
            if (capInput.EndsWith("UKPINT"))
            {

                output = new Volumes.UKPint(conversion);
                return true;
            }
            if (capInput.EndsWith("UKQUART"))
            {

                output = new Volumes.UKQuart(conversion);
                return true;
            }
            if (capInput.EndsWith("UKGALLON"))
            {

                output = new Volumes.UKGallon(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input volume conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Volumes.CubicMeter(conversion);
            return false;

        }
    }

    public static partial class Volumes
    {
        public static Volume TryParse(this string input)
        {
            Volume result;
            var success = Volume.TryParse(input, out result);
            return result;
        }
    }
}