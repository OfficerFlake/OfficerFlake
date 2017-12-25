using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Decagram : Mass, IDecagram
			{
				#region CTOR
				public Decagram(double value) : base(value, Conversion.Decagram, Suffixes.Decagram) { }
				#endregion
				#region Operators
				public static Decagram operator +(Decagram firstMeasurement, Decagram secondMeasurement)
				{
					return new Decagram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Decagram operator -(Decagram firstMeasurement, Decagram secondMeasurement)
				{
					return new Decagram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Decagram operator *(Decagram firstMeasurement, Decagram secondMeasurement)
				{
					return new Decagram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Decagram operator /(Decagram firstMeasurement, Decagram secondMeasurement)
				{
					return new Decagram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Decagrams
			public static Decagram Decagrams(this Byte input) => new Decagram(input);
			public static Decagram Decagrams(this Int16 input) => new Decagram(input);
			public static Decagram Decagrams(this Int32 input) => new Decagram(input);
			public static Decagram Decagrams(this Int64 input) => new Decagram(input);
			public static Decagram Decagrams(this Single input) => new Decagram(input);
			public static Decagram Decagrams(this Double input) => new Decagram(input);
			#endregion
		}
	}
}
