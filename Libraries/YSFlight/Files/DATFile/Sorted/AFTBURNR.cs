using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class AFTBURNR : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public AFTBURNR(Boolean value) : base("AFTBURNR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
