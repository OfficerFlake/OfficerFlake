using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LMTBYHDP : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public LMTBYHDP(Boolean value) : base("LMTBYHDP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
