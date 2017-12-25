using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class USShortTon : Mass, IUSShortTon
			{
				#region CTOR
				public USShortTon(double value) : base(value, Conversion.USShortTon, Suffixes.USShortTon) { }
				#endregion
				#region Operators
				public static USShortTon operator +(USShortTon firstMeasurement, USShortTon secondMeasurement)
				{
					return new USShortTon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USShortTon operator -(USShortTon firstMeasurement, USShortTon secondMeasurement)
				{
					return new USShortTon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USShortTon operator *(USShortTon firstMeasurement, USShortTon secondMeasurement)
				{
					return new USShortTon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USShortTon operator /(USShortTon firstMeasurement, USShortTon secondMeasurement)
				{
					return new USShortTon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USShortTons
			public static USShortTon USShortTons(this Byte input) => new USShortTon(input);
			public static USShortTon USShortTons(this Int16 input) => new USShortTon(input);
			public static USShortTon USShortTons(this Int32 input) => new USShortTon(input);
			public static USShortTon USShortTons(this Int64 input) => new USShortTon(input);
			public static USShortTon USShortTons(this Single input) => new USShortTon(input);
			public static USShortTon USShortTons(this Double input) => new USShortTon(input);
			#endregion
		}
	}
}
