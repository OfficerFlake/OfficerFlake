using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Second : Duration, ISecond
			{
				#region CTOR
				public Second(double value) : base(value, Conversion.Second, Suffixes.Second) { }
				#endregion
				#region Operators
				public static Second operator +(Second firstMeasurement, Second secondMeasurement)
				{
					return new Second((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Second operator -(Second firstMeasurement, Second secondMeasurement)
				{
					return new Second((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Second operator *(Second firstMeasurement, Second secondMeasurement)
				{
					return new Second((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Second operator /(Second firstMeasurement, Second secondMeasurement)
				{
					return new Second((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Seconds
			public static Second Seconds(this Byte input) => new Second(input);
			public static Second Seconds(this Int16 input) => new Second(input);
			public static Second Seconds(this Int32 input) => new Second(input);
			public static Second Seconds(this Int64 input) => new Second(input);
			public static Second Seconds(this Single input) => new Second(input);
			public static Second Seconds(this Double input) => new Second(input);
			#endregion
		}
	}
}
