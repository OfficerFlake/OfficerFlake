using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VRGMNOSE : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public VRGMNOSE(Boolean value) : base("VRGMNOSE" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
