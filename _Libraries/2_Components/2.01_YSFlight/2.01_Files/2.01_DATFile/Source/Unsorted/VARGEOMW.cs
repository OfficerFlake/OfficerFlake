using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VARGEOMW : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public VARGEOMW(Boolean value) : base("VARGEOMW" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
