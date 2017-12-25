using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareMeter : Area, ISquareMeter
			{
				#region CTOR
				public SquareMeter(double value) : base(value, Conversion.SquareMeter, Suffixes.SquareMeter) { }
				#endregion
				#region Operators
				public static SquareMeter operator +(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
				{
					return new SquareMeter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareMeter operator -(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
				{
					return new SquareMeter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareMeter operator *(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
				{
					return new SquareMeter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareMeter operator /(SquareMeter firstMeasurement, SquareMeter secondMeasurement)
				{
					return new SquareMeter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareMeters
			public static SquareMeter SquareMeters(this Byte input) => new SquareMeter(input);
			public static SquareMeter SquareMeters(this Int16 input) => new SquareMeter(input);
			public static SquareMeter SquareMeters(this Int32 input) => new SquareMeter(input);
			public static SquareMeter SquareMeters(this Int64 input) => new SquareMeter(input);
			public static SquareMeter SquareMeters(this Single input) => new SquareMeter(input);
			public static SquareMeter SquareMeters(this Double input) => new SquareMeter(input);
			#endregion
		}
	}
}
