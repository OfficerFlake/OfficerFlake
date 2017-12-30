using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Mass : UnitOfMeasurement, IMass
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
			public static readonly string[] MilliGram = { "MilliGram", "MG" };
			public static readonly string[] CentiGram = { "CentiGram" };
			public static readonly string[] DeciGram = { "DeciGram" };
			public static readonly string[] Gram = { "GRAM", "G" };
			public static readonly string[] DecaGram = { "DecaGram" };
			public static readonly string[] HectoGram = { "HectoGram" };
			public static readonly string[] KiloGram = { "KiloGram", "KG" };
			public static readonly string[] MetricTonne = { "METRICTONNE", "TONNE", "T" };

			public static readonly string[] Carat = { "CARAT", "CT" };
			public static readonly string[] Ounce = { "OUNCE", "OZ" };
			public static readonly string[] Pound = { "POUND", "LB" };
			public static readonly string[] Stone = { "STONE", "ST" };

			public static readonly string[] USShortTon = { "USSHORTTON", "SHORTTON", "USTON" };
			public static readonly string[] UKLongTon = { "UKLONGTON", "LONGTON", "UKTON" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.KiloGram;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double MilliGram = 0.000001d;
			public const double CentiGram = 0.00001d;
			public const double DeciGram = 0.0001d;
			public const double Gram = 0.001d;
			public const double DecaGram = 0.01d;
			public const double HectoGram = 0.1d;
			public const double KiloGram = 1d;
			public const double MetricTonne = 1000d;

			public const double Carat = 0.0002d;
			public const double Ounce = 0.02835d;
			public const double Pound = 0.453592d;
			public const double Stone = 6.350293d;

			public const double USShortTon = 907.1847d;
			public const double UKLongTon = 1016.047d;
		}
		public static bool TryParse(string input, out IMass output)
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
				output = new Masses.KiloGram(0);
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
			if (capInput.EndsWithAny(Suffixes.CentiGram))
			{
				output = new Masses.CentiGram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.DecaGram))
			{
				output = new Masses.DecaGram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Gram))
			{
				output = new Masses.Gram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.HectoGram))
			{
				output = new Masses.HectoGram(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.KiloGram))
			{
				output = new Masses.KiloGram(conversion);
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
			output = new Masses.KiloGram(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public ICarat ToCarats()
		{
			return new Masses.Carat(ConvertToBase() / Conversion.Carat);
		}
		public ICentiGram ToCentiGrams()
		{
			return new Masses.CentiGram(ConvertToBase() / Conversion.CentiGram);
		}
		public IDecaGram ToDecaGrams()
		{
			return new Masses.DecaGram(ConvertToBase() / Conversion.DecaGram);
		}
		public IGram ToGrams()
		{
			return new Masses.Gram(ConvertToBase() / Conversion.Gram);
		}
		public IHectoGram ToHectoGrams()
		{
			return new Masses.HectoGram(ConvertToBase() / Conversion.HectoGram);
		}
		public IKiloGram ToKiloGrams()
		{
			return new Masses.KiloGram(ConvertToBase() / Conversion.KiloGram);
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

