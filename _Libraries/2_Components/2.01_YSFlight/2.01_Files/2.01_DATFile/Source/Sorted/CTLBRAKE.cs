using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLBRAKE : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public CTLBRAKE(Boolean value) : base("CTLBRAKE" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
