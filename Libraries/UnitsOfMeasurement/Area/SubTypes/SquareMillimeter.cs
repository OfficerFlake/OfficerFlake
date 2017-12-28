using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareMillimeter : Area, ISquareMillimeter
			{
				#region CTOR
				public SquareMillimeter(double value) : base(value, Conversion.SquareMillimeter, Suffixes.SquareMillimeter) { }
				#endregion
				#region Operators
				public static SquareMillimeter operator +(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
				{
					return new SquareMillimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareMillimeter operator -(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
				{
					return new SquareMillimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareMillimeter operator *(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
				{
					return new SquareMillimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareMillimeter operator /(SquareMillimeter firstMeasurement, SquareMillimeter secondMeasurement)
				{
					return new SquareMillimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareMillimeters
			public static SquareMillimeter SquareMillimeters(this Byte input) => new SquareMillimeter(input);
			public static SquareMillimeter SquareMillimeters(this Int16 input) => new SquareMillimeter(input);
			public static SquareMillimeter SquareMillimeters(this Int32 input) => new SquareMillimeter(input);
			public static SquareMillimeter SquareMillimeters(this Int64 input) => new SquareMillimeter(input);
			public static SquareMillimeter SquareMillimeters(this Single input) => new SquareMillimeter(input);
			public static SquareMillimeter SquareMillimeters(this Double input) => new SquareMillimeter(input);
			#endregion
		}
	}
}
