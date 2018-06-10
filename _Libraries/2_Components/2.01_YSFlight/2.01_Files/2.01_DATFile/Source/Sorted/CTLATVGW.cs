using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLATVGW : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public CTLATVGW(Boolean value) : base("CTLATVGW" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
