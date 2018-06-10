using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class USPint : Volume, IUSPint
			{
				#region CTOR
				public USPint(double value) : base(value, Conversion.US.Pint, Suffixes.US.Pint) { }
				#endregion
				#region Operators
				public static USPint operator +(USPint firstMeasurement, USPint secondMeasurement)
				{
					return new USPint((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USPint operator -(USPint firstMeasurement, USPint secondMeasurement)
				{
					return new USPint((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USPint operator *(USPint firstMeasurement, USPint secondMeasurement)
				{
					return new USPint((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USPint operator /(USPint firstMeasurement, USPint secondMeasurement)
				{
					return new USPint((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USPints
			public static USPint USPints(this Byte input) => new USPint(input);
			public static USPint USPints(this Int16 input) => new USPint(input);
			public static USPint USPints(this Int32 input) => new USPint(input);
			public static USPint USPints(this Int64 input) => new USPint(input);
			public static USPint USPints(this Single input) => new USPint(input);
			public static USPint USPints(this Double input) => new USPint(input);
			#endregion
		}
	}
}
