using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Year : Duration, IYear
			{
				#region CTOR
				public Year(double value) : base(value, Conversion.Year, Suffixes.Year) { }
				#endregion
				#region Operators
				public static Year operator +(Year firstMeasurement, Year secondMeasurement)
				{
					return new Year((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Year operator -(Year firstMeasurement, Year secondMeasurement)
				{
					return new Year((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Year operator *(Year firstMeasurement, Year secondMeasurement)
				{
					return new Year((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Year operator /(Year firstMeasurement, Year secondMeasurement)
				{
					return new Year((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Years
			public static Year Years(Byte input) => new Year(input);
			public static Year Years(Int16 input) => new Year(input);
			public static Year Years(Int32 input) => new Year(input);
			public static Year Years(Int64 input) => new Year(input);
			public static Year Years(Single input) => new Year(input);
			public static Year Years(Double input) => new Year(input);
			#endregion
		}
	}
}
