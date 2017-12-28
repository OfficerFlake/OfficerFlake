using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class UKTeaSpoon : Volume, IUKTeaSpoon
			{
				#region CTOR
				public UKTeaSpoon(double value) : base(value, Conversion.UK.TeaSpoon, Suffixes.UK.TeaSpoon) { }
				#endregion
				#region Operators
				public static UKTeaSpoon operator +(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
				{
					return new UKTeaSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static UKTeaSpoon operator -(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
				{
					return new UKTeaSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static UKTeaSpoon operator *(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
				{
					return new UKTeaSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static UKTeaSpoon operator /(UKTeaSpoon firstMeasurement, UKTeaSpoon secondMeasurement)
				{
					return new UKTeaSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].UKTeaSpoons
			public static UKTeaSpoon UKTeaSpoons(this Byte input) => new UKTeaSpoon(input);
			public static UKTeaSpoon UKTeaSpoons(this Int16 input) => new UKTeaSpoon(input);
			public static UKTeaSpoon UKTeaSpoons(this Int32 input) => new UKTeaSpoon(input);
			public static UKTeaSpoon UKTeaSpoons(this Int64 input) => new UKTeaSpoon(input);
			public static UKTeaSpoon UKTeaSpoons(this Single input) => new UKTeaSpoon(input);
			public static UKTeaSpoon UKTeaSpoons(this Double input) => new UKTeaSpoon(input);
			#endregion
		}
	}
}
