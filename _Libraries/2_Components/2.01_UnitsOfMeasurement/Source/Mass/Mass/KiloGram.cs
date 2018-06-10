using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class KiloGram : Mass, IKiloGram
			{
				#region CTOR
				public KiloGram(double value) : base(value, Conversion.KiloGram, Suffixes.KiloGram) { }
				#endregion
				#region Operators
				public static KiloGram operator +(KiloGram firstMeasurement, KiloGram secondMeasurement)
				{
					return new KiloGram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KiloGram operator -(KiloGram firstMeasurement, KiloGram secondMeasurement)
				{
					return new KiloGram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KiloGram operator *(KiloGram firstMeasurement, KiloGram secondMeasurement)
				{
					return new KiloGram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KiloGram operator /(KiloGram firstMeasurement, KiloGram secondMeasurement)
				{
					return new KiloGram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KiloGrams
			public static KiloGram KiloGrams(this Byte input) => new KiloGram(input);
			public static KiloGram KiloGrams(this Int16 input) => new KiloGram(input);
			public static KiloGram KiloGrams(this Int32 input) => new KiloGram(input);
			public static KiloGram KiloGrams(this Int64 input) => new KiloGram(input);
			public static KiloGram KiloGrams(this Single input) => new KiloGram(input);
			public static KiloGram KiloGrams(this Double input) => new KiloGram(input);
			#endregion
		}
	}
}
