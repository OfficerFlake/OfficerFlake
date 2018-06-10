using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETPO : DATProperty, IDAT_3_Parameters<UInt32, ICoordinate3, IOrientation3>
	{
		public TURRETPO(UInt32 value1, ICoordinate3 value2, IOrientation3 value3) : base("TURRETPO" + " " + value1 + " " + value2 + " " + value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}

		public UInt32 Value1 { get; set; }
		public ICoordinate3 Value2 { get; set; }
		public IOrientation3 Value3 { get; set; }
	}
}
