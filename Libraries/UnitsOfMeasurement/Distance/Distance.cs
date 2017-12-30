using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Distance : UnitOfMeasurement, IDistance
	{
		#region CTOR
		protected Distance(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Distance operator +(Distance firstMeasurement, Distance secondMeasurement)
		{
			return new Distance((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Distance.DefaultSuffixes);
		}
		public static Distance operator -(Distance firstMeasurement, Distance secondMeasurement)
		{
			return new Distance((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Distance.DefaultSuffixes);
		}
		public static Distance operator *(Distance firstMeasurement, Distance secondMeasurement)
		{
			return new Distance((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Distance.DefaultSuffixes);
		}
		public static Distance operator /(Distance firstMeasurement, Distance secondMeasurement)
		{
			return new Distance((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Distance.DefaultSuffixes);
		}

		public static implicit operator string(Distance thisDistance) => thisDistance.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] NanoMeter = new[] { "NanoMeter", "NM" };
			public static readonly string[] Micron = new[] { "MICRON", "MICROMETER", "µM" };

			public static readonly string[] MilliMeter = new[] { "MilliMeter", "MM" };
			public static readonly string[] CentiMeter = new[] { "CentiMeter", "CM" };
			public static readonly string[] Meter = new[] { "METER", "M" };
			public static readonly string[] KiloMeter = new[] { "KiloMeter", "KM" };

			public static readonly string[] Inch = new[] { "INCH", "IN" };
			public static readonly string[] Foot = new[] { "FEET", "FT" };
			public static readonly string[] Yard = new[] { "YARD", "YD" };
			public static readonly string[] Mile = new[] { "MILE", "MI" };

			public static readonly string[] NauticalMile = new[] { "NAUTICALMILE" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.Meter;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double NanoMeter = 0.000000001d;
			public const double Micron = 0.000001d;

			public const double MilliMeter = 0.001d;
			public const double CentiMeter = 0.01d;
			public const double Meter = 1.00d;
			public const double KiloMeter = 1000d;

			public const double Inch = 0.0254d;
			public const double Foot = 0.3048d;
			public const double Yard = 0.9144d;
			public const double Mile = 1609.34d;

			public const double NauticalMile = 1.00d;
		}
		public static bool TryParse(string input, out IDistance output)
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
				output = new Distances.Meter(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Distance
			if (capInput.EndsWithAny(Suffixes.CentiMeter))
			{
				output = new Distances.CentiMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Foot))
			{
				output = new Distances.Foot(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Inch))
			{
				output = new Distances.Inch(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.KiloMeter))
			{
				output = new Distances.KiloMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Meter))
			{
				output = new Distances.Meter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Micron))
			{
				output = new Distances.Micron(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Mile))
			{
				output = new Distances.Mile(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MilliMeter))
			{
				output = new Distances.MilliMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.NanoMeter))
			{
				output = new Distances.NanoMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.NauticalMile))
			{
				output = new Distances.NauticalMile(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Yard))
			{
				output = new Distances.Yard(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Distance conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Distances.Meter(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public ICentiMeter ToCentiMeters()
		{
			return new Distances.CentiMeter(ConvertToBase() / Conversion.CentiMeter);
		}
		public IFoot ToFeet()
		{
			return new Distances.Foot(ConvertToBase() / Conversion.Foot);
		}
		public IInch ToInches()
		{
			return new Distances.Inch(ConvertToBase() / Conversion.Inch);
		}
		public IKiloMeter ToKiloMeters()
		{
			return new Distances.KiloMeter(ConvertToBase() / Conversion.KiloMeter);
		}
		public IMeter ToMeters()
		{
			return new Distances.Meter(ConvertToBase() / Conversion.Meter);
		}
		public IMicron ToMicrons()
		{
			return new Distances.Micron(ConvertToBase() / Conversion.Micron);
		}
		public IMile ToMiles()
		{
			return new Distances.Mile(ConvertToBase() / Conversion.Mile);
		}
		public IMilliMeter ToMilliMeters()
		{
			return new Distances.MilliMeter(ConvertToBase() / Conversion.MilliMeter);
		}
		public INanoMeter ToNanoMeters()
		{
			return new Distances.NanoMeter(ConvertToBase() / Conversion.NanoMeter);
		}
		public INauticalMile ToNauticalMiles()
		{
			return new Distances.NauticalMile(ConvertToBase() / Conversion.NauticalMile);
		}
		public IYard ToYards()
		{
			return new Distances.Yard(ConvertToBase() / Conversion.Yard);
		}

		#endregion
	}
}
