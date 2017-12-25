using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Distance : Measurement, IDistance
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
			public static readonly string[] Nanometer = new[] { "NANOMETER", "NM" };
			public static readonly string[] Micron = new[] { "MICRON", "MICROMETER", "µM" };

			public static readonly string[] Millimeter = new[] { "MILLIMETER", "MM" };
			public static readonly string[] Centimeter = new[] { "CENTIMETER", "CM" };
			public static readonly string[] Meter = new[] { "METER", "M" };
			public static readonly string[] Kilometer = new[] { "KILOMETER", "KM" };

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
		public static bool TryParse(string input, out Distance output)
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
			if (capInput.EndsWithAny(Suffixes.Meter))
			{
				output = new Distances.Meter(conversion);
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
		public ICentimeter ToCentimeters()
		{
			return new Distances.Centimeter(ConvertToBase() / Conversion.Centimeter);
		}
		public IFoot ToFeet()
		{
			return new Distances.Foot(ConvertToBase() / Conversion.Foot);
		}
		public IInch ToInches()
		{
			return new Distances.Inch(ConvertToBase() / Conversion.Inch);
		}
		public IKilometer ToKilometers()
		{
			return new Distances.Kilometer(ConvertToBase() / Conversion.Kilometer);
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
		public IMillimeter ToMillimeters()
		{
			return new Distances.Millimeter(ConvertToBase() / Conversion.Millimeter);
		}
		public INanometer ToNanometers()
		{
			return new Distances.Nanometer(ConvertToBase() / Conversion.Nanometer);
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
