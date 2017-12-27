using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITAAMM : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public INITAAMM(UInt32 value) : base("INITAAMM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
