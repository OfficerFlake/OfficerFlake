using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Mass : Measurement, IMass
	{
		#region CTOR
		protected Mass(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Mass operator +(Mass firstMeasurement, Mass secondMeasurement)
		{
			return new Mass((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Mass.DefaultSuffixes);
		}
		public static Mass operator -(Mass firstMeasurement, Mass secondMeasurement)
		{
			return new Mass((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Mass.DefaultSuffixes);
		}
		public static Mass operator *(Mass firstMeasurement, Mass secondMeasurement)
		{
			return new Mass((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Mass.DefaultSuffixes);
		}
		public static Mass operator /(Mass firstMeasurement, Mass secondMeasurement)
		{
			return new Mass((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Mass.DefaultSuffixes);
		}

		public static implicit operator string(Mass thisMass) => thisMass.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] Milligram = { "MILLIGRAM", "MG" };
			public static readonly string[] Centigram = { "CENTIGRAM" };
			public static readonly string[] Decigram = { "DECIGRAM" };
			public static readonly string[] Gram = { "GRAM", "G" };
			public static readonly string[] Decagram = { "DECAGRAM" };
			public static readonly string[] Hectogram = { "HECTOGRAM" };
			public static readonly string[] Kilogram = { "KILOGRAM", "KG" };
			public static readonly string[] MetricTonne = { "METRICTONNE", "TONNE", "T" };

			public static readonly string[] Carat = { "CARAT", "CT" };
			public static readonly string[] Ounce = { "OUNCE", "OZ" };
			public static readonly string[] Pound = { "POUND", "LB" };
			public static readonly string[] Stone = { "STONE", "ST" };

			public static readonly string[] USShortTon = { "USSHORTTON", "SHORTTON", "USTON" };
			public static readonly string[] UKLongTon = { "UKLONGTON", "LONGTON", "UKTON" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.Kilogram;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double Milligram = 0.000001d;
			public const double Centigram = 0.00001d;
			public const double Decigram = 0.0001d;
			public const double Gram = 0.001d;
			public const double Decagram = 0.01d;
			public const double Hectogram = 0.1d;
			public const double Kilogram = 1d;
			public const double MetricTonne = 1000d;

			public const double Carat = 0.0002d;
			public const double Ounce = 0.02835d;
			public const double Pound = 0.453592d;
			public const double Stone = 6.350293d;

			public const double USShortTon = 907.1847d;
			public const double UKLongTon = 1016.047d;
		}
		public static bool TryParse(string input, out Mass output)
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
				output = new Masses.Kilogram(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Mass
			if (capInput.EndsWithAny(Suffixes.Carat))
			{
				output = new Masses.Carat(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Centigram))
			{
				output = new Masses.Centigram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Decagram))
			{
				output = new Masses.Decagram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Gram))
			{
				output = new Masses.Gram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Hectogram))
			{
				output = new Masses.Hectogram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Kilogram))
			{
				output = new Masses.Kilogram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MetricTonne))
			{
				output = new Masses.MetricTonne(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Ounce))
			{
				output = new Masses.Ounce(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Pound))
			{
				output = new Masses.Pound(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Stone))
			{
				output = new Masses.Stone(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.UKLongTon))
			{
				output = new Masses.UKLongTon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.USShortTon))
			{
				output = new Masses.USShortTon(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Mass conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Masses.Kilogram(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public ICarat ToCarats()
		{
			return new Masses.Carat(ConvertToBase() / Conversion.Carat);
		}
		public ICentigram ToCentigrams()
		{
			return new Masses.Centigram(ConvertToBase() / Conversion.Centigram);
		}
		public IDecagram ToDecagrams()
		{
			return new Masses.Decagram(ConvertToBase() / Conversion.Decagram);
		}
		public IGram ToGrams()
		{
			return new Masses.Gram(ConvertToBase() / Conversion.Gram);
		}
		public IHectogram ToHectograms()
		{
			return new Masses.Hectogram(ConvertToBase() / Conversion.Hectogram);
		}
		public IKilogram ToKilograms()
		{
			return new Masses.Kilogram(ConvertToBase() / Conversion.Kilogram);
		}
		public IMetricTonne ToMetricTonnes()
		{
			return new Masses.MetricTonne(ConvertToBase() / Conversion.MetricTonne);
		}
		public IOunce ToOunces()
		{
			return new Masses.Ounce(ConvertToBase() / Conversion.Ounce);
		}
		public IPound ToPounds()
		{
			return new Masses.Pound(ConvertToBase() / Conversion.Pound);
		}
		public IStone ToStones()
		{
			return new Masses.Stone(ConvertToBase() / Conversion.Stone);
		}
		public IUKLongTon TUKLongTons()
		{
			return new Masses.UKLongTon(ConvertToBase() / Conversion.UKLongTon);
		}
		public IUSShortTon TUSShortTons()
		{
			return new Masses.USShortTon(ConvertToBase() / Conversion.USShortTon);
		}
		#endregion
	}
}

