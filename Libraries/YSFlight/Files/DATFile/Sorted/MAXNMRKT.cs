using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNMRKT : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNMRKT(UInt32 value) : base("MAXNMRKT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
