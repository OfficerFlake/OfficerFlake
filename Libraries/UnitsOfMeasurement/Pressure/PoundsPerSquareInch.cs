using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class PoundPerSquareInch : Pressure, IPoundPerSquareInch
			{
				#region CTOR
				public PoundPerSquareInch(double value) : base(value, Conversion.PoundPerSquareInch, Suffixes.PoundPerSquareInch) { }
				#endregion
				#region Operators
				public static PoundPerSquareInch operator +(PoundPerSquareInch firstMeasurement, PoundPerSquareInch secondMeasurement)
				{
					return new PoundPerSquareInch((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static PoundPerSquareInch operator -(PoundPerSquareInch firstMeasurement, PoundPerSquareInch secondMeasurement)
				{
					return new PoundPerSquareInch((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static PoundPerSquareInch operator *(PoundPerSquareInch firstMeasurement, PoundPerSquareInch secondMeasurement)
				{
					return new PoundPerSquareInch((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static PoundPerSquareInch operator /(PoundPerSquareInch firstMeasurement, PoundPerSquareInch secondMeasurement)
				{
					return new PoundPerSquareInch((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].PoundPerSquareInchs
			public static PoundPerSquareInch PoundPerSquareInchs(this Byte input) => new PoundPerSquareInch(input);
			public static PoundPerSquareInch PoundPerSquareInchs(this Int16 input) => new PoundPerSquareInch(input);
			public static PoundPerSquareInch PoundPerSquareInchs(this Int32 input) => new PoundPerSquareInch(input);
			public static PoundPerSquareInch PoundPerSquareInchs(this Int64 input) => new PoundPerSquareInch(input);
			public static PoundPerSquareInch PoundPerSquareInchs(this Single input) => new PoundPerSquareInch(input);
			public static PoundPerSquareInch PoundPerSquareInchs(this Double input) => new PoundPerSquareInch(input);
			#endregion
		}
	}
}
