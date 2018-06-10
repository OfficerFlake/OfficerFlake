using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETGD : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public TURRETGD(UInt32 value) : base("TURRETGD" + " " + value)
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
