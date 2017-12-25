using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Speeds
		{
			public class Knot : Speed, IKnot
			{
				#region CTOR
				public Knot(double value) : base(value, Conversion.Knot, Suffixes.Knot) { }
				#endregion
				#region Operators
				public static Knot operator +(Knot firstMeasurement, Knot secondMeasurement)
				{
					return new Knot((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Knot operator -(Knot firstMeasurement, Knot secondMeasurement)
				{
					return new Knot((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Knot operator *(Knot firstMeasurement, Knot secondMeasurement)
				{
					return new Knot((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Knot operator /(Knot firstMeasurement, Knot secondMeasurement)
				{
					return new Knot((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Knots
			public static Knot Knots(this Byte input) => new Knot(input);
			public static Knot Knots(this Int16 input) => new Knot(input);
			public static Knot Knots(this Int32 input) => new Knot(input);
			public static Knot Knots(this Int64 input) => new Knot(input);
			public static Knot Knots(this Single input) => new Knot(input);
			public static Knot Knots(this Double input) => new Knot(input);
			#endregion
		}
	}
}
