using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class USTableSpoon : Volume, IUSTableSpoon
			{
				#region CTOR
				public USTableSpoon(double value) : base(value, Conversion.US.TableSpoon, Suffixes.US.TableSpoon) { }
				#endregion
				#region Operators
				public static USTableSpoon operator +(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
				{
					return new USTableSpoon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USTableSpoon operator -(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
				{
					return new USTableSpoon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USTableSpoon operator *(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
				{
					return new USTableSpoon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USTableSpoon operator /(USTableSpoon firstMeasurement, USTableSpoon secondMeasurement)
				{
					return new USTableSpoon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USTableSpoons
			public static USTableSpoon USTableSpoons(this Byte input) => new USTableSpoon(input);
			public static USTableSpoon USTableSpoons(this Int16 input) => new USTableSpoon(input);
			public static USTableSpoon USTableSpoons(this Int32 input) => new USTableSpoon(input);
			public static USTableSpoon USTableSpoons(this Int64 input) => new USTableSpoon(input);
			public static USTableSpoon USTableSpoons(this Single input) => new USTableSpoon(input);
			public static USTableSpoon USTableSpoons(this Double input) => new USTableSpoon(input);
			#endregion
		}
	}
}
