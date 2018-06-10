using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLINVGW : DATProperty, IDAT_1_Parameter<Single>
	{
		public CTLINVGW(Single value) : base("CTLINVGW" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
