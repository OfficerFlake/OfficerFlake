using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class UKPint : Volume, IUKPint
			{
				#region CTOR
				public UKPint(double value) : base(value, Conversion.UK.Pint, Suffixes.UK.Pint) { }
				#endregion
				#region Operators
				public static UKPint operator +(UKPint firstMeasurement, UKPint secondMeasurement)
				{
					return new UKPint((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static UKPint operator -(UKPint firstMeasurement, UKPint secondMeasurement)
				{
					return new UKPint((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static UKPint operator *(UKPint firstMeasurement, UKPint secondMeasurement)
				{
					return new UKPint((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static UKPint operator /(UKPint firstMeasurement, UKPint secondMeasurement)
				{
					return new UKPint((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].UKPints
			public static UKPint UKPints(this Byte input) => new UKPint(input);
			public static UKPint UKPints(this Int16 input) => new UKPint(input);
			public static UKPint UKPints(this Int32 input) => new UKPint(input);
			public static UKPint UKPints(this Int64 input) => new UKPint(input);
			public static UKPint UKPints(this Single input) => new UKPint(input);
			public static UKPint UKPints(this Double input) => new UKPint(input);
			#endregion
		}
	}
}
