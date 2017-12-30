using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class PressureExtensions
	{
		#region Atmospheres
		public static IAtmosphere Atmospheres(this Byte input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this SByte input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this UInt16 input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this Int16 input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this UInt32 input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this Int32 input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this UInt64 input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this Int64 input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this Single input) => ObjectFactory.CreateAtmosphere(input);
		public static IAtmosphere Atmospheres(this Double input) => ObjectFactory.CreateAtmosphere(input);
		#endregion
		#region Bars
		public static IBar Bars(this Byte input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this SByte input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this UInt16 input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this Int16 input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this UInt32 input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this Int32 input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this UInt64 input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this Int64 input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this Single input) => ObjectFactory.CreateBar(input);
		public static IBar Bars(this Double input) => ObjectFactory.CreateBar(input);
		#endregion
		#region KiloPascals
		public static IKiloPascal KiloPascals(this Byte input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this SByte input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this UInt16 input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this Int16 input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this UInt32 input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this Int32 input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this UInt64 input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this Int64 input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this Single input) => ObjectFactory.CreateKiloPascal(input);
		public static IKiloPascal KiloPascals(this Double input) => ObjectFactory.CreateKiloPascal(input);
		#endregion
		#region MilliMetersOfMercury
		public static IMilliMeterOfMercury MilliMetersOfMercury(this Byte input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this SByte input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this UInt16 input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this Int16 input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this UInt32 input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this Int32 input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this UInt64 input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this Int64 input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this Single input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		public static IMilliMeterOfMercury MilliMetersOfMercury(this Double input) => ObjectFactory.CreateMilliMeterOfMercury(input);
		#endregion
		#region Pascals
		public static IPascal Pascals(this Byte input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this SByte input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this UInt16 input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this Int16 input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this UInt32 input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this Int32 input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this UInt64 input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this Int64 input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this Single input) => ObjectFactory.CreatePascal(input);
		public static IPascal Pascals(this Double input) => ObjectFactory.CreatePascal(input);
		#endregion
		#region PoundsPerSquareInch
		public static IPoundPerSquareInch PoundsPerSquareInch(this Byte input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this SByte input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this UInt16 input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this Int16 input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this UInt32 input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this Int32 input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this UInt64 input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this Int64 input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this Single input) => ObjectFactory.CreatePoundPerSquareInch(input);
		public static IPoundPerSquareInch PoundsPerSquareInch(this Double input) => ObjectFactory.CreatePoundPerSquareInch(input);
		#endregion
	}
}