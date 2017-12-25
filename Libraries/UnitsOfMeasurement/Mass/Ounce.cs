using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Ounce : Mass, IOunce
			{
				#region CTOR
				public Ounce(double value) : base(value, Conversion.Ounce, Suffixes.Ounce) { }
				#endregion
				#region Operators
				public static Ounce operator +(Ounce firstMeasurement, Ounce secondMeasurement)
				{
					return new Ounce((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Ounce operator -(Ounce firstMeasurement, Ounce secondMeasurement)
				{
					return new Ounce((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Ounce operator *(Ounce firstMeasurement, Ounce secondMeasurement)
				{
					return new Ounce((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Ounce operator /(Ounce firstMeasurement, Ounce secondMeasurement)
				{
					return new Ounce((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Ounces
			public static Ounce Ounces(this Byte input) => new Ounce(input);
			public static Ounce Ounces(this Int16 input) => new Ounce(input);
			public static Ounce Ounces(this Int32 input) => new Ounce(input);
			public static Ounce Ounces(this Int64 input) => new Ounce(input);
			public static Ounce Ounces(this Single input) => new Ounce(input);
			public static Ounce Ounces(this Double input) => new Ounce(input);
			#endregion
		}
	}
}
