using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETAR : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public TURRETAR(UInt32 value) : base("TURRETAR" + " " + value)
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
