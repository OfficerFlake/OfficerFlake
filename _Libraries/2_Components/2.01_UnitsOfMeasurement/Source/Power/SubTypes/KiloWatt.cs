using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Powers
		{
			public class KiloWatt : Power, IKiloWatt
			{
				#region CTOR
				public KiloWatt(double value) : base(value, Conversion.KiloWatt, Suffixes.KiloWatt) { }
				#endregion
				#region Operators
				public static KiloWatt operator +(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
				{
					return new KiloWatt((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KiloWatt operator -(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
				{
					return new KiloWatt((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KiloWatt operator *(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
				{
					return new KiloWatt((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KiloWatt operator /(KiloWatt firstMeasurement, KiloWatt secondMeasurement)
				{
					return new KiloWatt((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KiloWatts
			public static KiloWatt KiloWatts(this Byte input) => new KiloWatt(input);
			public static KiloWatt KiloWatts(this Int16 input) => new KiloWatt(input);
			public static KiloWatt KiloWatts(this Int32 input) => new KiloWatt(input);
			public static KiloWatt KiloWatts(this Int64 input) => new KiloWatt(input);
			public static KiloWatt KiloWatts(this Single input) => new KiloWatt(input);
			public static KiloWatt KiloWatts(this Double input) => new KiloWatt(input);
			#endregion
		}
	}
}
