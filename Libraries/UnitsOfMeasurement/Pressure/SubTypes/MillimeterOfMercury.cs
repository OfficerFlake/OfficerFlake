using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class MillimeterOfMercury : Pressure, IMillimeterOfMercury
			{
				#region CTOR
				public MillimeterOfMercury(double value) : base(value, Conversion.MillimeterOfMercury, Suffixes.MillimeterOfMercury) { }
				#endregion
				#region Operators
				public static MillimeterOfMercury operator +(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
				{
					return new MillimeterOfMercury((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static MillimeterOfMercury operator -(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
				{
					return new MillimeterOfMercury((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static MillimeterOfMercury operator *(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
				{
					return new MillimeterOfMercury((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static MillimeterOfMercury operator /(MillimeterOfMercury firstMeasurement, MillimeterOfMercury secondMeasurement)
				{
					return new MillimeterOfMercury((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].MillimeterOfMercurys
			public static MillimeterOfMercury MillimeterOfMercurys(this Byte input) => new MillimeterOfMercury(input);
			public static MillimeterOfMercury MillimeterOfMercurys(this Int16 input) => new MillimeterOfMercury(input);
			public static MillimeterOfMercury MillimeterOfMercurys(this Int32 input) => new MillimeterOfMercury(input);
			public static MillimeterOfMercury MillimeterOfMercurys(this Int64 input) => new MillimeterOfMercury(input);
			public static MillimeterOfMercury MillimeterOfMercurys(this Single input) => new MillimeterOfMercury(input);
			public static MillimeterOfMercury MillimeterOfMercurys(this Double input) => new MillimeterOfMercury(input);
			#endregion
		}
	}
}
