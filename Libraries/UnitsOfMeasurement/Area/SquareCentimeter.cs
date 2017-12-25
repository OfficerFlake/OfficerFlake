using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareCentimeter : Area, ISquareCentimeter
			{
				#region CTOR
				public SquareCentimeter(double value) : base(value, Conversion.SquareCentimeter, Suffixes.SquareCentimeter) { }
				#endregion
				#region Operators
				public static SquareCentimeter operator +(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
				{
					return new SquareCentimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareCentimeter operator -(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
				{
					return new SquareCentimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareCentimeter operator *(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
				{
					return new SquareCentimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareCentimeter operator /(SquareCentimeter firstMeasurement, SquareCentimeter secondMeasurement)
				{
					return new SquareCentimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareCentimeters
			public static SquareCentimeter SquareCentimeters(this Byte input) => new SquareCentimeter(input);
			public static SquareCentimeter SquareCentimeters(this Int16 input) => new SquareCentimeter(input);
			public static SquareCentimeter SquareCentimeters(this Int32 input) => new SquareCentimeter(input);
			public static SquareCentimeter SquareCentimeters(this Int64 input) => new SquareCentimeter(input);
			public static SquareCentimeter SquareCentimeters(this Single input) => new SquareCentimeter(input);
			public static SquareCentimeter SquareCentimeters(this Double input) => new SquareCentimeter(input);
			#endregion
		}
	}
}
