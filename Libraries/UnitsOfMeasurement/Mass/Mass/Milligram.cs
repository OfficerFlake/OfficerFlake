using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class MilliGram : Mass, IMilliGram
			{
				#region CTOR
				public Miligram(double value) : base(value, Conversion.Milligram, Suffixes.Milligram) { }
				#endregion
				#region Operators
				public static MilliGram operator +(MilliGram firstMeasurement, MilliGram secondMeasurement)
				{
					return new MilliGram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MilliGram operator -(MilliGram firstMeasurement, MilliGram secondMeasurement)
				{
					return new MilliGram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MilliGram operator *(MilliGram firstMeasurement, MilliGram secondMeasurement)
				{
					return new MilliGram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MilliGram operator /(MilliGram firstMeasurement, MilliGram secondMeasurement)
				{
					return new MilliGram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Miligrams
			public static MilliGram Miligrams(this Byte input) => new MilliGram(input);
			public static MilliGram Miligrams(this Int16 input) => new MilliGram(input);
			public static MilliGram Miligrams(this Int32 input) => new MilliGram(input);
			public static MilliGram Miligrams(this Int64 input) => new MilliGram(input);
			public static MilliGram Miligrams(this Single input) => new MilliGram(input);
			public static MilliGram Miligrams(this Double input) => new MilliGram(input);
			#endregion
		}
	}
}
