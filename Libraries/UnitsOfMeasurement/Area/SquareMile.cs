using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class SquareMile : Area, ISquareMile
			{
				#region CTOR
				public SquareMile(double value) : base(value, Conversion.SquareMile, Suffixes.SquareMile) { }
				#endregion
				#region Operators
				public static SquareMile operator +(SquareMile firstMeasurement, SquareMile secondMeasurement)
				{
					return new SquareMile((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static SquareMile operator -(SquareMile firstMeasurement, SquareMile secondMeasurement)
				{
					return new SquareMile((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static SquareMile operator *(SquareMile firstMeasurement, SquareMile secondMeasurement)
				{
					return new SquareMile((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static SquareMile operator /(SquareMile firstMeasurement, SquareMile secondMeasurement)
				{
					return new SquareMile((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].SquareMiles
			public static SquareMile SquareMiles(this Byte input) => new SquareMile(input);
			public static SquareMile SquareMiles(this Int16 input) => new SquareMile(input);
			public static SquareMile SquareMiles(this Int32 input) => new SquareMile(input);
			public static SquareMile SquareMiles(this Int64 input) => new SquareMile(input);
			public static SquareMile SquareMiles(this Single input) => new SquareMile(input);
			public static SquareMile SquareMiles(this Double input) => new SquareMile(input);
			#endregion
		}
	}
}
