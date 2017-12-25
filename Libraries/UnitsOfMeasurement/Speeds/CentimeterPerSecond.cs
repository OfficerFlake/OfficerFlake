using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class CentimeterPerSecond : Speed, ICentimeterPerSecond
			{
				#region CTOR
				public CentimeterPerSecond(double value) : base(value, Conversion.CentimeterPerSecond, Suffixes.CentimeterPerSecond) { }
				#endregion
				#region Operators
				public static CentimeterPerSecond operator +(CentimeterPerSecond firstMeasurement, CentimeterPerSecond secondMeasurement)
				{
					return new CentimeterPerSecond((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CentimeterPerSecond operator -(CentimeterPerSecond firstMeasurement, CentimeterPerSecond secondMeasurement)
				{
					return new CentimeterPerSecond((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CentimeterPerSecond operator *(CentimeterPerSecond firstMeasurement, CentimeterPerSecond secondMeasurement)
				{
					return new CentimeterPerSecond((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CentimeterPerSecond operator /(CentimeterPerSecond firstMeasurement, CentimeterPerSecond secondMeasurement)
				{
					return new CentimeterPerSecond((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CentimeterPerSeconds
			public static CentimeterPerSecond CentimeterPerSeconds(this Byte input) => new CentimeterPerSecond(input);
			public static CentimeterPerSecond CentimeterPerSeconds(this Int16 input) => new CentimeterPerSecond(input);
			public static CentimeterPerSecond CentimeterPerSeconds(this Int32 input) => new CentimeterPerSecond(input);
			public static CentimeterPerSecond CentimeterPerSeconds(this Int64 input) => new CentimeterPerSecond(input);
			public static CentimeterPerSecond CentimeterPerSeconds(this Single input) => new CentimeterPerSecond(input);
			public static CentimeterPerSecond CentimeterPerSeconds(this Double input) => new CentimeterPerSecond(input);
			#endregion
		}
	}
}
