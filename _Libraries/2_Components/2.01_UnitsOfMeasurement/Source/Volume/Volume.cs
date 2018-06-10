using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Volume : UnitOfMeasurement, IVolume
	{
		#region CTOR
		protected Volume(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Volume operator +(Volume firstMeasurement, Volume secondMeasurement)
		{
			return new Volume((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Volume.DefaultSuffixes);
		}
		public static Volume operator -(Volume firstMeasurement, Volume secondMeasurement)
		{
			return new Volume((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Volume.DefaultSuffixes);
		}
		public static Volume operator *(Volume firstMeasurement, Volume secondMeasurement)
		{
			return new Volume((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Volume.DefaultSuffixes);
		}
		public static Volume operator /(Volume firstMeasurement, Volume secondMeasurement)
		{
			return new Volume((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Volume.DefaultSuffixes);
		}

		public static implicit operator string(Volume thisVolume) => thisVolume.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] MilliLitre = { "MILLILITRE", "ML" };
			public static readonly string[] Litre = { "LITRE", "L" };

			public static readonly string[] CubicCentiMeter = { "CM^3" };
			public static readonly string[] CubicMeter = { "M^3" };

			public static readonly string[] CubicInch = { "IN^3" };
			public static readonly string[] CubicFoot = { "FT^3" };
			public static readonly string[] CubicYard = { "YD^3" };

			public struct US
			{
				public static readonly string[] TeaSpoon = { "TSP" };
				public static readonly string[] TableSpoon = { "TBLSP" };
				public static readonly string[] Cup = { "CUP" };
				public static readonly string[] Pint = { "PINT" };
				public static readonly string[] Quart = { "QUART", "QT" };
				public static readonly string[] Gallon = { "GALLON", "GAL" };
			}

			public struct UK
			{
				public static readonly string[] TeaSpoon = { "UKTSP" };
				public static readonly string[] TableSpoon = { "UKTBLSP" };
				public static readonly string[] FluidOunce = { "FLOZ" };
				public static readonly string[] Pint = { "UKPINT" };
				public static readonly string[] Quart = { "UKQUART", "UKQT" };
				public static readonly string[] Gallon = { "UKGALLON", "UKGAL" };
			}
		}
		private static readonly string[] DefaultSuffixes = Suffixes.Litre;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double MilliLitre = 0.001d;
			public const double Litre = 1.00d;

			public const double CubicCentiMeter = 0.001d;
			public const double CubicMeter = 1000d;

			public const double CubicInch = 0.016387d;
			public const double CubicFoot = 28.31685d;
			public const double CubicYard = 764.5549d;

			public struct US
			{
				public const double TeaSpoon = 0.004929d;
				public const double TableSpoon = 0.014787d;
				public const double Cup = 0.236588d;
				public const double Pint = 0.473176d;
				public const double Quart = 0.946353d;
				public const double Gallon = 3.785412d;
			}

			public struct UK
			{
				public const double TeaSpoon = 0.005919d;
				public const double TableSpoon = 0.017758d;
				public const double FluidOunce = 0.028413d;
				public const double Pint = 0.568261d;
				public const double Quart = 1.136523d;
				public const double Gallon = 4.54609d;
			}
		}
		public static bool TryParse(string input, out IVolume output)
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
				output = new Volumes.Litre(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Volume
			if (capInput.EndsWithAny(Suffixes.UK.FluidOunce))
			{
				output = new Volumes.FluidOunce(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.UK.Gallon))
			{
				output = new Volumes.UKGallon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.UK.Pint))
			{
				output = new Volumes.UKPint(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.UK.Quart))
			{
				output = new Volumes.UKQuart(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.UK.TableSpoon))
			{
				output = new Volumes.UKTableSpoon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.UK.TeaSpoon))
			{
				output = new Volumes.UKTeaSpoon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.US.Cup))
			{
				output = new Volumes.Cup(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.US.Gallon))
			{
				output = new Volumes.USGallon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.US.Pint))
			{
				output = new Volumes.USPint(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.US.Quart))
			{
				output = new Volumes.USQuart(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.US.TableSpoon))
			{
				output = new Volumes.USTableSpoon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.US.TeaSpoon))
			{
				output = new Volumes.USTeaSpoon(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.CubicCentiMeter))
			{
				output = new Volumes.CubicCentiMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.CubicFoot))
			{
				output = new Volumes.CubicFoot(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.CubicInch))
			{
				output = new Volumes.CubicInch(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.CubicMeter))
			{
				output = new Volumes.CubicMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.CubicYard))
			{
				output = new Volumes.CubicYard(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Litre))
			{
				output = new Volumes.Litre(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MilliLitre))
			{
				output = new Volumes.MilliLitre(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Volume conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Volumes.Litre(conversion);
			return false;
			#endregion

		}
		#endregion
		
		#region Convert To Subobjects
		public IFluidOunce ToFluidOunces()
		{
			return new Volumes.FluidOunce(ConvertToBase() / Conversion.UK.FluidOunce);
		}
		public IUKGallon ToUKGallons()
		{
			return new Volumes.UKGallon(ConvertToBase() / Conversion.UK.Gallon);
		}
		public IUKPint ToUKPints()
		{
			return new Volumes.UKPint(ConvertToBase() / Conversion.UK.Pint);
		}
		public IUKQuart ToUKQuarts()
		{
			return new Volumes.UKQuart(ConvertToBase() / Conversion.UK.Quart);
		}
		public IUKTableSpoon ToUKTableSpoons()
		{
			return new Volumes.UKTableSpoon(ConvertToBase() / Conversion.UK.TableSpoon);
		}
		public IUKTeaSpoon ToUKTeaSpoons()
		{
			return new Volumes.UKTeaSpoon(ConvertToBase() / Conversion.UK.TeaSpoon);
		}
		public ICup ToCups()
		{
			return new Volumes.Cup(ConvertToBase() / Conversion.US.Cup);
		}
		public IUSGallon ToUSGallons()
		{
			return new Volumes.USGallon(ConvertToBase() / Conversion.US.Gallon);
		}
		public IUSPint ToUSPints()
		{
			return new Volumes.USPint(ConvertToBase() / Conversion.US.Pint);
		}
		public IUSQuart ToUSQuarts()
		{
			return new Volumes.USQuart(ConvertToBase() / Conversion.US.Quart);
		}
		public IUSTableSpoon ToUSTableSpoons()
		{
			return new Volumes.USTableSpoon(ConvertToBase() / Conversion.US.TableSpoon);
		}
		public IUSTeaSpoon ToUSTeaSpoons()
		{
			return new Volumes.USTeaSpoon(ConvertToBase() / Conversion.US.TeaSpoon);
		}
		public ICubicCentiMeter ToCubicCentiMeters()
		{
			return new Volumes.CubicCentiMeter(ConvertToBase() / Conversion.CubicCentiMeter);
		}
		public ICubicFoot ToCubicFeet()
		{
			return new Volumes.CubicFoot(ConvertToBase() / Conversion.CubicFoot);
		}
		public ICubicInch ToCubicInches()
		{
			return new Volumes.CubicInch(ConvertToBase() / Conversion.CubicInch);
		}
		public ICubicMeter ToCubicMeters()
		{
			return new Volumes.CubicMeter(ConvertToBase() / Conversion.CubicMeter);
		}
		public ICubicYard ToCubicYards()
		{
			return new Volumes.CubicYard(ConvertToBase() / Conversion.CubicYard);
		}
		public ILitre ToLitres()
		{
			return new Volumes.Litre(ConvertToBase() / Conversion.Litre);
		}
		public IMilliLitre ToMilliLitres()
		{
			return new Volumes.MilliLitre(ConvertToBase() / Conversion.MilliLitre);
		}
		#endregion
	}
}


