using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class KiloMeter : Distance, IKiloMeter
			{
				#region CTOR
				public KiloMeter(double value) : base(value, Conversion.KiloMeter, Suffixes.KiloMeter) { }
				#endregion
				#region Operators
				public static KiloMeter operator +(KiloMeter firstMeasurement, KiloMeter secondMeasurement)
				{
					return new KiloMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static KiloMeter operator -(KiloMeter firstMeasurement, KiloMeter secondMeasurement)
				{
					return new KiloMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static KiloMeter operator *(KiloMeter firstMeasurement, KiloMeter secondMeasurement)
				{
					return new KiloMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static KiloMeter operator /(KiloMeter firstMeasurement, KiloMeter secondMeasurement)
				{
					return new KiloMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].KiloMeters
			public static KiloMeter KiloMeters(this Byte input) => new KiloMeter(input);
			public static KiloMeter KiloMeters(this Int16 input) => new KiloMeter(input);
			public static KiloMeter KiloMeters(this Int32 input) => new KiloMeter(input);
			public static KiloMeter KiloMeters(this Int64 input) => new KiloMeter(input);
			public static KiloMeter KiloMeters(this Single input) => new KiloMeter(input);
			public static KiloMeter KiloMeters(this Double input) => new KiloMeter(input);
			#endregion
		}
	}
}
