using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class USCup : Volume, ICup
			{
				#region CTOR
				public USCup(double value) : base(value, Conversion.US.Cup, Suffixes.US.Cup) { }
				#endregion
				#region Operators
				public static USCup operator +(USCup firstMeasurement, USCup secondMeasurement)
				{
					return new USCup((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USCup operator -(USCup firstMeasurement, USCup secondMeasurement)
				{
					return new USCup((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USCup operator *(USCup firstMeasurement, USCup secondMeasurement)
				{
					return new USCup((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USCup operator /(USCup firstMeasurement, USCup secondMeasurement)
				{
					return new USCup((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USCups
			public static USCup USCups(this Byte input) => new USCup(input);
			public static USCup USCups(this Int16 input) => new USCup(input);
			public static USCup USCups(this Int32 input) => new USCup(input);
			public static USCup USCups(this Int64 input) => new USCup(input);
			public static USCup USCups(this Single input) => new USCup(input);
			public static USCup USCups(this Double input) => new USCup(input);
			#endregion
		}
	}
}
