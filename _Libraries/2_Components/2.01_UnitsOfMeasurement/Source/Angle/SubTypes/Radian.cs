using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Angles
		{
			public class Radian : Angle, IRadian
			{
				#region CTOR
				public Radian(double value) : base(value, Conversion.Radian, Suffixes.Radian) { }
				#endregion
				#region Operators
				public static Radian operator +(Radian firstMeasurement, Radian secondMeasurement)
				{
					return new Radian((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Radian operator -(Radian firstMeasurement, Radian secondMeasurement)
				{
					return new Radian((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Radian operator *(Radian firstMeasurement, Radian secondMeasurement)
				{
					return new Radian((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Radian operator /(Radian firstMeasurement, Radian secondMeasurement)
				{
					return new Radian((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Radians
			public static Radian Radians(this Byte input) => new Radian(input);
			public static Radian Radians(this Int16 input) => new Radian(input);
			public static Radian Radians(this Int32 input) => new Radian(input);
			public static Radian Radians(this Int64 input) => new Radian(input);
			public static Radian Radians(this Single input) => new Radian(input);
			public static Radian Radians(this Double input) => new Radian(input);
			#endregion
		}
	}
}
