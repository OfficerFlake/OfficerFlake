using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Energys
		{
			public class BritishThermalUnit : Energy, IBritishThermalUnit
			{
				#region CTOR
				public BritishThermalUnit(double value) : base(value, Conversion.BritishThermalUnit, Suffixes.BritishThermalUnit) { }
				#endregion
				#region Operators
				public static BritishThermalUnit operator +(BritishThermalUnit firstMeasurement, BritishThermalUnit secondMeasurement)
				{
					return new BritishThermalUnit((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static BritishThermalUnit operator -(BritishThermalUnit firstMeasurement, BritishThermalUnit secondMeasurement)
				{
					return new BritishThermalUnit((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static BritishThermalUnit operator *(BritishThermalUnit firstMeasurement, BritishThermalUnit secondMeasurement)
				{
					return new BritishThermalUnit((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static BritishThermalUnit operator /(BritishThermalUnit firstMeasurement, BritishThermalUnit secondMeasurement)
				{
					return new BritishThermalUnit((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].BritishThermalUnits
			public static BritishThermalUnit BritishThermalUnits(this Byte input) => new BritishThermalUnit(input);
			public static BritishThermalUnit BritishThermalUnits(this Int16 input) => new BritishThermalUnit(input);
			public static BritishThermalUnit BritishThermalUnits(this Int32 input) => new BritishThermalUnit(input);
			public static BritishThermalUnit BritishThermalUnits(this Int64 input) => new BritishThermalUnit(input);
			public static BritishThermalUnit BritishThermalUnits(this Single input) => new BritishThermalUnit(input);
			public static BritishThermalUnit BritishThermalUnits(this Double input) => new BritishThermalUnit(input);
			#endregion
		}
	}
}
