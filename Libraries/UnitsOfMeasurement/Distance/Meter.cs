using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Meter : Distance, IMeter
			{
				#region CTOR
				public Meter(double value) : base(value, Conversion.Meter, Suffixes.Meter) { }
				#endregion
				#region Operators
				public static Meter operator +(Meter firstMeasurement, Meter secondMeasurement)
				{
					return new Meter((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Meter operator -(Meter firstMeasurement, Meter secondMeasurement)
				{
					return new Meter((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Meter operator *(Meter firstMeasurement, Meter secondMeasurement)
				{
					return new Meter((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Meter operator /(Meter firstMeasurement, Meter secondMeasurement)
				{
					return new Meter((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Meters
			public static Meter Meters(this Byte input) => new Meter(input);
			public static Meter Meters(this Int16 input) => new Meter(input);
			public static Meter Meters(this Int32 input) => new Meter(input);
			public static Meter Meters(this Int64 input) => new Meter(input);
			public static Meter Meters(this Single input) => new Meter(input);
			public static Meter Meters(this Double input) => new Meter(input);
			#endregion
		}
	}
}
