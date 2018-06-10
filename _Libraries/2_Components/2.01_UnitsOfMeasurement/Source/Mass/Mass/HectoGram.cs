using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class HectoGram : Mass, IHectoGram
			{
				#region CTOR
				public HectoGram(double value) : base(value, Conversion.HectoGram, Suffixes.HectoGram) { }
				#endregion
				#region Operators
				public static HectoGram operator +(HectoGram firstMeasurement, HectoGram secondMeasurement)
				{
					return new HectoGram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static HectoGram operator -(HectoGram firstMeasurement, HectoGram secondMeasurement)
				{
					return new HectoGram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static HectoGram operator *(HectoGram firstMeasurement, HectoGram secondMeasurement)
				{
					return new HectoGram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static HectoGram operator /(HectoGram firstMeasurement, HectoGram secondMeasurement)
				{
					return new HectoGram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].HectoGrams
			public static HectoGram HectoGrams(this Byte input) => new HectoGram(input);
			public static HectoGram HectoGrams(this Int16 input) => new HectoGram(input);
			public static HectoGram HectoGrams(this Int32 input) => new HectoGram(input);
			public static HectoGram HectoGrams(this Int64 input) => new HectoGram(input);
			public static HectoGram HectoGrams(this Single input) => new HectoGram(input);
			public static HectoGram HectoGrams(this Double input) => new HectoGram(input);
			#endregion
		}
	}
}
