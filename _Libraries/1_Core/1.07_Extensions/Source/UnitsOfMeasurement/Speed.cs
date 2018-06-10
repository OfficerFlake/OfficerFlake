using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class SpeedExtensions
	{
		#region CentiMetersPerSecond
		public static ICentiMeterPerSecond CentiMetersPerSecond(this Byte input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this SByte input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this UInt16 input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this Int16 input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this UInt32 input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this Int32 input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this UInt64 input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this Int64 input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this Single input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		public static ICentiMeterPerSecond CentiMetersPerSecond(this Double input) => ObjectFactory.CreateCentiMeterPerSecond(input);
		#endregion
		#region FeetPerSecond
		public static IFootPerSecond FeetPerSecond(this Byte input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this SByte input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this UInt16 input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this Int16 input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this UInt32 input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this Int32 input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this UInt64 input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this Int64 input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this Single input) => ObjectFactory.CreateFootPerSecond(input);
		public static IFootPerSecond FeetPerSecond(this Double input) => ObjectFactory.CreateFootPerSecond(input);
		#endregion
		#region KiloMetersPerHour
		public static IKiloMeterPerHour KiloMetersPerHour(this Byte input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this SByte input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this UInt16 input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this Int16 input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this UInt32 input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this Int32 input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this UInt64 input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this Int64 input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this Single input) => ObjectFactory.CreateKiloMeterPerHour(input);
		public static IKiloMeterPerHour KiloMetersPerHour(this Double input) => ObjectFactory.CreateKiloMeterPerHour(input);
		#endregion
		#region Knots
		public static IKnot Knots(this Byte input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this SByte input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this UInt16 input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this Int16 input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this UInt32 input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this Int32 input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this UInt64 input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this Int64 input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this Single input) => ObjectFactory.CreateKnot(input);
		public static IKnot Knots(this Double input) => ObjectFactory.CreateKnot(input);
		#endregion
		#region MachAtSeaLevel
		public static IMachAtSeaLevel MachAtSeaLevel(this Byte input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this SByte input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this UInt16 input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this Int16 input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this UInt32 input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this Int32 input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this UInt64 input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this Int64 input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this Single input) => ObjectFactory.CreateMachAtSeaLevel(input);
		public static IMachAtSeaLevel MachAtSeaLevel(this Double input) => ObjectFactory.CreateMachAtSeaLevel(input);
		#endregion
		#region MetersPerSecond
		public static IMeterPerSecond MetersPerSecond(this Byte input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this SByte input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this UInt16 input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this Int16 input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this UInt32 input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this Int32 input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this UInt64 input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this Int64 input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this Single input) => ObjectFactory.CreateMeterPerSecond(input);
		public static IMeterPerSecond MetersPerSecond(this Double input) => ObjectFactory.CreateMeterPerSecond(input);
		#endregion
		#region MilesPerHour
		public static IMilePerHour MilesPerHour(this Byte input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this SByte input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this UInt16 input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this Int16 input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this UInt32 input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this Int32 input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this UInt64 input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this Int64 input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this Single input) => ObjectFactory.CreateMilePerHour(input);
		public static IMilePerHour MilesPerHour(this Double input) => ObjectFactory.CreateMilePerHour(input);
		#endregion
		#region MilliMetersPerSecond
		public static IMilliMeterPerSecond MilliMetersPerSecond(this Byte input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this SByte input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this UInt16 input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this Int16 input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this UInt32 input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this Int32 input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this UInt64 input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this Int64 input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this Single input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		public static IMilliMeterPerSecond MilliMetersPerSecond(this Double input) => ObjectFactory.CreateMilliMeterPerSecond(input);
		#endregion
	}
}