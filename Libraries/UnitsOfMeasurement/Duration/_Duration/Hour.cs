using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Hour : Duration, IHour
			{
				#region CTOR
				public Hour(double value) : base(value, Conversion.Hour, Suffixes.Hour) { }
				#endregion
				#region Operators
				public static Hour operator +(Hour firstMeasurement, Hour secondMeasurement)
				{
					return new Hour((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Hour operator -(Hour firstMeasurement, Hour secondMeasurement)
				{
					return new Hour((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Hour operator *(Hour firstMeasurement, Hour secondMeasurement)
				{
					return new Hour((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Hour operator /(Hour firstMeasurement, Hour secondMeasurement)
				{
					return new Hour((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Hours
			public static Hour Hours(this Byte input) => new Hour(input);
			public static Hour Hours(this Int16 input) => new Hour(input);
			public static Hour Hours(this Int32 input) => new Hour(input);
			public static Hour Hours(this Int64 input) => new Hour(input);
			public static Hour Hours(this Single input) => new Hour(input);
			public static Hour Hours(this Double input) => new Hour(input);
			#endregion
		}
	}
}
