using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Kilometer : Distance, IKilometer
			{
				#region CTOR
				public Kilometer(double value) : base(value, Conversion.Kilometer, Suffixes.Kilometer) { }
				#endregion
				#region Operators
				public static Kilometer operator +(Kilometer firstMeasurement, Kilometer secondMeasurement)
				{
					return new Kilometer((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Kilometer operator -(Kilometer firstMeasurement, Kilometer secondMeasurement)
				{
					return new Kilometer((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Kilometer operator *(Kilometer firstMeasurement, Kilometer secondMeasurement)
				{
					return new Kilometer((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Kilometer operator /(Kilometer firstMeasurement, Kilometer secondMeasurement)
				{
					return new Kilometer((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Kilometers
			public static Kilometer Kilometers(this Byte input) => new Kilometer(input);
			public static Kilometer Kilometers(this Int16 input) => new Kilometer(input);
			public static Kilometer Kilometers(this Int32 input) => new Kilometer(input);
			public static Kilometer Kilometers(this Int64 input) => new Kilometer(input);
			public static Kilometer Kilometers(this Single input) => new Kilometer(input);
			public static Kilometer Kilometers(this Double input) => new Kilometer(input);
			#endregion
		}
	}
}
