using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Carat : Mass, ICarat
			{
				#region CTOR
				public Carat(double value) : base(value, Conversion.Carat, Suffixes.Carat) { }
				#endregion
				#region Operators
				public static Carat operator +(Carat firstMeasurement, Carat secondMeasurement)
				{
					return new Carat((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Carat operator -(Carat firstMeasurement, Carat secondMeasurement)
				{
					return new Carat((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Carat operator *(Carat firstMeasurement, Carat secondMeasurement)
				{
					return new Carat((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Carat operator /(Carat firstMeasurement, Carat secondMeasurement)
				{
					return new Carat((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Carats
			public static Carat Carats(this Byte input) => new Carat(input);
			public static Carat Carats(this Int16 input) => new Carat(input);
			public static Carat Carats(this Int32 input) => new Carat(input);
			public static Carat Carats(this Int64 input) => new Carat(input);
			public static Carat Carats(this Single input) => new Carat(input);
			public static Carat Carats(this Double input) => new Carat(input);
			#endregion
		}
	}
}
