using System;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
	public class Energy : Measurement, IEnergy
	{
		#region CTOR
		protected Energy(double value, double conversionRatio, string[] unitSuffixes)
			: base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
		#endregion
		#region Operators
		public static Energy operator +(Energy firstMeasurement, Energy secondMeasurement)
		{
			return new Energy((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Energy.DefaultSuffixes);
		}
		public static Energy operator -(Energy firstMeasurement, Energy secondMeasurement)
		{
			return new Energy((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Energy.DefaultSuffixes);
		}
		public static Energy operator *(Energy firstMeasurement, Energy secondMeasurement)
		{
			return new Energy((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Energy.DefaultSuffixes);
		}
		public static Energy operator /(Energy firstMeasurement, Energy secondMeasurement)
		{
			return new Energy((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Energy.DefaultSuffixes);
		}

		public static implicit operator string(Energy thisEnergy) => thisEnergy.ToString();
		public override string ToString()
		{
			return base.ToString() + CurrentSuffixes[0];
		}
		#endregion
		#region Suffix
		protected struct Suffixes
		{
			public static readonly string[] ElectronVolt = new[] { "ELECTRONVOLT", "VOLT", "EV", "V" };

			public static readonly string[] ThermalCalorie = new[] { "THERMALCALORIE" };
			public static readonly string[] FoodCalorie = new[] { "FOODCALORIE", "CALORIE", "CAL" };

			public static readonly string[] Joule = new[] { "JOULE", "J" };
			public static readonly string[] KiloJoule = new[] { "KILOJOULE", "KJ" };

			public static readonly string[] FootPound = new[] { "FOOTPOUND", "FT.LB", "FT*LB", "FTLB" };

			public static readonly string[] BritishThermalUnit = new[] { "BRITISHTHERMALUNIT", "BTU" };
		}
		private static readonly string[] DefaultSuffixes = Suffixes.KiloJoule;
		private readonly string[] CurrentSuffixes = DefaultSuffixes;
		#endregion

		#region Conversion ...
		protected struct Conversion
		{
			public const double ElectronVolt = 1.602177e-22d;

			public const double ThermalCalorie = 0.004184d;
			public const double FoodCalorie = 4.184d;

			public const double Joule = 0.001d;
			public const double KiloJoule = 1.0d;

			public const double FootPound = 0.001356d;

			public const double BritishThermalUnit = 1.055056d;
		}
		public static bool TryParse(string input, out Energy output)
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
				output = new Energys.KiloJoule(0);
				return false;
			}
			#endregion
			#endregion
			#region Convert To Energy
			if (capInput.EndsWithAny(Suffixes.BritishThermalUnit))
			{
				output = new Energys.BritishThermalUnit(conversion);
				return true;
			}
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input Energy conversion. Break here for details...");
			Debug.AddDetailMessage("----" + capInput);
			output = new Energys.KiloJoule(conversion);
			return false;
			#endregion

		}
		#endregion

		#region Convert To Subobjects
		public IBritishThermalUnit ToBritishThermalUnits()
		{
			return new Energys.BritishThermalUnit(ConvertToBase() / Conversion.BritishThermalUnit);
		}
		public IElectronVolt ToElectronVolts()
		{
			return new Energys.ElectronVolt(ConvertToBase() / Conversion.ElectronVolt);
		}
		public IFoodCalorie ToFoodCalories()
		{
			return new Energys.FoodCalorie(ConvertToBase() / Conversion.FoodCalorie);
		}
		public IFootPound ToFootPounds()
		{
			return new Energys.FootPound(ConvertToBase() / Conversion.FootPound);
		}
		public IJoule ToJoules()
		{
			return new Energys.Joule(ConvertToBase() / Conversion.Joule);
		}
		public IKiloJoule ToKiloJoules()
		{
			return new Energys.KiloJoule(ConvertToBase() / Conversion.KiloJoule);
		}
		public IThermalCalorie ToThermalCalories()
		{
			return new Energys.ThermalCalorie(ConvertToBase() / Conversion.ThermalCalorie);
		}
		#endregion
	}
}
