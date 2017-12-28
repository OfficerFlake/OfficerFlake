using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Powers
		{
			public class BTUPerMinute : Power, IBTUPerMinute
			{
				#region CTOR
				public BTUPerMinute(double value) : base(value, Conversion.BTUPerMinute, Suffixes.BTUPerMinute) { }
				#endregion
				#region Operators
				public static BTUPerMinute operator +(BTUPerMinute firstMeasurement, BTUPerMinute secondMeasurement)
				{
					return new BTUPerMinute((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static BTUPerMinute operator -(BTUPerMinute firstMeasurement, BTUPerMinute secondMeasurement)
				{
					return new BTUPerMinute((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static BTUPerMinute operator *(BTUPerMinute firstMeasurement, BTUPerMinute secondMeasurement)
				{
					return new BTUPerMinute((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static BTUPerMinute operator /(BTUPerMinute firstMeasurement, BTUPerMinute secondMeasurement)
				{
					return new BTUPerMinute((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].BTUPerMinutes
			public static BTUPerMinute BTUPerMinutes(this Byte input) => new BTUPerMinute(input);
			public static BTUPerMinute BTUPerMinutes(this Int16 input) => new BTUPerMinute(input);
			public static BTUPerMinute BTUPerMinutes(this Int32 input) => new BTUPerMinute(input);
			public static BTUPerMinute BTUPerMinutes(this Int64 input) => new BTUPerMinute(input);
			public static BTUPerMinute BTUPerMinutes(this Single input) => new BTUPerMinute(input);
			public static BTUPerMinute BTUPerMinutes(this Double input) => new BTUPerMinute(input);
			#endregion
		}
	}
}
