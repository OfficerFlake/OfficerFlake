using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareFoot : Area, ISquareFoot
			{
				#region CTOR
				public SquareFoot(double value) : base(value, Conversion.SquareFoot, Suffixes.SquareFoot) { }
				#endregion
				#region Operators
				public static SquareFoot operator +(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
				{
					return new SquareFoot((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareFoot operator -(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
				{
					return new SquareFoot((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareFoot operator *(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
				{
					return new SquareFoot((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareFoot operator /(SquareFoot firstMeasurement, SquareFoot secondMeasurement)
				{
					return new SquareFoot((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareFoots
			public static SquareFoot SquareFoots(this Byte input) => new SquareFoot(input);
			public static SquareFoot SquareFoots(this Int16 input) => new SquareFoot(input);
			public static SquareFoot SquareFoots(this Int32 input) => new SquareFoot(input);
			public static SquareFoot SquareFoots(this Int64 input) => new SquareFoot(input);
			public static SquareFoot SquareFoots(this Single input) => new SquareFoot(input);
			public static SquareFoot SquareFoots(this Double input) => new SquareFoot(input);
			#endregion
		}
	}
}
