using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Centigram : Mass, ICentigram
			{
				#region CTOR
				public Centigram(double value) : base(value, Conversion.Centigram, Suffixes.Centigram) { }
				#endregion
				#region Operators
				public static Centigram operator +(Centigram firstMeasurement, Centigram secondMeasurement)
				{
					return new Centigram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Centigram operator -(Centigram firstMeasurement, Centigram secondMeasurement)
				{
					return new Centigram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Centigram operator *(Centigram firstMeasurement, Centigram secondMeasurement)
				{
					return new Centigram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Centigram operator /(Centigram firstMeasurement, Centigram secondMeasurement)
				{
					return new Centigram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Centigrams
			public static Centigram Centigrams(this Byte input) => new Centigram(input);
			public static Centigram Centigrams(this Int16 input) => new Centigram(input);
			public static Centigram Centigrams(this Int32 input) => new Centigram(input);
			public static Centigram Centigrams(this Int64 input) => new Centigram(input);
			public static Centigram Centigrams(this Single input) => new Centigram(input);
			public static Centigram Centigrams(this Double input) => new Centigram(input);
			#endregion
		}
	}
}
