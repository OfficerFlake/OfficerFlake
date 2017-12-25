using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class UKTableSpoon : Volume, IUKTableSpoon
			{
				#region CTOR
				public UKTableSpoon(double value) : base(value, Conversion.UK.TableSpoon, Suffixes.UK.TableSpoon) { }
				#endregion
				#region Operators
				public static UKTableSpoon operator +(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
				{
					return new UKTableSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static UKTableSpoon operator -(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
				{
					return new UKTableSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static UKTableSpoon operator *(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
				{
					return new UKTableSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static UKTableSpoon operator /(UKTableSpoon firstMeasurement, UKTableSpoon secondMeasurement)
				{
					return new UKTableSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].UKTableSpoons
			public static UKTableSpoon UKTableSpoons(this Byte input) => new UKTableSpoon(input);
			public static UKTableSpoon UKTableSpoons(this Int16 input) => new UKTableSpoon(input);
			public static UKTableSpoon UKTableSpoons(this Int32 input) => new UKTableSpoon(input);
			public static UKTableSpoon UKTableSpoons(this Int64 input) => new UKTableSpoon(input);
			public static UKTableSpoon UKTableSpoons(this Single input) => new UKTableSpoon(input);
			public static UKTableSpoon UKTableSpoons(this Double input) => new UKTableSpoon(input);
			#endregion
		}
	}
}
