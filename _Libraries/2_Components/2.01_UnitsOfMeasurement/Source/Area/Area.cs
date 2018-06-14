using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Area : UnitOfMeasurement, IArea
	{
		#region CTOR
		protected Area(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Area operator +(Area firstMeasurement, Area secondMeasurement)
		{
			return new Area((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffixes);
		}
		public static Area operator -(Area firstMeasurement, Area secondMeasurement)
		{
			return new Area((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffixes);
		}
		public static Area operator *(Area firstMeasurement, Area secondMeasurement)
		{
			return new Area((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffixes);
		}
		public static Area operator /(Area firstMeasurement, Area secondMeasurement)
		{
			return new Area((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Area.DefaultSuffixes);
		}

		public static implicit operator string(Area thisArea) => thisArea.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] SquareMilliMeter = { "SQUAREMILLIMETERS", "SQMM", "MM^2" };
			public static readonly string[] SquareCentiMeter = { "SQUARECENTIMETERS", "SQCM", "CM^2" };
			public static readonly string[] SquareMeter = { "SQUAREMETERS", "SQM", "M^2" };
			public static readonly string[] SquareNauticalMile = { "SQUARENAUTICALMILE" };
			public static readonly string[] SquareKiloMeter = { "SQUAREKILOMETERS", "SQKM", "KM^2" };
			public static readonly string[] SquareInch = { "SQUAREINCHES", "SQIN", "IN^2" };
			public static readonly string[] SquareFoot = { "SQUAREFEET", "SQFT", "FT^2" };
			public static readonly string[] SquareYard = { "SQUAREYARDS", "SQYD", "YD^2" };
			public static readonly string[] Acre = { "ACRES" };
			public static readonly string[] SquareMile = { "SQUAREMILES", "SQMI", "MI^2" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.SquareMeter;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double Acre = 4046.856d;
			public const double SquareMilliMeter = 0.000001d;
			public const double SquareCentiMeter = 0.0001d;
			public const double SquareMeter = 1d;
			public const double SquareNauticalMile = 3429904d;
			public const double SquareKiloMeter = 1000000d;
			public const double SquareInch = 0.000645d;
			public const double SquareFoot = 0.092903d;
			public const double SquareYard = 0.836127d;
			
			public const double SquareMile = 2589988d;
		}
		public static bool TryParse(string input, out IArea output)
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
				output = new Areas.SquareMeter(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Area
			if (capInput.EndsWithAny(Suffixes.Acre))
			{
				output = new Areas.Acre(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareCentiMeter))
			{
				output = new Areas.SquareCentiMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareFoot))
			{
				output = new Areas.SquareFoot(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareKiloMeter))
			{
				output = new Areas.SquareKiloMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareMeter))
			{
				output = new Areas.SquareMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareMile))
			{
				output = new Areas.SquareMile(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareMilliMeter))
			{
				output = new Areas.SquareMilliMeter(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareNauticalMile))
			{
				output = new Areas.SquareNauticalMile(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.SquareYard))
			{
				output = new Areas.SquareYard(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Area conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Areas.SquareMeter(0);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public IAcre ToAcres()
		{
			return new Areas.Acre(ConvertToBase() / Conversion.Acre);
		}
		public ISquareCentiMeter ToSquareCentiMeters()
		{
			return new Areas.SquareCentiMeter(ConvertToBase() / Conversion.SquareCentiMeter);
		}
		public ISquareFoot ToSquareFeet()
		{
			return new Areas.SquareFoot(ConvertToBase() / Conversion.SquareFoot);
		}
		public ISquareInch ToSquareInches()
		{
			return new Areas.SquareInch(ConvertToBase() / Conversion.SquareInch);
		}
		public ISquareKiloMeter ToSquareKiloMeters()
		{
			return new Areas.SquareKiloMeter(ConvertToBase() / Conversion.SquareKiloMeter);
		}
		public ISquareMeter ToSquareMeters()
		{
			return new Areas.SquareMeter(ConvertToBase() / Conversion.SquareMeter);
		}
		public ISquareMile ToSquareMiles()
		{
			return new Areas.SquareMile(ConvertToBase() / Conversion.SquareMile);
		}
		public ISquareMilliMeter ToSquareMilliMeters()
		{
			return new Areas.SquareMilliMeter(ConvertToBase() / Conversion.SquareMilliMeter);
		}
		public ISquareNauticalMile ToSquareNauticalMiles()
		{
			return new Areas.SquareNauticalMile(ConvertToBase() / Conversion.SquareNauticalMile);
		}
		public ISquareYard ToSquareYards()
		{
			return new Areas.SquareYard(ConvertToBase() / Conversion.SquareYard);
		}
		#endregion
	}
}
