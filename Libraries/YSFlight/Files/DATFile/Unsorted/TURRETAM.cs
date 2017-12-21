using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETAM : DATProperty, IDAT_2_Parameters<UInt32, UInt32>
	{
		public TURRETAM(UInt32 value1, UInt32 value2) : base("TURRETAM" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public UInt32 Value1 { get; set; }
		public UInt32 Value2 { get; set; }
	}
}
