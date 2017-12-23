using System.Diagnostics;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Duration : Measurement, IDuration
    {
        #region CTOR
        protected Duration(double value, double conversionRatio, string unitSuffix)
            : base(value, conversionRatio)
        {
            _unitSuffix = unitSuffix;
        }
        #endregion
        private readonly string _unitSuffix;

        #region Operators
        public static implicit operator byte(Duration thisDuration) => (byte)thisDuration.ConvertToBase();
        public static implicit operator short(Duration thisDuration) => (short)thisDuration.ConvertToBase();
        public static implicit operator int(Duration thisDuration) => (int)thisDuration.ConvertToBase();
        public static implicit operator long(Duration thisDuration) => (long)thisDuration.ConvertToBase();

        public static implicit operator float(Duration thisDuration) => (float)thisDuration.ConvertToBase();
        public static implicit operator double(Duration thisDuration) => thisDuration.ConvertToBase();
        public static implicit operator decimal(Duration thisDuration) => (decimal)thisDuration.ConvertToBase();
            
        public static Duration operator +(Duration firstMeasurement, Duration secondMeasurement)
        {
            return new Duration((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffix);
        }
        public static Duration operator -(Duration firstMeasurement, Duration secondMeasurement)
        {
            return new Duration((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffix);
        }
        public static Duration operator *(Duration firstMeasurement, Duration secondMeasurement)
        {
            return new Duration((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffix);
        }
        public static Duration operator /(Duration firstMeasurement, Duration secondMeasurement)
        {
            return new Duration((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffix);
        }

        public static implicit operator string(Duration thisDuration) => thisDuration.ToString();
        #endregion
        public override string ToString()
        {
            return base.ToString() + _unitSuffix;
        }

        #region Conversion
        private const string DefaultSuffix = "RAD";

        protected struct Conversion
        {
            public const double Second =  1.0d;
            public const double Minute = 60.0d;
            public const double Hour = 3600.0d;
	        public const double Day = 86400.0d;
	        public const double Week = 604800.0d;
	        public const double Month = 2678400.0d;
	        public const double Year = 31536000.0d;
		}

        private struct Suffixes
        {
            public static readonly string[] Second = new[] { "SECOND", "SEC", "ss", "s" };
            public static readonly string[] Minute = new[] { "MINUTE", "MIN", "mm", "m" };
            public static readonly string[] Hour = new[] { "HOUR", "HR", "hh", "h" };
	        public static readonly string[] Day = new[] { "DAY", "DD", "D" };
	        public static readonly string[] Week = new[] { "WEEK", "WK", "WW", "W" };
	        public static readonly string[] Month = new[] { "MONTH", "MM", "M" };
	        public static readonly string[] Year = new[] { "YEAR", "YR", "YYYY", "YY", "Y" };
		}
        #endregion
        public static bool TryParse(string input, out Duration output)
        {
            var capInput = input.ToUpperInvariant();
            var extraction = input.ExtractNumberComponentFromMeasurementString();
            double conversion;
            var failed = !double.TryParse(extraction, out conversion);

            if (failed)
            {
                Debug.WriteLine("Measurement Input not successfully converted.");
                Debug.WriteLine("----" + capInput);
                output = 0.Seconds();
                return false;
            }

            if (capInput.EndsWithAny(Suffixes.Year))
            {

                output = new Durations.Year(conversion);
                return true;
            }

			if (capInput.EndsWithAny(Suffixes.Month))
			{

				output = new Durations.Month(conversion);
				return true;
			}

	        if (capInput.EndsWithAny(Suffixes.Week))
	        {

		        output = new Durations.Week(conversion);
		        return true;
	        }

	        if (capInput.EndsWithAny(Suffixes.Day))
	        {
		        output = new Durations.Day(conversion);
		        return true;
	        }

	        if (capInput.EndsWithAny(Suffixes.Hour))
	        {

		        output = new Durations.Hour(conversion);
		        return true;
	        }

	        if (capInput.EndsWithAny(Suffixes.Minute))
	        {

		        output = new Durations.Minute(conversion);
		        return true;
	        }

	        if (capInput.EndsWithAny(Suffixes.Second))
	        {

		        output = new Durations.Second(conversion);
		        return true;
	        }

			//Type Unrecognised.
			Debug.WriteLine("No Type for input Duration conversion. Break here for details...");
            Debug.WriteLine("----" + capInput);
            output = 0.Seconds();
			return false;

        }
	}

	public static class DurationExtensions
	{
		public static Duration TryParse(this string input)
		{
			Duration result = 0.Seconds();
			var success = Duration.TryParse(input, out result);
			return result;
		}
	}
}
