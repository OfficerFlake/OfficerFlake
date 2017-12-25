using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class USQuart : Volume, IUSQuart
			{
				#region CTOR
				public USQuart(double value) : base(value, Conversion.US.Quart, Suffixes.US.Quart) { }
				#endregion
				#region Operators
				public static USQuart operator +(USQuart firstMeasurement, USQuart secondMeasurement)
				{
					return new USQuart((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USQuart operator -(USQuart firstMeasurement, USQuart secondMeasurement)
				{
					return new USQuart((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USQuart operator *(USQuart firstMeasurement, USQuart secondMeasurement)
				{
					return new USQuart((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USQuart operator /(USQuart firstMeasurement, USQuart secondMeasurement)
				{
					return new USQuart((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USQuarts
			public static USQuart USQuarts(this Byte input) => new USQuart(input);
			public static USQuart USQuarts(this Int16 input) => new USQuart(input);
			public static USQuart USQuarts(this Int32 input) => new USQuart(input);
			public static USQuart USQuarts(this Int64 input) => new USQuart(input);
			public static USQuart USQuarts(this Single input) => new USQuart(input);
			public static USQuart USQuarts(this Double input) => new USQuart(input);
			#endregion
		}
	}
}
