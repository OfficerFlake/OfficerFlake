using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class CentiGram : Mass, ICentiGram
			{
				#region CTOR
				public CentiGram(double value) : base(value, Conversion.CentiGram, Suffixes.CentiGram) { }
				#endregion
				#region Operators
				public static CentiGram operator +(CentiGram firstMeasurement, CentiGram secondMeasurement)
				{
					return new CentiGram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CentiGram operator -(CentiGram firstMeasurement, CentiGram secondMeasurement)
				{
					return new CentiGram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CentiGram operator *(CentiGram firstMeasurement, CentiGram secondMeasurement)
				{
					return new CentiGram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CentiGram operator /(CentiGram firstMeasurement, CentiGram secondMeasurement)
				{
					return new CentiGram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CentiGrams
			public static CentiGram CentiGrams(this Byte input) => new CentiGram(input);
			public static CentiGram CentiGrams(this Int16 input) => new CentiGram(input);
			public static CentiGram CentiGrams(this Int32 input) => new CentiGram(input);
			public static CentiGram CentiGrams(this Int64 input) => new CentiGram(input);
			public static CentiGram CentiGrams(this Single input) => new CentiGram(input);
			public static CentiGram CentiGrams(this Double input) => new CentiGram(input);
			#endregion
		}
	}
}
