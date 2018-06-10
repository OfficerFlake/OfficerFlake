using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNMFLR : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNMFLR(UInt32 value) : base("MAXNMFLR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
