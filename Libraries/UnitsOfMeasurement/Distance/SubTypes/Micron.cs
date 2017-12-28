using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Distances
		{
			public class Micron : Distance, IMicron
			{
				#region CTOR
				public Micron(double value) : base(value, Conversion.Micron, Suffixes.Micron) { }
				#endregion
				#region Operators
				public static Micron operator +(Micron firstMeasurement, Micron secondMeasurement)
				{
					return new Micron((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Micron operator -(Micron firstMeasurement, Micron secondMeasurement)
				{
					return new Micron((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Micron operator *(Micron firstMeasurement, Micron secondMeasurement)
				{
					return new Micron((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Micron operator /(Micron firstMeasurement, Micron secondMeasurement)
				{
					return new Micron((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Microns
			public static Micron Microns(this Byte input) => new Micron(input);
			public static Micron Microns(this Int16 input) => new Micron(input);
			public static Micron Microns(this Int32 input) => new Micron(input);
			public static Micron Microns(this Int64 input) => new Micron(input);
			public static Micron Microns(this Single input) => new Micron(input);
			public static Micron Microns(this Double input) => new Micron(input);
			#endregion
		}
	}
}
