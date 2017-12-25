using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Masses
		{
			public class UKLongTon : Mass, IUKLongTon
			{
				#region CTOR
				public UKLongTon(double value) : base(value, Conversion.UKLongTon, Suffixes.UKLongTon) { }
				#endregion
				#region Operators
				public static UKLongTon operator +(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
				{
					return new UKLongTon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static UKLongTon operator -(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
				{
					return new UKLongTon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static UKLongTon operator *(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
				{
					return new UKLongTon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static UKLongTon operator /(UKLongTon firstMeasurement, UKLongTon secondMeasurement)
				{
					return new UKLongTon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].UKLongTons
			public static UKLongTon UKLongTons(this Byte input) => new UKLongTon(input);
			public static UKLongTon UKLongTons(this Int16 input) => new UKLongTon(input);
			public static UKLongTon UKLongTons(this Int32 input) => new UKLongTon(input);
			public static UKLongTon UKLongTons(this Int64 input) => new UKLongTon(input);
			public static UKLongTon UKLongTons(this Single input) => new UKLongTon(input);
			public static UKLongTon UKLongTons(this Double input) => new UKLongTon(input);
			#endregion
		}
	}
}
