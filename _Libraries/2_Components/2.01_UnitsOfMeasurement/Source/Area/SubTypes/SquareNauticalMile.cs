using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareNauticalMile : Area, ISquareNauticalMile
			{
				#region CTOR
				public SquareNauticalMile(double value) : base(value, Conversion.SquareNauticalMile, Suffixes.SquareNauticalMile) { }
				#endregion
				#region Operators
				public static SquareNauticalMile operator +(SquareNauticalMile firstMeasurement, SquareNauticalMile secondMeasurement)
				{
					return new SquareNauticalMile((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareNauticalMile operator -(SquareNauticalMile firstMeasurement, SquareNauticalMile secondMeasurement)
				{
					return new SquareNauticalMile((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareNauticalMile operator *(SquareNauticalMile firstMeasurement, SquareNauticalMile secondMeasurement)
				{
					return new SquareNauticalMile((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareNauticalMile operator /(SquareNauticalMile firstMeasurement, SquareNauticalMile secondMeasurement)
				{
					return new SquareNauticalMile((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareNauticalMiles
			public static SquareNauticalMile SquareNauticalMiles(this Byte input) => new SquareNauticalMile(input);
			public static SquareNauticalMile SquareNauticalMiles(this Int16 input) => new SquareNauticalMile(input);
			public static SquareNauticalMile SquareNauticalMiles(this Int32 input) => new SquareNauticalMile(input);
			public static SquareNauticalMile SquareNauticalMiles(this Int64 input) => new SquareNauticalMile(input);
			public static SquareNauticalMile SquareNauticalMiles(this Single input) => new SquareNauticalMile(input);
			public static SquareNauticalMile SquareNauticalMiles(this Double input) => new SquareNauticalMile(input);
			#endregion
		}
	}
}
