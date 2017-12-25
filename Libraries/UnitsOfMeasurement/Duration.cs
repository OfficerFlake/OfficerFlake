using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Duration : Measurement, IDuration
	{
		#region CTOR
		protected Duration(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Duration operator +(Duration firstMeasurement, Duration secondMeasurement)
		{
			return new Duration((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffixes);
		}
		public static Duration operator -(Duration firstMeasurement, Duration secondMeasurement)
		{
			return new Duration((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffixes);
		}
		public static Duration operator *(Duration firstMeasurement, Duration secondMeasurement)
		{
			return new Duration((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffixes);
		}
		public static Duration operator /(Duration firstMeasurement, Duration secondMeasurement)
		{
			return new Duration((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Duration.DefaultSuffixes);
		}

		public static implicit operator string(Duration thisDuration) => thisDuration.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] Second = new[] { "SECOND", "SEC", "ss", "s" };
			public static readonly string[] Minute = new[] { "MINUTE", "MIN", "mm", "m" };
			public static readonly string[] Hour = new[] { "HOUR", "HR", "hh", "h" };
			public static readonly string[] Day = new[] { "DAY", "DD", "D" };
			public static readonly string[] Week = new[] { "WEEK", "WK", "WW", "W" };
			public static readonly string[] Month = new[] { "MONTH", "MM", "M" };
			public static readonly string[] Year = new[] { "YEAR", "YR", "YYYY", "YY", "Y" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.Second;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double Second = 1.0d;
			public const double Minute = 60.0d;
			public const double Hour = 3600.0d;
			public const double Day = 86400.0d;
			public const double Week = 604800.0d;
			public const double Month = 2678400.0d;
			public const double Year = 31536000.0d;
		}
		public static bool TryParse(string input, out Duration output)
		{
			#region Prepare Variables
			string capInput = input.ToUpperInvariant();
			string extraction = input.ExtractNumberComponentFromMeasurementString();
			double conversion = 0;
			#endregion

			#region Convert To Double
			bool failed = !double.TryParse(extraction, out conversion);
			if (failed)
			{
				Debug.AddDetailMessage("Measurement Input not successfully converted.");
				Debug.AddDetailMessage("----" + capInput);
				output = new Durations.Second(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Duration
			if (capInput.EndsWithAny(Suffixes.Second))
			{
				output = new Durations.Second(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Duration conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Durations.Second(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public ISecond ToSeconds()
		{
			return new Durations.Second(ConvertToBase() / Conversion.Second);
		}
		public IMinute ToMinutes()
		{
			return new Durations.Minute(ConvertToBase() / Conversion.Minute);
		}
		public IHour ToHours()
		{
			return new Durations.Hour(ConvertToBase() / Conversion.Hour);
		}
		public IDay ToDays()
		{
			return new Durations.Day(ConvertToBase() / Conversion.Day);
		}
		public IWeek ToWeeks()
		{
			return new Durations.Week(ConvertToBase() / Conversion.Week);
		}
		public IMonth ToMonths()
		{
			return new Durations.Month(ConvertToBase() / Conversion.Month);
		}
		public IYear ToYears()
		{
			return new Durations.Year(ConvertToBase() / Conversion.Year);
		}
		#endregion
	}
}
