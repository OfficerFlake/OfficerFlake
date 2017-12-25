using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Yard : Distance, IYard
			{
				#region CTOR
				public Yard(double value) : base(value, Conversion.Yard, Suffixes.Yard) { }
				#endregion
				#region Operators
				public static Yard operator +(Yard firstMeasurement, Yard secondMeasurement)
				{
					return new Yard((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Yard operator -(Yard firstMeasurement, Yard secondMeasurement)
				{
					return new Yard((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Yard operator *(Yard firstMeasurement, Yard secondMeasurement)
				{
					return new Yard((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Yard operator /(Yard firstMeasurement, Yard secondMeasurement)
				{
					return new Yard((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Yards
			public static Yard Yards(this Byte input) => new Yard(input);
			public static Yard Yards(this Int16 input) => new Yard(input);
			public static Yard Yards(this Int32 input) => new Yard(input);
			public static Yard Yards(this Int64 input) => new Yard(input);
			public static Yard Yards(this Single input) => new Yard(input);
			public static Yard Yards(this Double input) => new Yard(input);
			#endregion
		}
	}
}
