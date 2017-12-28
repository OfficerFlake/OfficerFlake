using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class DecaGram : Mass, IDecaGram
			{
				#region CTOR
				public DecaGram(double value) : base(value, Conversion.DecaGram, Suffixes.DecaGram) { }
				#endregion
				#region Operators
				public static DecaGram operator +(DecaGram firstMeasurement, DecaGram secondMeasurement)
				{
					return new DecaGram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static DecaGram operator -(DecaGram firstMeasurement, DecaGram secondMeasurement)
				{
					return new DecaGram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static DecaGram operator *(DecaGram firstMeasurement, DecaGram secondMeasurement)
				{
					return new DecaGram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static DecaGram operator /(DecaGram firstMeasurement, DecaGram secondMeasurement)
				{
					return new DecaGram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].DecaGrams
			public static DecaGram DecaGrams(this Byte input) => new DecaGram(input);
			public static DecaGram DecaGrams(this Int16 input) => new DecaGram(input);
			public static DecaGram DecaGrams(this Int32 input) => new DecaGram(input);
			public static DecaGram DecaGrams(this Int64 input) => new DecaGram(input);
			public static DecaGram DecaGrams(this Single input) => new DecaGram(input);
			public static DecaGram DecaGrams(this Double input) => new DecaGram(input);
			#endregion
		}
	}
}
