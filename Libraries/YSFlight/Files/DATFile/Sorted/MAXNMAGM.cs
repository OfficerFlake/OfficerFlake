using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNMAGM : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNMAGM(UInt32 value) : base("MAXNMAGM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
