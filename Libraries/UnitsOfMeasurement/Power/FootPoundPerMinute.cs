using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Powers
		{
			public class FootPoundPerMinute : Power, IFootPoundPerMinute
			{
				#region CTOR
				public FootPoundPerMinute(double value) : base(value, Conversion.FootPoundPerMinute, Suffixes.FootPoundPerMinute) { }
				#endregion
				#region Operators
				public static FootPoundPerMinute operator +(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
				{
					return new FootPoundPerMinute((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static FootPoundPerMinute operator -(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
				{
					return new FootPoundPerMinute((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static FootPoundPerMinute operator *(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
				{
					return new FootPoundPerMinute((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static FootPoundPerMinute operator /(FootPoundPerMinute firstMeasurement, FootPoundPerMinute secondMeasurement)
				{
					return new FootPoundPerMinute((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].FootPoundPerMinutes
			public static FootPoundPerMinute FootPoundPerMinutes(this Byte input) => new FootPoundPerMinute(input);
			public static FootPoundPerMinute FootPoundPerMinutes(this Int16 input) => new FootPoundPerMinute(input);
			public static FootPoundPerMinute FootPoundPerMinutes(this Int32 input) => new FootPoundPerMinute(input);
			public static FootPoundPerMinute FootPoundPerMinutes(this Int64 input) => new FootPoundPerMinute(input);
			public static FootPoundPerMinute FootPoundPerMinutes(this Single input) => new FootPoundPerMinute(input);
			public static FootPoundPerMinute FootPoundPerMinutes(this Double input) => new FootPoundPerMinute(input);
			#endregion
		}
	}
}
