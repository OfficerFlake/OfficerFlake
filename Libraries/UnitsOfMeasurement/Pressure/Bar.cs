using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class Bar : Pressure, IBar
			{
				#region CTOR
				public Bar(double value) : base(value, Conversion.Bar, Suffixes.Bar) { }
				#endregion
				#region Operators
				public static Bar operator +(Bar firstMeasurement, Bar secondMeasurement)
				{
					return new Bar((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Bar operator -(Bar firstMeasurement, Bar secondMeasurement)
				{
					return new Bar((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Bar operator *(Bar firstMeasurement, Bar secondMeasurement)
				{
					return new Bar((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Bar operator /(Bar firstMeasurement, Bar secondMeasurement)
				{
					return new Bar((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Bars
			public static Bar Bars(this Byte input) => new Bar(input);
			public static Bar Bars(this Int16 input) => new Bar(input);
			public static Bar Bars(this Int32 input) => new Bar(input);
			public static Bar Bars(this Int64 input) => new Bar(input);
			public static Bar Bars(this Single input) => new Bar(input);
			public static Bar Bars(this Double input) => new Bar(input);
			#endregion
		}
	}
}
