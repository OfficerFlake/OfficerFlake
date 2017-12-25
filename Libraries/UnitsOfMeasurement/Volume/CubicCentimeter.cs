using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class CubicCentimeter : Volume, ICubicCentimeter
			{
				#region CTOR
				public CubicCentimeter(double value) : base(value, Conversion.CubicCentimeter, Suffixes.CubicCentimeter) { }
				#endregion
				#region Operators
				public static CubicCentimeter operator +(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
				{
					return new CubicCentimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static CubicCentimeter operator -(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
				{
					return new CubicCentimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static CubicCentimeter operator *(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
				{
					return new CubicCentimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static CubicCentimeter operator /(CubicCentimeter firstMeasurement, CubicCentimeter secondMeasurement)
				{
					return new CubicCentimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].CubicCentimeters
			public static CubicCentimeter CubicCentimeters(this Byte input) => new CubicCentimeter(input);
			public static CubicCentimeter CubicCentimeters(this Int16 input) => new CubicCentimeter(input);
			public static CubicCentimeter CubicCentimeters(this Int32 input) => new CubicCentimeter(input);
			public static CubicCentimeter CubicCentimeters(this Int64 input) => new CubicCentimeter(input);
			public static CubicCentimeter CubicCentimeters(this Single input) => new CubicCentimeter(input);
			public static CubicCentimeter CubicCentimeters(this Double input) => new CubicCentimeter(input);
			#endregion
		}
	}
}
