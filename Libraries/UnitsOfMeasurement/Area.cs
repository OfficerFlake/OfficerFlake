using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Debug = System.Diagnostics.Debug;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Area : Measurement, IArea
    {
        #region CTOR
        protected Area(double value, double conversionRatio, string unitSuffix)
: base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }
        #endregion
        private readonly string _unitSuffix;

        #region Operators
        public static implicit operator byte(Area thisArea) => (byte)thisArea.ConvertToBase();
        public static implicit operator short(Area thisArea) => (short)thisArea.ConvertToBase();
        public static implicit operator int(Area thisArea) => (int)thisArea.ConvertToBase();
        public static implicit operator long(Area thisArea) => (long)thisArea.ConvertToBase();

        public static implicit operator float(Area thisArea) => (float)thisArea.ConvertToBase();
        public static implicit operator double(Area thisArea) => thisArea.ConvertToBase();
        public static implicit operator decimal(Area thisArea) => (decimal)thisArea.ConvertToBase();

        public static Area operator +(Area firstMeasurement, Area secondMeasurement)
        {
            return new Area((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffix);
        }
        public static Area operator -(Area firstMeasurement, Area secondMeasurement)
        {
            return new Area((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffix);
        }
        public static Area operator *(Area firstMeasurement, Area secondMeasurement)
        {
            return new Area((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffix);
        }
        public static Area operator /(Area firstMeasurement, Area secondMeasurement)
        {
            return new Area((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffix);
        }
        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion
        internal const string DefaultSuffix = "M^2";

        protected struct Conversion
        {
            public const double SquareMillimeter = 0.000001d;
            public const double SquareCentimeter = 0.0001d;
            public const double SquareMeter = 1d;
            public const double Hectare = 10000d;
            public const double SquareKilometer = 1000000d;
            public const double SquareInch = 0.000645d;
            public const double SquareFoot = 0.092903d;
            public const double SquareYard = 0.836127d;
            public const double Acre = 4046.856d;
            public const double SquareMile = 2589988d;
        }

        protected struct Suffixes
        {
            public static readonly string[] SquareMillimeter = { "SQUAREMILLIMETERS", "SQMM", "MM^2" };
            public static readonly string[] SquareCentimeter = { "SQUARECENTIMETERS", "SQCM", "CM^2" };
            public static readonly string[] SquareMeter = { "SQUAREMETERS", "SQM", "M^2" };
            public static readonly string[] Hectare = { "HECTARES", "HA" };
            public static readonly string[] SquareKilometer = { "SQUAREKILOMETERS", "SQKM", "KM^2" };
            public static readonly string[] SquareInch = { "SQUAREINCHES", "SQIN", "IN^2" };
            public static readonly string[] SquareFoot = { "SQUAREFEET", "SQFT", "FT^2" };
            public static readonly string[] SquareYard = { "SQUAREYARDS", "SQYD", "YD^2" };
            public static readonly string[] Acre = { "ACRES" };
            public static readonly string[] SquareMile = { "SQUAREMILES", "SQMI", "MI^2" };
        }
        #endregion
        public static bool TryParse(string input, out Area output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            double conversion;
            var failed = !double.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Areas.SquareMeter(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.SquareMillimeter))
            {
                output = new Areas.SquareMillimeter(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.SquareCentimeter))
            {
                output = new Areas.SquareCentimeter(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.SquareMeter))
            {
                output = new Areas.SquareMeter(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Hectare))
            {
                output = new Areas.Hectare(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.SquareKilometer))
            {
                output = new Areas.SquareKilometer(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.SquareInch))
            {
                output = new Areas.SquareInch(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.SquareFoot))
            {
                output = new Areas.SquareFoot(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.SquareYard))
            {
                output = new Areas.SquareYard(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Acre))
            {
                output = new Areas.Acre(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.SquareMile))
            {
                output = new Areas.SquareMile(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input area conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Areas.SquareMeter(conversion);
            return false;

        }
    }

    public static partial class Areas
    {
        public static Area TryParse(this string input)
        {
            Area result;
            var success = Area.TryParse(input, out result);
            return result;
        }
    }
}