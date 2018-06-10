using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Powers
		{
			public class Watt : Power, IWatt
			{
				#region CTOR
				public Watt(double value) : base(value, Conversion.Watt, Suffixes.Watt) { }
				#endregion
				#region Operators
				public static Watt operator +(Watt firstMeasurement, Watt secondMeasurement)
				{
					return new Watt((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Watt operator -(Watt firstMeasurement, Watt secondMeasurement)
				{
					return new Watt((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Watt operator *(Watt firstMeasurement, Watt secondMeasurement)
				{
					return new Watt((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Watt operator /(Watt firstMeasurement, Watt secondMeasurement)
				{
					return new Watt((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Watts
			public static Watt Watts(this Byte input) => new Watt(input);
			public static Watt Watts(this Int16 input) => new Watt(input);
			public static Watt Watts(this Int32 input) => new Watt(input);
			public static Watt Watts(this Int64 input) => new Watt(input);
			public static Watt Watts(this Single input) => new Watt(input);
			public static Watt Watts(this Double input) => new Watt(input);
			#endregion
		}
	}
}
