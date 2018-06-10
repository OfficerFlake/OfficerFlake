using Com.OfficerFlake.Libraries.Interfaces;
using System;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class PowerExtensions
	{
		#region BTUsPerMinute
		public static IBTUPerMinute BTUsPerMinute(this Byte input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this SByte input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this UInt16 input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this Int16 input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this UInt32 input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this Int32 input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this UInt64 input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this Int64 input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this Single input) => ObjectFactory.CreateBTUPerMinute(input);
		public static IBTUPerMinute BTUsPerMinute(this Double input) => ObjectFactory.CreateBTUPerMinute(input);
		#endregion
		#region FootPoundsPerMinute
		public static IFootPoundPerMinute FootPoundsPerMinute(this Byte input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this SByte input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this UInt16 input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this Int16 input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this UInt32 input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this Int32 input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this UInt64 input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this Int64 input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this Single input) => ObjectFactory.CreateFootPoundPerMinute(input);
		public static IFootPoundPerMinute FootPoundsPerMinute(this Double input) => ObjectFactory.CreateFootPoundPerMinute(input);
		#endregion
		#region KiloWatts
		public static IKiloWatt KiloWatts(this Byte input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this SByte input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this UInt16 input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this Int16 input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this UInt32 input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this Int32 input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this UInt64 input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this Int64 input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this Single input) => ObjectFactory.CreateKiloWatt(input);
		public static IKiloWatt KiloWatts(this Double input) => ObjectFactory.CreateKiloWatt(input);
		#endregion
		#region USHorsePower
		public static IUSHorsePower USHorsePower(this Byte input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this SByte input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this UInt16 input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this Int16 input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this UInt32 input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this Int32 input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this UInt64 input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this Int64 input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this Single input) => ObjectFactory.CreateUSHorsePower(input);
		public static IUSHorsePower USHorsePower(this Double input) => ObjectFactory.CreateUSHorsePower(input);
		#endregion
		#region Watts
		public static IWatt Watts(this Byte input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this SByte input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this UInt16 input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this Int16 input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this UInt32 input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this Int32 input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this UInt64 input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this Int64 input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this Single input) => ObjectFactory.CreateWatt(input);
		public static IWatt Watts(this Double input) => ObjectFactory.CreateWatt(input);
		#endregion
	}
}