using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class KiloPascal : Pressure, IKiloPascal
			{
				#region CTOR
				public KiloPascal(double value) : base(value, Conversion.KiloPascal, Suffixes.KiloPascal) { }
				#endregion
				#region Operators
				public static KiloPascal operator +(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
				{
					return new KiloPascal((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KiloPascal operator -(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
				{
					return new KiloPascal((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KiloPascal operator *(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
				{
					return new KiloPascal((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KiloPascal operator /(KiloPascal firstMeasurement, KiloPascal secondMeasurement)
				{
					return new KiloPascal((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KiloPascals
			public static KiloPascal KiloPascals(this Byte input) => new KiloPascal(input);
			public static KiloPascal KiloPascals(this Int16 input) => new KiloPascal(input);
			public static KiloPascal KiloPascals(this Int32 input) => new KiloPascal(input);
			public static KiloPascal KiloPascals(this Int64 input) => new KiloPascal(input);
			public static KiloPascal KiloPascals(this Single input) => new KiloPascal(input);
			public static KiloPascal KiloPascals(this Double input) => new KiloPascal(input);
			#endregion
		}
	}
}
