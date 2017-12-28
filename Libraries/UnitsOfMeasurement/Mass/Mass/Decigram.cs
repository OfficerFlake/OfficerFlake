using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class DeciGram : Mass, IDeciGram
			{
				#region CTOR
				public DeciGram(double value) : base(value, Conversion.DeciGram, Suffixes.DeciGram) { }
				#endregion
				#region Operators
				public static DeciGram operator +(DeciGram firstMeasurement, DeciGram secondMeasurement)
				{
					return new DeciGram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static DeciGram operator -(DeciGram firstMeasurement, DeciGram secondMeasurement)
				{
					return new DeciGram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static DeciGram operator *(DeciGram firstMeasurement, DeciGram secondMeasurement)
				{
					return new DeciGram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static DeciGram operator /(DeciGram firstMeasurement, DeciGram secondMeasurement)
				{
					return new DeciGram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].DeciGrams
			public static DeciGram DeciGrams(this Byte input) => new DeciGram(input);
			public static DeciGram DeciGrams(this Int16 input) => new DeciGram(input);
			public static DeciGram DeciGrams(this Int32 input) => new DeciGram(input);
			public static DeciGram DeciGrams(this Int64 input) => new DeciGram(input);
			public static DeciGram DeciGrams(this Single input) => new DeciGram(input);
			public static DeciGram DeciGrams(this Double input) => new DeciGram(input);
			#endregion
		}
	}
}
