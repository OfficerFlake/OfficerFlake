using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class NanoMeter : Distance, INanoMeter
			{
				#region CTOR
				public NanoMeter(double value) : base(value, Conversion.NanoMeter, Suffixes.NanoMeter) { }
				#endregion
				#region Operators
				public static NanoMeter operator +(NanoMeter firstMeasurement, NanoMeter secondMeasurement)
				{
					return new NanoMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static NanoMeter operator -(NanoMeter firstMeasurement, NanoMeter secondMeasurement)
				{
					return new NanoMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static NanoMeter operator *(NanoMeter firstMeasurement, NanoMeter secondMeasurement)
				{
					return new NanoMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static NanoMeter operator /(NanoMeter firstMeasurement, NanoMeter secondMeasurement)
				{
					return new NanoMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].NanoMeters
			public static NanoMeter NanoMeters(this Byte input) => new NanoMeter(input);
			public static NanoMeter NanoMeters(this Int16 input) => new NanoMeter(input);
			public static NanoMeter NanoMeters(this Int32 input) => new NanoMeter(input);
			public static NanoMeter NanoMeters(this Int64 input) => new NanoMeter(input);
			public static NanoMeter NanoMeters(this Single input) => new NanoMeter(input);
			public static NanoMeter NanoMeters(this Double input) => new NanoMeter(input);
			#endregion
		}
	}
}
