using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class STRENGTH : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public STRENGTH(UInt32 value) : base("STRENGTH" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
