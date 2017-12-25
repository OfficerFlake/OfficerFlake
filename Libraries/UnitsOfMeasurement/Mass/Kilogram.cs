using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Kilogram : Mass, IKilogram
			{
				#region CTOR
				public Kilogram(double value) : base(value, Conversion.Kilogram, Suffixes.Kilogram) { }
				#endregion
				#region Operators
				public static Kilogram operator +(Kilogram firstMeasurement, Kilogram secondMeasurement)
				{
					return new Kilogram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Kilogram operator -(Kilogram firstMeasurement, Kilogram secondMeasurement)
				{
					return new Kilogram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Kilogram operator *(Kilogram firstMeasurement, Kilogram secondMeasurement)
				{
					return new Kilogram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Kilogram operator /(Kilogram firstMeasurement, Kilogram secondMeasurement)
				{
					return new Kilogram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Kilograms
			public static Kilogram Kilograms(this Byte input) => new Kilogram(input);
			public static Kilogram Kilograms(this Int16 input) => new Kilogram(input);
			public static Kilogram Kilograms(this Int32 input) => new Kilogram(input);
			public static Kilogram Kilograms(this Int64 input) => new Kilogram(input);
			public static Kilogram Kilograms(this Single input) => new Kilogram(input);
			public static Kilogram Kilograms(this Double input) => new Kilogram(input);
			#endregion
		}
	}
}
