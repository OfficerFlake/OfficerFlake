using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Mile : Distance, IMile
			{
				#region CTOR
				public Mile(double value) : base(value, Conversion.Mile, Suffixes.Mile) { }
				#endregion
				#region Operators
				public static Mile operator +(Mile firstMeasurement, Mile secondMeasurement)
				{
					return new Mile((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Mile operator -(Mile firstMeasurement, Mile secondMeasurement)
				{
					return new Mile((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Mile operator *(Mile firstMeasurement, Mile secondMeasurement)
				{
					return new Mile((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Mile operator /(Mile firstMeasurement, Mile secondMeasurement)
				{
					return new Mile((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Miles
			public static Mile Miles(this Byte input) => new Mile(input);
			public static Mile Miles(this Int16 input) => new Mile(input);
			public static Mile Miles(this Int32 input) => new Mile(input);
			public static Mile Miles(this Int64 input) => new Mile(input);
			public static Mile Miles(this Single input) => new Mile(input);
			public static Mile Miles(this Double input) => new Mile(input);
			#endregion
		}
	}
}
