using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Speed : UnitOfMeasurement, ISpeed
	{
		#region CTOR
		protected Speed(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Speed operator +(Speed firstMeasurement, Speed secondMeasurement)
		{
			return new Speed((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Speed.DefaultSuffixes);
		}
		public static Speed operator -(Speed firstMeasurement, Speed secondMeasurement)
		{
			return new Speed((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Speed.DefaultSuffixes);
		}
		public static Speed operator *(Speed firstMeasurement, Speed secondMeasurement)
		{
			return new Speed((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Speed.DefaultSuffixes);
		}
		public static Speed operator /(Speed firstMeasurement, Speed secondMeasurement)
		{
			return new Speed((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Speed.DefaultSuffixes);
		}

		public static implicit operator string(Speed thisSpeed) => thisSpeed.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] MilliMeterPerSecond = new[] { "MM/SEC", "MM/S" };
			public static readonly string[] CentiMeterPerSecond = new[] { "CM/SEC", "CM/S" };
			public static readonly string[] MeterPerSecond = new[] { "M/SEC", "M/S" };
			public static readonly string[] KiloMeterPerHour = new[] { "KM/SEC", "KPH", "KM/H", "KMPH" };
			public static readonly string[] FootPerSecond = new[] { "FT/SEC", "FPS", "FT/S" };
			public static readonly string[] MilePerHour = new[] { "MI/HR", "MPH", "MI/H" };
			public static readonly string[] Knot = new[] { "KNOTS", "KT" };
			public static readonly string[] MachAtSeaLevel = new[] { "MACH", "M" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.MeterPerSecond;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double MilliMeterPerSecond = 0.001d;
			public const double CentiMeterPerSecond = 0.01d;
			public const double MeterPerSecond = 1d;
			public const double KiloMeterPerHour = 0.277778d;
			public const double FootPerSecond = 0.3048d;
			public const double MilePerHour = 0.447d;
			public const double Knot = 0.5144d;
			public const double MachAtSeaLevel = 340.3d;
		}
		public static bool TryParse(string input, out ISpeed output)
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
				output = new Speeds.MeterPerSecond(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Speed
			if (capInput.EndsWithAny(Suffixes.CentiMeterPerSecond))
			{
				output = new Speeds.CentiMeterPerSecond(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.FootPerSecond))
			{
				output = new Speeds.FootPerSecond(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.KiloMeterPerHour))
			{
				output = new Speeds.KiloMeterPerHour(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Knot))
			{
				output = new Speeds.Knot(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MachAtSeaLevel))
			{
				output = new Speeds.MachAtSeaLevel(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MeterPerSecond))
			{
				output = new Speeds.MeterPerSecond(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MilePerHour))
			{
				output = new Speeds.MilePerHour(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MilliMeterPerSecond))
			{
				output = new Speeds.MilliMeterPerSecond(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Speed conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Speeds.MeterPerSecond(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public ICentiMeterPerSecond ToCentiMetersPerSecond()
		{
			return new Speeds.CentiMeterPerSecond(ConvertToBase() / Conversion.CentiMeterPerSecond);
		}
		public IFootPerSecond ToFeetPerSecond()
		{
			return new Speeds.FootPerSecond(ConvertToBase() / Conversion.FootPerSecond);
		}
		public IKiloMeterPerHour ToKiloMetersPerHour()
		{
			return new Speeds.KiloMeterPerHour(ConvertToBase() / Conversion.KiloMeterPerHour);
		}
		public IKnot ToKnots()
		{
			return new Speeds.Knot(ConvertToBase() / Conversion.Knot);
		}
		public IMachAtSeaLevel ToMachAtSeaLevel()
		{
			return new Speeds.MachAtSeaLevel(ConvertToBase() / Conversion.MachAtSeaLevel);
		}
		public IMeterPerSecond ToMetersPerSecond()
		{
			return new Speeds.MeterPerSecond(ConvertToBase() / Conversion.MeterPerSecond);
		}
		public IMilePerHour ToMilesPerHour()
		{
			return new Speeds.MilePerHour(ConvertToBase() / Conversion.MilePerHour);
		}
		public IMilliMeterPerSecond ToMilliMetersPerSecond()
		{
			return new Speeds.MilliMeterPerSecond(ConvertToBase() / Conversion.MilliMeterPerSecond);
		}
		#endregion
	}
}


