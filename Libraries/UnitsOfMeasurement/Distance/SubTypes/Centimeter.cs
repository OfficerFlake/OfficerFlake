using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class CentiMeter : Distance, ICentiMeter
			{
				#region CTOR
				public CentiMeter(double value) : base(value, Conversion.CentiMeter, Suffixes.CentiMeter) { }
				#endregion
				#region Operators
				public static CentiMeter operator +(CentiMeter firstMeasurement, CentiMeter secondMeasurement)
				{
					return new CentiMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CentiMeter operator -(CentiMeter firstMeasurement, CentiMeter secondMeasurement)
				{
					return new CentiMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CentiMeter operator *(CentiMeter firstMeasurement, CentiMeter secondMeasurement)
				{
					return new CentiMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CentiMeter operator /(CentiMeter firstMeasurement, CentiMeter secondMeasurement)
				{
					return new CentiMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CentiMeters
			public static CentiMeter CentiMeters(this Byte input) => new CentiMeter(input);
			public static CentiMeter CentiMeters(this Int16 input) => new CentiMeter(input);
			public static CentiMeter CentiMeters(this Int32 input) => new CentiMeter(input);
			public static CentiMeter CentiMeters(this Int64 input) => new CentiMeter(input);
			public static CentiMeter CentiMeters(this Single input) => new CentiMeter(input);
			public static CentiMeter CentiMeters(this Double input) => new CentiMeter(input);
			#endregion
		}
	}
}
