using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareYard : Area, ISquareYard
			{
				#region CTOR
				public SquareYard(double value) : base(value, Conversion.SquareYard, Suffixes.SquareYard) { }
				#endregion
				#region Operators
				public static SquareYard operator +(SquareYard firstMeasurement, SquareYard secondMeasurement)
				{
					return new SquareYard((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareYard operator -(SquareYard firstMeasurement, SquareYard secondMeasurement)
				{
					return new SquareYard((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareYard operator *(SquareYard firstMeasurement, SquareYard secondMeasurement)
				{
					return new SquareYard((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareYard operator /(SquareYard firstMeasurement, SquareYard secondMeasurement)
				{
					return new SquareYard((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareYards
			public static SquareYard SquareYards(this Byte input) => new SquareYard(input);
			public static SquareYard SquareYards(this Int16 input) => new SquareYard(input);
			public static SquareYard SquareYards(this Int32 input) => new SquareYard(input);
			public static SquareYard SquareYards(this Int64 input) => new SquareYard(input);
			public static SquareYard SquareYards(this Single input) => new SquareYard(input);
			public static SquareYard SquareYards(this Double input) => new SquareYard(input);
			#endregion
		}
	}
}
