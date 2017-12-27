using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITRCKT : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public INITRCKT(UInt32 value) : base("INITRCKT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
