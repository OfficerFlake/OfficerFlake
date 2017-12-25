using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Stone : Mass, IStone
			{
				#region CTOR
				public Stone(double value) : base(value, Conversion.Stone, Suffixes.Stone) { }
				#endregion
				#region Operators
				public static Stone operator +(Stone firstMeasurement, Stone secondMeasurement)
				{
					return new Stone((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Stone operator -(Stone firstMeasurement, Stone secondMeasurement)
				{
					return new Stone((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Stone operator *(Stone firstMeasurement, Stone secondMeasurement)
				{
					return new Stone((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Stone operator /(Stone firstMeasurement, Stone secondMeasurement)
				{
					return new Stone((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Stones
			public static Stone Stones(this Byte input) => new Stone(input);
			public static Stone Stones(this Int16 input) => new Stone(input);
			public static Stone Stones(this Int32 input) => new Stone(input);
			public static Stone Stones(this Int64 input) => new Stone(input);
			public static Stone Stones(this Single input) => new Stone(input);
			public static Stone Stones(this Double input) => new Stone(input);
			#endregion
		}
	}
}
