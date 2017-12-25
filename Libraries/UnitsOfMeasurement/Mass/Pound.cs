using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Pound : Mass, IPound
			{
				#region CTOR
				public Pound(double value) : base(value, Conversion.Pound, Suffixes.Pound) { }
				#endregion
				#region Operators
				public static Pound operator +(Pound firstMeasurement, Pound secondMeasurement)
				{
					return new Pound((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Pound operator -(Pound firstMeasurement, Pound secondMeasurement)
				{
					return new Pound((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Pound operator *(Pound firstMeasurement, Pound secondMeasurement)
				{
					return new Pound((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Pound operator /(Pound firstMeasurement, Pound secondMeasurement)
				{
					return new Pound((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Pounds
			public static Pound Pounds(this Byte input) => new Pound(input);
			public static Pound Pounds(this Int16 input) => new Pound(input);
			public static Pound Pounds(this Int32 input) => new Pound(input);
			public static Pound Pounds(this Int64 input) => new Pound(input);
			public static Pound Pounds(this Single input) => new Pound(input);
			public static Pound Pounds(this Double input) => new Pound(input);
			#endregion
		}
	}
}
