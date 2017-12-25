using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Inch : Distance, IInch
			{
				#region CTOR
				public Inch(double value) : base(value, Conversion.Inch, Suffixes.Inch) { }
				#endregion
				#region Operators
				public static Inch operator +(Inch firstMeasurement, Inch secondMeasurement)
				{
					return new Inch((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Inch operator -(Inch firstMeasurement, Inch secondMeasurement)
				{
					return new Inch((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Inch operator *(Inch firstMeasurement, Inch secondMeasurement)
				{
					return new Inch((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Inch operator /(Inch firstMeasurement, Inch secondMeasurement)
				{
					return new Inch((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Inchs
			public static Inch Inchs(this Byte input) => new Inch(input);
			public static Inch Inchs(this Int16 input) => new Inch(input);
			public static Inch Inchs(this Int32 input) => new Inch(input);
			public static Inch Inchs(this Int64 input) => new Inch(input);
			public static Inch Inchs(this Single input) => new Inch(input);
			public static Inch Inchs(this Double input) => new Inch(input);
			#endregion
		}
	}
}
