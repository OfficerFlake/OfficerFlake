using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class CentiMeterPerSecond : Speed, ICentiMeterPerSecond
			{
				#region CTOR
				public CentiMeterPerSecond(double value) : base(value, Conversion.CentiMeterPerSecond, Suffixes.CentiMeterPerSecond) { }
				#endregion
				#region Operators
				public static CentiMeterPerSecond operator +(CentiMeterPerSecond firstMeasurement, CentiMeterPerSecond secondMeasurement)
				{
					return new CentiMeterPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CentiMeterPerSecond operator -(CentiMeterPerSecond firstMeasurement, CentiMeterPerSecond secondMeasurement)
				{
					return new CentiMeterPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CentiMeterPerSecond operator *(CentiMeterPerSecond firstMeasurement, CentiMeterPerSecond secondMeasurement)
				{
					return new CentiMeterPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CentiMeterPerSecond operator /(CentiMeterPerSecond firstMeasurement, CentiMeterPerSecond secondMeasurement)
				{
					return new CentiMeterPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CentiMeterPerSeconds
			public static CentiMeterPerSecond CentiMeterPerSeconds(this Byte input) => new CentiMeterPerSecond(input);
			public static CentiMeterPerSecond CentiMeterPerSeconds(this Int16 input) => new CentiMeterPerSecond(input);
			public static CentiMeterPerSecond CentiMeterPerSeconds(this Int32 input) => new CentiMeterPerSecond(input);
			public static CentiMeterPerSecond CentiMeterPerSeconds(this Int64 input) => new CentiMeterPerSecond(input);
			public static CentiMeterPerSecond CentiMeterPerSeconds(this Single input) => new CentiMeterPerSecond(input);
			public static CentiMeterPerSecond CentiMeterPerSeconds(this Double input) => new CentiMeterPerSecond(input);
			#endregion
		}
	}
}
