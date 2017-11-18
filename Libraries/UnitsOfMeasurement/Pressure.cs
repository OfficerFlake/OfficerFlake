﻿using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Pressure : Measurement
    {
        #region CTOR

        protected Pressure(decimal value, decimal conversionRatio, string unitSuffix)
: base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }

        #endregion
        private readonly string _unitSuffix;

        #region Operators

        public static implicit operator byte(Pressure thisPressure) => (byte)thisPressure.ConvertToBase;
        public static implicit operator short(Pressure thisPressure) => (short)thisPressure.ConvertToBase;
        public static implicit operator int(Pressure thisPressure) => (int)thisPressure.ConvertToBase;
        public static implicit operator long(Pressure thisPressure) => (long)thisPressure.ConvertToBase;

        public static implicit operator float(Pressure thisPressure) => (float)thisPressure.ConvertToBase;
        public static implicit operator double(Pressure thisPressure) => (double)thisPressure.ConvertToBase;
        public static implicit operator decimal(Pressure thisPressure) => thisPressure.ConvertToBase;

        public static Pressure operator +(Pressure firstMeasurement, Pressure secondMeasurement)
        {
            return new Pressure((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Pressure operator -(Pressure firstMeasurement, Pressure secondMeasurement)
        {
            return new Pressure((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Pressure operator *(Pressure firstMeasurement, Pressure secondMeasurement)
        {
            return new Pressure((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }
        public static Pressure operator /(Pressure firstMeasurement, Pressure secondMeasurement)
        {
            return new Pressure((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, DefaultSuffix);
        }

        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion

        internal static readonly string DefaultSuffix = "P";

        public struct Conversion
        {
            public const decimal Atmosphere = 101325m;
            public const decimal Bar = 100000m;
            public const decimal KiloPascal = 1000m;
            public const decimal MillimetersOfMercury = 133.3m;
            public const decimal Pascal = 1m;
            public const decimal PoundsPerSquareInch = 6894.757m;
        }

        private struct Suffixes
        {
            public static readonly string[] Atmosphere = new[] { "ATMOSPHERE", "ATM" };
            public static readonly string[] Bar = new[] { "BAR" };
            public static readonly string[] KiloPascal = new[] { "KILOPASCAL", "KP" };
            public static readonly string[] MillimetersOfMercury = new[] { "MMOFMERCURY", "MMHG" };
            public static readonly string[] Pascal = new[] { "PASCAL", "P" };
            public static readonly string[] PoundsPerSquareInch = new[] { "LBPERSQUAREIN", "LB/IN^2" };
        }

        #endregion
        public static bool TryParse(string input, out Pressure output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Pressures.Pascal(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Atmosphere))
            {
                output = new Pressures.Atmosphere(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Bar))
            {
                output = new Pressures.Bar(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.KiloPascal))
            {
                output = new Pressures.KiloPascal(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.MillimetersOfMercury))
            {
                output = new Pressures.MillimetersOfMercury(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.Pascal))
            {
                output = new Pressures.Pascal(conversion);
                return true;
            }
            if (capInput.EndsWithAny(Suffixes.PoundsPerSquareInch))
            {
                output = new Pressures.PoundsPerSquareInch(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input pressure conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Pressures.Pascal(conversion);
            return false;

        }
    }

    public static partial class Pressures
    {
        public static Pressure TryParse(this string input)
        {
            Pressure result;
            var success = Pressure.TryParse(input, out result);
            return result;
        }
    }
}
