using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Gram : Mass, IGram
			{
				#region CTOR
				public Gram(double value) : base(value, Conversion.Gram, Suffixes.Gram) { }
				#endregion
				#region Operators
				public static Gram operator +(Gram firstMeasurement, Gram secondMeasurement)
				{
					return new Gram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Gram operator -(Gram firstMeasurement, Gram secondMeasurement)
				{
					return new Gram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Gram operator *(Gram firstMeasurement, Gram secondMeasurement)
				{
					return new Gram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Gram operator /(Gram firstMeasurement, Gram secondMeasurement)
				{
					return new Gram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Grams
			public static Gram Grams(this Byte input) => new Gram(input);
			public static Gram Grams(this Int16 input) => new Gram(input);
			public static Gram Grams(this Int32 input) => new Gram(input);
			public static Gram Grams(this Int64 input) => new Gram(input);
			public static Gram Grams(this Single input) => new Gram(input);
			public static Gram Grams(this Double input) => new Gram(input);
			#endregion
		}
	}
}
