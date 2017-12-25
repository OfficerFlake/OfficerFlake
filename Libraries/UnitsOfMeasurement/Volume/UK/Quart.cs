using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class UKQuart : Volume, IUKQuart
			{
				#region CTOR
				public UKQuart(double value) : base(value, Conversion.UK.Quart, Suffixes.UK.Quart) { }
				#endregion
				#region Operators
				public static UKQuart operator +(UKQuart firstMeasurement, UKQuart secondMeasurement)
				{
					return new UKQuart((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static UKQuart operator -(UKQuart firstMeasurement, UKQuart secondMeasurement)
				{
					return new UKQuart((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static UKQuart operator *(UKQuart firstMeasurement, UKQuart secondMeasurement)
				{
					return new UKQuart((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static UKQuart operator /(UKQuart firstMeasurement, UKQuart secondMeasurement)
				{
					return new UKQuart((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].UKQuarts
			public static UKQuart UKQuarts(this Byte input) => new UKQuart(input);
			public static UKQuart UKQuarts(this Int16 input) => new UKQuart(input);
			public static UKQuart UKQuarts(this Int32 input) => new UKQuart(input);
			public static UKQuart UKQuarts(this Int64 input) => new UKQuart(input);
			public static UKQuart UKQuarts(this Single input) => new UKQuart(input);
			public static UKQuart UKQuarts(this Double input) => new UKQuart(input);
			#endregion
		}
	}
}
