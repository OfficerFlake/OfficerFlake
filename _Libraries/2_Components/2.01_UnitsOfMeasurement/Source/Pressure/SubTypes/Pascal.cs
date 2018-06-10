using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class Pascal : Pressure, IPascal
			{
				#region CTOR
				public Pascal(double value) : base(value, Conversion.Pascal, Suffixes.Pascal) { }
				#endregion
				#region Operators
				public static Pascal operator +(Pascal firstMeasurement, Pascal secondMeasurement)
				{
					return new Pascal((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Pascal operator -(Pascal firstMeasurement, Pascal secondMeasurement)
				{
					return new Pascal((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Pascal operator *(Pascal firstMeasurement, Pascal secondMeasurement)
				{
					return new Pascal((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Pascal operator /(Pascal firstMeasurement, Pascal secondMeasurement)
				{
					return new Pascal((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Pascals
			public static Pascal Pascals(this Byte input) => new Pascal(input);
			public static Pascal Pascals(this Int16 input) => new Pascal(input);
			public static Pascal Pascals(this Int32 input) => new Pascal(input);
			public static Pascal Pascals(this Int64 input) => new Pascal(input);
			public static Pascal Pascals(this Single input) => new Pascal(input);
			public static Pascal Pascals(this Double input) => new Pascal(input);
			#endregion
		}
	}
}
