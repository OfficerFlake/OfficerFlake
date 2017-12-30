using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class KiloMeterPerHour : Speed, IKiloMeterPerHour
			{
				#region CTOR
				public KiloMeterPerHour(double value) : base(value, Conversion.KiloMeterPerHour, Suffixes.KiloMeterPerHour) { }
				#endregion
				#region Operators
				public static KiloMeterPerHour operator +(KiloMeterPerHour firstMeasurement, KiloMeterPerHour secondMeasurement)
				{
					return new KiloMeterPerHour((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KiloMeterPerHour operator -(KiloMeterPerHour firstMeasurement, KiloMeterPerHour secondMeasurement)
				{
					return new KiloMeterPerHour((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KiloMeterPerHour operator *(KiloMeterPerHour firstMeasurement, KiloMeterPerHour secondMeasurement)
				{
					return new KiloMeterPerHour((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KiloMeterPerHour operator /(KiloMeterPerHour firstMeasurement, KiloMeterPerHour secondMeasurement)
				{
					return new KiloMeterPerHour((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KiloMeterPerHours
			public static KiloMeterPerHour KiloMeterPerHours(this Byte input) => new KiloMeterPerHour(input);
			public static KiloMeterPerHour KiloMeterPerHours(this Int16 input) => new KiloMeterPerHour(input);
			public static KiloMeterPerHour KiloMeterPerHours(this Int32 input) => new KiloMeterPerHour(input);
			public static KiloMeterPerHour KiloMeterPerHours(this Int64 input) => new KiloMeterPerHour(input);
			public static KiloMeterPerHour KiloMeterPerHours(this Single input) => new KiloMeterPerHour(input);
			public static KiloMeterPerHour KiloMeterPerHours(this Double input) => new KiloMeterPerHour(input);
			#endregion
		}
	}
}
