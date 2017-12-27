using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ISPNLHUD : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public ISPNLHUD(Boolean value) : base("ISPNLHUD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
