using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Month : Duration, IMonth
			{
				#region CTOR
				public Month(double value) : base(value, Conversion.Month, Suffixes.Month) { }
				#endregion
				#region Operators
				public static Month operator +(Month firstMeasurement, Month secondMeasurement)
				{
					return new Month((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Month operator -(Month firstMeasurement, Month secondMeasurement)
				{
					return new Month((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Month operator *(Month firstMeasurement, Month secondMeasurement)
				{
					return new Month((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Month operator /(Month firstMeasurement, Month secondMeasurement)
				{
					return new Month((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Months
			public static Month Months(Byte input) => new Month(input);
			public static Month Months(Int16 input) => new Month(input);
			public static Month Months(Int32 input) => new Month(input);
			public static Month Months(Int64 input) => new Month(input);
			public static Month Months(Single input) => new Month(input);
			public static Month Months(Double input) => new Month(input);
			#endregion
		}
	}
}
