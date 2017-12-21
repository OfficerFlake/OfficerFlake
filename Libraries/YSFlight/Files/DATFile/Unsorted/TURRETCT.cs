using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETCT : DATProperty, IDAT_2_Parameters<UInt32, String>
	{
		public TURRETCT(UInt32 value1, String value2) : base("TURRETCT" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public UInt32 Value1 { get; set; }
		public String Value2 { get; set; }
	}
}
