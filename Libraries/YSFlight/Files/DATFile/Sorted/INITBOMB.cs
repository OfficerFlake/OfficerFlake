using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITBOMB : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public INITBOMB(UInt32 value) : base("INITBOMB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
