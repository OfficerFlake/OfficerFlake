using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETIV : DATProperty, IDAT_2_Parameters<UInt32, IDuration>
	{
		public TURRETIV(UInt32 value1, IDuration value2) : base("TURRETIV" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public UInt32 Value1 { get; set; }
		public IDuration Value2 { get; set; }
	}
}
