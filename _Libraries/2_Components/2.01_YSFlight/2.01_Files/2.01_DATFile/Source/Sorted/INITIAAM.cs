using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITIAAM : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public INITIAAM(UInt32 value) : base("INITIAAM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
