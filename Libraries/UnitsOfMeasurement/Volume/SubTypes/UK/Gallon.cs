using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class UKGallon : Volume, IUKGallon
			{
				#region CTOR
				public UKGallon(double value) : base(value, Conversion.UK.Gallon, Suffixes.UK.Gallon) { }
				#endregion
				#region Operators
				public static UKGallon operator +(UKGallon firstMeasurement, UKGallon secondMeasurement)
				{
					return new UKGallon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static UKGallon operator -(UKGallon firstMeasurement, UKGallon secondMeasurement)
				{
					return new UKGallon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static UKGallon operator *(UKGallon firstMeasurement, UKGallon secondMeasurement)
				{
					return new UKGallon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static UKGallon operator /(UKGallon firstMeasurement, UKGallon secondMeasurement)
				{
					return new UKGallon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].UKGallons
			public static UKGallon UKGallons(this Byte input) => new UKGallon(input);
			public static UKGallon UKGallons(this Int16 input) => new UKGallon(input);
			public static UKGallon UKGallons(this Int32 input) => new UKGallon(input);
			public static UKGallon UKGallons(this Int64 input) => new UKGallon(input);
			public static UKGallon UKGallons(this Single input) => new UKGallon(input);
			public static UKGallon UKGallons(this Double input) => new UKGallon(input);
			#endregion
		}
	}
}
