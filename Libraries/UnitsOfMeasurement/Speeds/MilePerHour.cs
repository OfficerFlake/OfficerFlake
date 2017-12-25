using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class MilePerHour : Speed, IMilePerHour
			{
				#region CTOR
				public MilePerHour(double value) : base(value, Conversion.MilePerHour, Suffixes.MilePerHour) { }
				#endregion
				#region Operators
				public static MilePerHour operator +(MilePerHour firstMeasurement, MilePerHour secondMeasurement)
				{
					return new MilePerHour((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MilePerHour operator -(MilePerHour firstMeasurement, MilePerHour secondMeasurement)
				{
					return new MilePerHour((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MilePerHour operator *(MilePerHour firstMeasurement, MilePerHour secondMeasurement)
				{
					return new MilePerHour((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MilePerHour operator /(MilePerHour firstMeasurement, MilePerHour secondMeasurement)
				{
					return new MilePerHour((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MilePerHours
			public static MilePerHour MilePerHours(this Byte input) => new MilePerHour(input);
			public static MilePerHour MilePerHours(this Int16 input) => new MilePerHour(input);
			public static MilePerHour MilePerHours(this Int32 input) => new MilePerHour(input);
			public static MilePerHour MilePerHours(this Int64 input) => new MilePerHour(input);
			public static MilePerHour MilePerHours(this Single input) => new MilePerHour(input);
			public static MilePerHour MilePerHours(this Double input) => new MilePerHour(input);
			#endregion
		}
	}
}
