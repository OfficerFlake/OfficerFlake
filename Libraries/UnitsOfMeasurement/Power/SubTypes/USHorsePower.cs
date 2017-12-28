using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Powers
		{
			public class USHorsePower : Power, IUSHorsePower
			{
				#region CTOR
				public USHorsePower(double value) : base(value, Conversion.USHorsePower, Suffixes.USHorsePower) { }
				#endregion
				#region Operators
				public static USHorsePower operator +(USHorsePower firstMeasurement, USHorsePower secondMeasurement)
				{
					return new USHorsePower((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USHorsePower operator -(USHorsePower firstMeasurement, USHorsePower secondMeasurement)
				{
					return new USHorsePower((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USHorsePower operator *(USHorsePower firstMeasurement, USHorsePower secondMeasurement)
				{
					return new USHorsePower((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USHorsePower operator /(USHorsePower firstMeasurement, USHorsePower secondMeasurement)
				{
					return new USHorsePower((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USHorsePowers
			public static USHorsePower USHorsePowers(this Byte input) => new USHorsePower(input);
			public static USHorsePower USHorsePowers(this Int16 input) => new USHorsePower(input);
			public static USHorsePower USHorsePowers(this Int32 input) => new USHorsePower(input);
			public static USHorsePower USHorsePowers(this Int64 input) => new USHorsePower(input);
			public static USHorsePower USHorsePowers(this Single input) => new USHorsePower(input);
			public static USHorsePower USHorsePowers(this Double input) => new USHorsePower(input);
			#endregion
		}
	}
}
