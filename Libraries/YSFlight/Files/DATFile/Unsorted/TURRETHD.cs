using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETHD : DATProperty, IDAT_2_Parameters<UInt32, IOrientation3>
	{
		public TURRETHD(UInt32 value1, IOrientation3 value2) : base("TURRETHD" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public UInt32 Value1 { get; set; }
		public IOrientation3 Value2 { get; set; }
	}
}
