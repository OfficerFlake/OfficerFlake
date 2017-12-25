using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class Miligram : Mass, IMiligram
			{
				#region CTOR
				public Miligram(double value) : base(value, Conversion.Miligram, Suffixes.Miligram) { }
				#endregion
				#region Operators
				public static Miligram operator +(Miligram firstMeasurement, Miligram secondMeasurement)
				{
					return new Miligram((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Miligram operator -(Miligram firstMeasurement, Miligram secondMeasurement)
				{
					return new Miligram((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Miligram operator *(Miligram firstMeasurement, Miligram secondMeasurement)
				{
					return new Miligram((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Miligram operator /(Miligram firstMeasurement, Miligram secondMeasurement)
				{
					return new Miligram((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Miligrams
			public static Miligram Miligrams(this Byte input) => new Miligram(input);
			public static Miligram Miligrams(this Int16 input) => new Miligram(input);
			public static Miligram Miligrams(this Int32 input) => new Miligram(input);
			public static Miligram Miligrams(this Int64 input) => new Miligram(input);
			public static Miligram Miligrams(this Single input) => new Miligram(input);
			public static Miligram Miligrams(this Double input) => new Miligram(input);
			#endregion
		}
	}
}
