using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
	namespace UnitsOfMeasurement
	{
		public static partial class Pressures
		{
			public class Atmosphere : Pressure, IAtmosphere
			{
				#region CTOR
				public Atmosphere(double value) : base(value, Conversion.Atmosphere, Suffixes.Atmosphere) { }
				#endregion
				#region Operators
				public static Atmosphere operator +(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
				{
					return new Atmosphere((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()));
				}
				public static Atmosphere operator -(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
				{
					return new Atmosphere((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()));
				}
				public static Atmosphere operator *(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
				{
					return new Atmosphere((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()));
				}
				public static Atmosphere operator /(Atmosphere firstMeasurement, Atmosphere secondMeasurement)
				{
					return new Atmosphere((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()));
				}
				#endregion
			}
			#region [Number].Atmospheres
			public static Atmosphere Atmospheres(this Byte input) => new Atmosphere(input);
			public static Atmosphere Atmospheres(this Int16 input) => new Atmosphere(input);
			public static Atmosphere Atmospheres(this Int32 input) => new Atmosphere(input);
			public static Atmosphere Atmospheres(this Int64 input) => new Atmosphere(input);
			public static Atmosphere Atmospheres(this Single input) => new Atmosphere(input);
			public static Atmosphere Atmospheres(this Double input) => new Atmosphere(input);
			#endregion
		}
	}
}
