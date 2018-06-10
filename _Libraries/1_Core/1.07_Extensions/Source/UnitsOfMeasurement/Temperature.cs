using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class TemperatureExtensions
	{
		#region DegreesCelsius
		public static IDegreeCelsius DegreesCelsius(this Byte input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this SByte input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this UInt16 input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this Int16 input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this UInt32 input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this Int32 input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this UInt64 input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this Int64 input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this Single input) => ObjectFactory.CreateDegreeCelsius(input);
		public static IDegreeCelsius DegreesCelsius(this Double input) => ObjectFactory.CreateDegreeCelsius(input);
		#endregion
		#region DegreesFahrenheit
		public static IDegreeFahrenheit DegreesFahrenheit(this Byte input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this SByte input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this UInt16 input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this Int16 input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this UInt32 input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this Int32 input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this UInt64 input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this Int64 input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this Single input) => ObjectFactory.CreateDegreeFahrenheit(input);
		public static IDegreeFahrenheit DegreesFahrenheit(this Double input) => ObjectFactory.CreateDegreeFahrenheit(input);
		#endregion
		#region DegreeKelvins
		public static IDegreeKelvin DegreesKelvin(this Byte input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this SByte input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this UInt16 input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this Int16 input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this UInt32 input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this Int32 input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this UInt64 input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this Int64 input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this Single input) => ObjectFactory.CreateDegreeKelvin(input);
		public static IDegreeKelvin DegreesKelvin(this Double input) => ObjectFactory.CreateDegreeKelvin(input);
		#endregion
	}
}