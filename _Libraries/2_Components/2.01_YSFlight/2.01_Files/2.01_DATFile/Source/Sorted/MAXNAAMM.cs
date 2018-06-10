using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNMAAM : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNMAAM(UInt32 value) : base("MAXNMAAM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
