using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Millimeter : Distance, IMillimeter
			{
				#region CTOR
				public Millimeter(double value) : base(value, Conversion.Millimeter, Suffixes.Millimeter) { }
				#endregion
				#region Operators
				public static Millimeter operator +(Millimeter firstMeasurement, Millimeter secondMeasurement)
				{
					return new Millimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Millimeter operator -(Millimeter firstMeasurement, Millimeter secondMeasurement)
				{
					return new Millimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Millimeter operator *(Millimeter firstMeasurement, Millimeter secondMeasurement)
				{
					return new Millimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Millimeter operator /(Millimeter firstMeasurement, Millimeter secondMeasurement)
				{
					return new Millimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Millimeters
			public static Millimeter Millimeters(this Byte input) => new Millimeter(input);
			public static Millimeter Millimeters(this Int16 input) => new Millimeter(input);
			public static Millimeter Millimeters(this Int32 input) => new Millimeter(input);
			public static Millimeter Millimeters(this Int64 input) => new Millimeter(input);
			public static Millimeter Millimeters(this Single input) => new Millimeter(input);
			public static Millimeter Millimeters(this Double input) => new Millimeter(input);
			#endregion
		}
	}
}
