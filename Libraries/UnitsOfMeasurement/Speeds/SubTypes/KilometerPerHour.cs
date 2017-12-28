using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class KilometerPerHour : Speed, IKilometerPerHour
			{
				#region CTOR
				public KilometerPerHour(double value) : base(value, Conversion.KilometerPerHour, Suffixes.KilometerPerHour) { }
				#endregion
				#region Operators
				public static KilometerPerHour operator +(KilometerPerHour firstMeasurement, KilometerPerHour secondMeasurement)
				{
					return new KilometerPerHour((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KilometerPerHour operator -(KilometerPerHour firstMeasurement, KilometerPerHour secondMeasurement)
				{
					return new KilometerPerHour((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KilometerPerHour operator *(KilometerPerHour firstMeasurement, KilometerPerHour secondMeasurement)
				{
					return new KilometerPerHour((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KilometerPerHour operator /(KilometerPerHour firstMeasurement, KilometerPerHour secondMeasurement)
				{
					return new KilometerPerHour((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KilometerPerHours
			public static KilometerPerHour KilometerPerHours(this Byte input) => new KilometerPerHour(input);
			public static KilometerPerHour KilometerPerHours(this Int16 input) => new KilometerPerHour(input);
			public static KilometerPerHour KilometerPerHours(this Int32 input) => new KilometerPerHour(input);
			public static KilometerPerHour KilometerPerHours(this Int64 input) => new KilometerPerHour(input);
			public static KilometerPerHour KilometerPerHours(this Single input) => new KilometerPerHour(input);
			public static KilometerPerHour KilometerPerHours(this Double input) => new KilometerPerHour(input);
			#endregion
		}
	}
}
