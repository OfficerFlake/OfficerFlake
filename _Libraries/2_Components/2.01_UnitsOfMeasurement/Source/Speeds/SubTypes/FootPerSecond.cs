using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class FootPerSecond : Speed, IFootPerSecond
			{
				#region CTOR
				public FootPerSecond(double value) : base(value, Conversion.FootPerSecond, Suffixes.FootPerSecond) { }
				#endregion
				#region Operators
				public static FootPerSecond operator +(FootPerSecond firstMeasurement, FootPerSecond secondMeasurement)
				{
					return new FootPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static FootPerSecond operator -(FootPerSecond firstMeasurement, FootPerSecond secondMeasurement)
				{
					return new FootPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static FootPerSecond operator *(FootPerSecond firstMeasurement, FootPerSecond secondMeasurement)
				{
					return new FootPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static FootPerSecond operator /(FootPerSecond firstMeasurement, FootPerSecond secondMeasurement)
				{
					return new FootPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].FootPerSeconds
			public static FootPerSecond FootPerSeconds(this Byte input) => new FootPerSecond(input);
			public static FootPerSecond FootPerSeconds(this Int16 input) => new FootPerSecond(input);
			public static FootPerSecond FootPerSeconds(this Int32 input) => new FootPerSecond(input);
			public static FootPerSecond FootPerSeconds(this Int64 input) => new FootPerSecond(input);
			public static FootPerSecond FootPerSeconds(this Single input) => new FootPerSecond(input);
			public static FootPerSecond FootPerSeconds(this Double input) => new FootPerSecond(input);
			#endregion
		}
	}
}
