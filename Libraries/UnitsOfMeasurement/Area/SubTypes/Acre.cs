using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Areas
		{
			public class Acre : Area, IAcre
			{
				#region CTOR
				public Acre(double value) : base(value, Conversion.Acre, Suffixes.Acre) { }
				#endregion
				#region Operators
				public static Acre operator +(Acre firstMeasurement, Acre secondMeasurement)
				{
					return new Acre((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Acre operator -(Acre firstMeasurement, Acre secondMeasurement)
				{
					return new Acre((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Acre operator *(Acre firstMeasurement, Acre secondMeasurement)
				{
					return new Acre((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Acre operator /(Acre firstMeasurement, Acre secondMeasurement)
				{
					return new Acre((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Acres
			public static Acre Acres(this Byte input) => new Acre(input);
			public static Acre Acres(this Int16 input) => new Acre(input);
			public static Acre Acres(this Int32 input) => new Acre(input);
			public static Acre Acres(this Int64 input) => new Acre(input);
			public static Acre Acres(this Single input) => new Acre(input);
			public static Acre Acres(this Double input) => new Acre(input);
			#endregion
		}
	}
}
