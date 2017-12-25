using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class ThermalCalorie : Energy, IThermalCalorie
			{
				#region CTOR
				public ThermalCalorie(double value) : base(value, Conversion.ThermalCalorie, Suffixes.ThermalCalorie) { }
				#endregion
				#region Operators
				public static ThermalCalorie operator +(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
				{
					return new ThermalCalorie((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static ThermalCalorie operator -(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
				{
					return new ThermalCalorie((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static ThermalCalorie operator *(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
				{
					return new ThermalCalorie((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static ThermalCalorie operator /(ThermalCalorie firstMeasurement, ThermalCalorie secondMeasurement)
				{
					return new ThermalCalorie((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].ThermalCalories
			public static ThermalCalorie ThermalCalories(this Byte input) => new ThermalCalorie(input);
			public static ThermalCalorie ThermalCalories(this Int16 input) => new ThermalCalorie(input);
			public static ThermalCalorie ThermalCalories(this Int32 input) => new ThermalCalorie(input);
			public static ThermalCalorie ThermalCalories(this Int64 input) => new ThermalCalorie(input);
			public static ThermalCalorie ThermalCalories(this Single input) => new ThermalCalorie(input);
			public static ThermalCalorie ThermalCalories(this Double input) => new ThermalCalorie(input);
			#endregion
		}
	}
}
