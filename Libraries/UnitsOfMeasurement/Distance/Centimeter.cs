using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Centimeter : Distance, ICentimeter
			{
				#region CTOR
				public Centimeter(double value) : base(value, Conversion.Centimeter, Suffixes.Centimeter) { }
				#endregion
				#region Operators
				public static Centimeter operator +(Centimeter firstMeasurement, Centimeter secondMeasurement)
				{
					return new Centimeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Centimeter operator -(Centimeter firstMeasurement, Centimeter secondMeasurement)
				{
					return new Centimeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Centimeter operator *(Centimeter firstMeasurement, Centimeter secondMeasurement)
				{
					return new Centimeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Centimeter operator /(Centimeter firstMeasurement, Centimeter secondMeasurement)
				{
					return new Centimeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Centimeters
			public static Centimeter Centimeters(this Byte input) => new Centimeter(input);
			public static Centimeter Centimeters(this Int16 input) => new Centimeter(input);
			public static Centimeter Centimeters(this Int32 input) => new Centimeter(input);
			public static Centimeter Centimeters(this Int64 input) => new Centimeter(input);
			public static Centimeter Centimeters(this Single input) => new Centimeter(input);
			public static Centimeter Centimeters(this Double input) => new Centimeter(input);
			#endregion
		}
	}
}
