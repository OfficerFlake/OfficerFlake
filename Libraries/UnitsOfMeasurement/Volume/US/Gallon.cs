using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Volumes
		{
			public class USGallon : Volume, IUSGallon
			{
				#region CTOR
				public USGallon(double value) : base(value, Conversion.US.Gallon, Suffixes.US.Gallon) { }
				#endregion
				#region Operators
				public static USGallon operator +(USGallon firstMeasurement, USGallon secondMeasurement)
				{
					return new USGallon((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static USGallon operator -(USGallon firstMeasurement, USGallon secondMeasurement)
				{
					return new USGallon((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static USGallon operator *(USGallon firstMeasurement, USGallon secondMeasurement)
				{
					return new USGallon((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static USGallon operator /(USGallon firstMeasurement, USGallon secondMeasurement)
				{
					return new USGallon((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].USGallons
			public static USGallon USGallons(this Byte input) => new USGallon(input);
			public static USGallon USGallons(this Int16 input) => new USGallon(input);
			public static USGallon USGallons(this Int32 input) => new USGallon(input);
			public static USGallon USGallons(this Int64 input) => new USGallon(input);
			public static USGallon USGallons(this Single input) => new USGallon(input);
			public static USGallon USGallons(this Double input) => new USGallon(input);
			#endregion
		}
	}
}
