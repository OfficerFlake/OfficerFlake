using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Decigram : Mass, IDecigram
			{
				#region CTOR
				public Decigram(double value) : base(value, Conversion.Decigram, Suffixes.Decigram) { }
				#endregion
				#region Operators
				public static Decigram operator +(Decigram firstMeasurement, Decigram secondMeasurement)
				{
					return new Decigram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Decigram operator -(Decigram firstMeasurement, Decigram secondMeasurement)
				{
					return new Decigram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Decigram operator *(Decigram firstMeasurement, Decigram secondMeasurement)
				{
					return new Decigram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Decigram operator /(Decigram firstMeasurement, Decigram secondMeasurement)
				{
					return new Decigram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Decigrams
			public static Decigram Decigrams(this Byte input) => new Decigram(input);
			public static Decigram Decigrams(this Int16 input) => new Decigram(input);
			public static Decigram Decigrams(this Int32 input) => new Decigram(input);
			public static Decigram Decigrams(this Int64 input) => new Decigram(input);
			public static Decigram Decigrams(this Single input) => new Decigram(input);
			public static Decigram Decigrams(this Double input) => new Decigram(input);
			#endregion
		}
	}
}
