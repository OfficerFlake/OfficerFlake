﻿using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Angle : Measurement
    {
        #region CTOR
        protected Angle(decimal value, decimal conversionRatio, string unitSuffix)
            : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }
        #endregion
        private readonly string _unitSuffix;

        #region Operators
        public static implicit operator byte(Angle thisAngle) => (byte)thisAngle.ConvertToBase;
        public static implicit operator short(Angle thisAngle) => (short)thisAngle.ConvertToBase;
        public static implicit operator int(Angle thisAngle) => (int)thisAngle.ConvertToBase;
        public static implicit operator long(Angle thisAngle) => (long)thisAngle.ConvertToBase;

        public static implicit operator float(Angle thisAngle) => (float)thisAngle.ConvertToBase;
        public static implicit operator double(Angle thisAngle) => (double)thisAngle.ConvertToBase;
        public static implicit operator decimal(Angle thisAngle) => thisAngle.ConvertToBase;
            
        public static Angle operator +(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase + secondMeasurement.ConvertToBase), 1, Angle.DefaultSuffix);
        }
        public static Angle operator -(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase - secondMeasurement.ConvertToBase), 1, Angle.DefaultSuffix);
        }
        public static Angle operator *(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase * secondMeasurement.ConvertToBase), 1, Angle.DefaultSuffix);
        }
        public static Angle operator /(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase / secondMeasurement.ConvertToBase), 1, Angle.DefaultSuffix);
        }

        public static implicit operator string(Angle thisAngle) => thisAngle.ToString();
        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion
        private const string DefaultSuffix = "RAD";

        protected struct Conversion
        {
            public const decimal Radian = 1.00m;
            public const decimal Degree = 0.017453m;
            public const decimal Gradian = 0.015708m;
        }

        private struct Suffixes
        {
            public static readonly string[] Radian = new[] { "RADIANS", "RADIAN", "RAD" };
            public static readonly string[] Degree = new[] { "DEGREES", "DEGREE", "DEG" };
            public static readonly string[] Gradian = new[] { "GRADIANS", "GRADIAN", "GRAD" };
        }
        #endregion
        public static bool TryParse(string input, out Angle output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            decimal conversion;
            var failed = !decimal.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = new Angles.Degree(0);
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Degree))
            {

                output = new Angles.Degree(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Radian))
            {

                output = new Angles.Radian(conversion);
                return true;
            }

            if (capInput.EndsWithAny(Suffixes.Gradian))
            {

                output = new Angles.Gradian(conversion);
                return true;
            }

            //Type Unrecognised.
            Debug.WriteLine("No Type for input angle conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = new Angles.Degree(conversion);
            return false;

        }
    }

    public static partial class Angles
    {
        public static Angle TryParse(this string input)
        {
            Angle result;
            var success = Angle.TryParse(input, out result);
            return result;
        }
    }
}
