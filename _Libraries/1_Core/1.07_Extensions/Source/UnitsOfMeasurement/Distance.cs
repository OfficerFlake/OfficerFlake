using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class DistanceExtensions
	{
		#region CentiMeters
		public static ICentiMeter CentiMeters(this Byte input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this SByte input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this UInt16 input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this Int16 input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this UInt32 input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this Int32 input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this UInt64 input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this Int64 input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this Single input) => ObjectFactory.CreateCentiMeter(input);
		public static ICentiMeter CentiMeters(this Double input) => ObjectFactory.CreateCentiMeter(input);
		#endregion
		#region Feet
		public static IFoot Feet(this Byte input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this SByte input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this UInt16 input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this Int16 input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this UInt32 input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this Int32 input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this UInt64 input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this Int64 input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this Single input) => ObjectFactory.CreateFoot(input);
		public static IFoot Feet(this Double input) => ObjectFactory.CreateFoot(input);
		#endregion
		#region Inches
		public static IInch Inches(this Byte input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this SByte input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this UInt16 input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this Int16 input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this UInt32 input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this Int32 input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this UInt64 input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this Int64 input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this Single input) => ObjectFactory.CreateInch(input);
		public static IInch Inches(this Double input) => ObjectFactory.CreateInch(input);
		#endregion
		#region KiloMeters
		public static IKiloMeter KiloMeters(this Byte input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this SByte input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this UInt16 input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this Int16 input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this UInt32 input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this Int32 input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this UInt64 input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this Int64 input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this Single input) => ObjectFactory.CreateKiloMeter(input);
		public static IKiloMeter KiloMeters(this Double input) => ObjectFactory.CreateKiloMeter(input);
		#endregion
		#region Meters
		public static IMeter Meters(this Byte input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this SByte input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this UInt16 input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this Int16 input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this UInt32 input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this Int32 input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this UInt64 input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this Int64 input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this Single input) => ObjectFactory.CreateMeter(input);
		public static IMeter Meters(this Double input) => ObjectFactory.CreateMeter(input);
		#endregion
		#region Microns
		public static IMicron Microns(this Byte input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this SByte input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this UInt16 input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this Int16 input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this UInt32 input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this Int32 input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this UInt64 input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this Int64 input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this Single input) => ObjectFactory.CreateMicron(input);
		public static IMicron Microns(this Double input) => ObjectFactory.CreateMicron(input);
		#endregion
		#region Miles
		public static IMile Miles(this Byte input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this SByte input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this UInt16 input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this Int16 input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this UInt32 input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this Int32 input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this UInt64 input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this Int64 input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this Single input) => ObjectFactory.CreateMile(input);
		public static IMile Miles(this Double input) => ObjectFactory.CreateMile(input);
		#endregion
		#region MilliMeters
		public static IMilliMeter MilliMeters(this Byte input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this SByte input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this UInt16 input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this Int16 input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this UInt32 input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this Int32 input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this UInt64 input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this Int64 input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this Single input) => ObjectFactory.CreateMilliMeter(input);
		public static IMilliMeter MilliMeters(this Double input) => ObjectFactory.CreateMilliMeter(input);
		#endregion
		#region NanoMeters
		public static INanoMeter NanoMeters(this Byte input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this SByte input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this UInt16 input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this Int16 input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this UInt32 input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this Int32 input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this UInt64 input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this Int64 input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this Single input) => ObjectFactory.CreateNanoMeter(input);
		public static INanoMeter NanoMeters(this Double input) => ObjectFactory.CreateNanoMeter(input);
		#endregion
		#region NauticalMiles
		public static INauticalMile NauticalMiles(this Byte input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this SByte input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this UInt16 input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this Int16 input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this UInt32 input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this Int32 input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this UInt64 input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this Int64 input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this Single input) => ObjectFactory.CreateNauticalMile(input);
		public static INauticalMile NauticalMiles(this Double input) => ObjectFactory.CreateNauticalMile(input);
		#endregion
		#region Yards
		public static IYard Yards(this Byte input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this SByte input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this UInt16 input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this Int16 input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this UInt32 input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this Int32 input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this UInt64 input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this Int64 input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this Single input) => ObjectFactory.CreateYard(input);
		public static IYard Yards(this Double input) => ObjectFactory.CreateYard(input);
		#endregion
	}
}