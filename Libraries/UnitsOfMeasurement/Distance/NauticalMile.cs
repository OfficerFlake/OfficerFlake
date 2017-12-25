using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class NauticalMile : Distance, INauticalMile
			{
				#region CTOR
				public NauticalMile(double value) : base(value, Conversion.NauticalMile, Suffixes.NauticalMile) { }
				#endregion
				#region Operators
				public static NauticalMile operator +(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
				{
					return new NauticalMile((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static NauticalMile operator -(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
				{
					return new NauticalMile((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static NauticalMile operator *(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
				{
					return new NauticalMile((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static NauticalMile operator /(NauticalMile firstMeasurement, NauticalMile secondMeasurement)
				{
					return new NauticalMile((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].NauticalMiles
			public static NauticalMile NauticalMiles(this Byte input) => new NauticalMile(input);
			public static NauticalMile NauticalMiles(this Int16 input) => new NauticalMile(input);
			public static NauticalMile NauticalMiles(this Int32 input) => new NauticalMile(input);
			public static NauticalMile NauticalMiles(this Int64 input) => new NauticalMile(input);
			public static NauticalMile NauticalMiles(this Single input) => new NauticalMile(input);
			public static NauticalMile NauticalMiles(this Double input) => new NauticalMile(input);
			#endregion
		}
	}
}
