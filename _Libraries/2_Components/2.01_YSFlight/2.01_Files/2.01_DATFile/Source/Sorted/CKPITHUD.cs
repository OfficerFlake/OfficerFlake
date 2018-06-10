using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CKPITHUD : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public CKPITHUD(Boolean value) : base("CKPITHUD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
