using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Pressure : UnitOfMeasurement, IPressure
	{
		#region CTOR
		protected Pressure(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Pressure operator +(Pressure firstMeasurement, Pressure secondMeasurement)
		{
			return new Pressure((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Pressure.DefaultSuffixes);
		}
		public static Pressure operator -(Pressure firstMeasurement, Pressure secondMeasurement)
		{
			return new Pressure((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Pressure.DefaultSuffixes);
		}
		public static Pressure operator *(Pressure firstMeasurement, Pressure secondMeasurement)
		{
			return new Pressure((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Pressure.DefaultSuffixes);
		}
		public static Pressure operator /(Pressure firstMeasurement, Pressure secondMeasurement)
		{
			return new Pressure((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Pressure.DefaultSuffixes);
		}

		public static implicit operator string(Pressure thisPressure) => thisPressure.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] Atmosphere = new[] { "ATMOSPHERE", "ATM" };
			public static readonly string[] Bar = new[] { "BAR" };
			public static readonly string[] KiloPascal = new[] { "KILOPASCAL", "KP" };
			public static readonly string[] MillimeterOfMercury = new[] { "MMOFMERCURY", "MMHG" };
			public static readonly string[] Pascal = new[] { "PASCAL", "P" };
			public static readonly string[] PoundPerSquareInch = new[] { "LBPERSQUAREIN", "LB/IN^2" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.Pascal;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double Atmosphere = 101325d;
			public const double Bar = 100000d;
			public const double KiloPascal = 1000d;
			public const double MillimeterOfMercury = 133.3d;
			public const double Pascal = 1d;
			public const double PoundPerSquareInch = 6894.757d;
		}
		public static bool TryParse(string input, out Pressure output)
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
				output = new Pressures.Pascal(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Pressure
			if (capInput.EndsWithAny(Suffixes.Atmosphere))
			{
				output = new Pressures.Atmosphere(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Bar))
			{
				output = new Pressures.Bar(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.KiloPascal))
			{
				output = new Pressures.KiloPascal(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.MillimeterOfMercury))
			{
				output = new Pressures.MillimeterOfMercury(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Pascal))
			{
				output = new Pressures.Pascal(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.PoundPerSquareInch))
			{
				output = new Pressures.PoundPerSquareInch(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Pressure conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Pressures.Pascal(conversion);
			return false;
			#endregion
		}
		#endregion

		#region Convert To Subobjects
		public IAtmosphere ToAtmospheres()
		{
			return new Pressures.Atmosphere(ConvertToBase() / Conversion.Atmosphere);
		}
		public IBar ToBars()
		{
			return new Pressures.Bar(ConvertToBase() / Conversion.Bar);
		}
		public IKiloPascal ToKiloPascals()
		{
			return new Pressures.KiloPascal(ConvertToBase() / Conversion.KiloPascal);
		}
		public IMillimeterOfMercury ToMillimetersOfMercury()
		{
			return new Pressures.MillimeterOfMercury(ConvertToBase() / Conversion.MillimeterOfMercury);
		}
		public IPascal ToPascals()
		{
			return new Pressures.Pascal(ConvertToBase() / Conversion.Pascal);
		}
		public IPoundPerSquareInch ToPoundsPerSquareInch()
		{
			return new Pressures.PoundPerSquareInch(ConvertToBase() / Conversion.PoundPerSquareInch);
		}
		#endregion
	}
}


