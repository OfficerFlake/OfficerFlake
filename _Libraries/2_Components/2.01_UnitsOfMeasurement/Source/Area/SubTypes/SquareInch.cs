using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareInch : Area, ISquareInch
			{
				#region CTOR
				public SquareInch(double value) : base(value, Conversion.SquareInch, Suffixes.SquareInch) { }
				#endregion
				#region Operators
				public static SquareInch operator +(SquareInch firstMeasurement, SquareInch secondMeasurement)
				{
					return new SquareInch((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareInch operator -(SquareInch firstMeasurement, SquareInch secondMeasurement)
				{
					return new SquareInch((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareInch operator *(SquareInch firstMeasurement, SquareInch secondMeasurement)
				{
					return new SquareInch((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareInch operator /(SquareInch firstMeasurement, SquareInch secondMeasurement)
				{
					return new SquareInch((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareInchs
			public static SquareInch SquareInchs(this Byte input) => new SquareInch(input);
			public static SquareInch SquareInchs(this Int16 input) => new SquareInch(input);
			public static SquareInch SquareInchs(this Int32 input) => new SquareInch(input);
			public static SquareInch SquareInchs(this Int64 input) => new SquareInch(input);
			public static SquareInch SquareInchs(this Single input) => new SquareInch(input);
			public static SquareInch SquareInchs(this Double input) => new SquareInch(input);
			#endregion
		}
	}
}
