using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Energy : Measurement
    {
        #region CTOR

        protected Energy(decimal value, decimal conversionRatio, string unitSuffix)
: base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators

        public static implicit operator byte(Energy thisEnergy) => (byte)thisEnergy.ConvertToBase;
        public static implicit operator short(Energy thisEnergy) => (short)thisEnergy.ConvertToBase;
        public static implicit operator int(Energy thisEnergy) => (int)thisEnergy.ConvertToBase;
        public static implicit operator long(Energy thisEnergy) => (long)thisEnergy.ConvertToBase;

        public static implicit operator float(Energy thisEnergy) => (float)thisEnergy.ConvertToBase;
        public static implicit operator double(Energy thisEnergy) => (double)thisEnergy.ConvertToBase;
        public static implicit operator decimal(Energy thisEnergy) => thisEnergy.ConvertToBase;

        public static Energy operator +(Energy firstMeasurement, Energy secondMeasurement)
        {
            return new Energy((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Energy operator -(Energy firstMeasurement, Energy secondMeasurement)
        {
            return new Energy((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Energy operator *(Energy firstMeasurement, Energy secondMeasurement)
        {
            return new Energy((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Energy operator /(Energy firstMeasurement, Energy secondMeasurement)
        {
            return new Energy((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }

        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        private static readonly string DefaultSuffix = "KJ";

        protected struct Conversion
        {
            public const decimal ElectronVolt = 1.602177e-22m;

            public const decimal ThermalCalorie = 0.004184m;
            public const decimal FoodCalories = 4.184m;

            public const decimal Joule = 0.001m;
            public const decimal Kilojoule = 1.0m;

            public const decimal FootPounds = 0.001356m;

            public const decimal BritishThermalUnits = 1.055056m;
        }

        private struct Suffixes
        {
            public static readonly string[] ElectronVolt = new[] { "ELECTRONVOLT", "VOLT", "EV", "V" };

            public static readonly string[] ThermalCalorie = new[] { "THERMALCALORIE"};
            public static readonly string[] FoodCalories = new[] { "FOODCALORIE", "CALORIE", "CAL" };

            public static readonly string[] Joule = new[] { "JOULE", "J" };
            public static readonly string[] Kilojoule = new[] { "KILOJOULE", "KJ"};

            public static readonly string[] FootPounds = new[] { "FOOTPOUND", "FT.LB", "FT*LB", "FTLB" };

            public static readonly string[] BritishThermalUnits = new[] { "BRITISHTHERMALUNIT", "BTU" };
        }

        #endregion
        public static bool TryParse(string input, out Energy output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Energys.Kilojoule(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.ElectronVolt))
            {
                output = new Energys.ElectronVolt(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.ThermalCalorie))
            {
                output = new Energys.ThermalCalorie(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.FoodCalories))
            {
                output = new Energys.FoodCalories(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Joule))
            {
                output = new Energys.Joule(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Kilojoule))
            {
                output = new Energys.Kilojoule(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.FootPounds))
            {
                output = new Energys.FootPounds(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.BritishThermalUnits))
            {
                output = new Energys.BritishThermalUnits(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input energy conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Energys.Kilojoule(conversion);
            return false;

        }
    }

    public static partial class Energys
    {
        public static Energy TryParse(this string input)
        {
            Energy result;
            var success = Energy.TryParse(input, out result);
            return result;
        }
    }
}
