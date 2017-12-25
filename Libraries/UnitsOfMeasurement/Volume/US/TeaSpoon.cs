using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class USTeaSpoon : Volume, IUSTeaSpoon
			{
				#region CTOR
				public USTeaSpoon(double value) : base(value, Conversion.US.TeaSpoon, Suffixes.US.TeaSpoon) { }
				#endregion
				#region Operators
				public static USTeaSpoon operator +(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
				{
					return new USTeaSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USTeaSpoon operator -(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
				{
					return new USTeaSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USTeaSpoon operator *(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
				{
					return new USTeaSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USTeaSpoon operator /(USTeaSpoon firstMeasurement, USTeaSpoon secondMeasurement)
				{
					return new USTeaSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USTeaSpoons
			public static USTeaSpoon USTeaSpoons(this Byte input) => new USTeaSpoon(input);
			public static USTeaSpoon USTeaSpoons(this Int16 input) => new USTeaSpoon(input);
			public static USTeaSpoon USTeaSpoons(this Int32 input) => new USTeaSpoon(input);
			public static USTeaSpoon USTeaSpoons(this Int64 input) => new USTeaSpoon(input);
			public static USTeaSpoon USTeaSpoons(this Single input) => new USTeaSpoon(input);
			public static USTeaSpoon USTeaSpoons(this Double input) => new USTeaSpoon(input);
			#endregion
		}
	}
}
