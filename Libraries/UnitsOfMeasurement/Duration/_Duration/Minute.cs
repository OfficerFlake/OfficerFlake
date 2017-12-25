using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Durations
		{
			public class Minute : Duration, IMinute
			{
				#region CTOR
				public Minute(double value) : base(value, Conversion.Minute, Suffixes.Minute) { }
				#endregion
				#region Operators
				public static Minute operator +(Minute firstMeasurement, Minute secondMeasurement)
				{
					return new Minute((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Minute operator -(Minute firstMeasurement, Minute secondMeasurement)
				{
					return new Minute((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Minute operator *(Minute firstMeasurement, Minute secondMeasurement)
				{
					return new Minute((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Minute operator /(Minute firstMeasurement, Minute secondMeasurement)
				{
					return new Minute((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Minutes
			public static Minute Minutes(this Byte input) => new Minute(input);
			public static Minute Minutes(this Int16 input) => new Minute(input);
			public static Minute Minutes(this Int32 input) => new Minute(input);
			public static Minute Minutes(this Int64 input) => new Minute(input);
			public static Minute Minutes(this Single input) => new Minute(input);
			public static Minute Minutes(this Double input) => new Minute(input);
			#endregion
		}
	}
}
