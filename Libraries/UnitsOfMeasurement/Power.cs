using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Power : Measurement, IPower
	{
		#region CTOR
		protected Power(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Power operator +(Power firstMeasurement, Power secondMeasurement)
		{
			return new Power((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Power.DefaultSuffixes);
		}
		public static Power operator -(Power firstMeasurement, Power secondMeasurement)
		{
			return new Power((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Power.DefaultSuffixes);
		}
		public static Power operator *(Power firstMeasurement, Power secondMeasurement)
		{
			return new Power((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Power.DefaultSuffixes);
		}
		public static Power operator /(Power firstMeasurement, Power secondMeasurement)
		{
			return new Power((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Power.DefaultSuffixes);
		}

		public static implicit operator string(Power thisPower) => thisPower.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] Watt = new[] { "WATT", "W" };
			public static readonly string[] KiloWatt = new[] { "KILOWATT", "KW" };
			public static readonly string[] USHorsePower = new[] { "USHORSEPOWER", "HORSEPOWER", "HP" };
			public static readonly string[] FootPoundPerMinute = new[] { "FT.LB/MIN", "FT*LB/MIN" };
			public static readonly string[] BTUPerMinute = new[] { "BTU/MIN", };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.KiloWatt;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double Watt = 0.001d;
			public const double KiloWatt = 1d;
			public const double USHorsePower = 0.7457d;
			public const double FootPoundPerMinute = 0.000023d;
			public const double BTUPerMinute = 0.017584d;
		}
		public static bool TryParse(string input, out Power output)
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
				output = new Powers.KiloWatt(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Power
			if (capInput.EndsWithAny(Suffixes.BTUPerMinute))
			{
				output = new Powers.BTUPerMinute(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.FootPoundPerMinute))
			{
				output = new Powers.FootPoundPerMinute(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.KiloWatt))
			{
				output = new Powers.KiloWatt(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.USHorsePower))
			{
				output = new Powers.USHorsePower(conversion);
				return true;
			}
			if (capInput.EndsWithAny(Suffixes.Watt))
			{
				output = new Powers.Watt(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Power conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Powers.KiloWatt(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public IBTUPerMinute ToBTUsPerMinute()
		{
			return new Powers.BTUPerMinute(ConvertToBase() / Conversion.BTUPerMinute);
		}
		public IFootPoundPerMinute ToFootPoundsPerMinute()
		{
			return new Powers.FootPoundPerMinute(ConvertToBase() / Conversion.FootPoundPerMinute);
		}
		public IKiloWatt ToKiloWatts()
		{
			return new Powers.KiloWatt(ConvertToBase() / Conversion.KiloWatt);
		}
		public IUSHorsePower ToUSHorsePower()
		{
			return new Powers.USHorsePower(ConvertToBase() / Conversion.USHorsePower);
		}
		public IWatt ToWatts()
		{
			return new Powers.Watt(ConvertToBase() / Conversion.Watt);
		}
		#endregion
	}
}

