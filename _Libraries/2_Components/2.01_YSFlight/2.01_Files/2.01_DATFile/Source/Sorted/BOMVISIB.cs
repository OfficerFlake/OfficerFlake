using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class BOMVISIB : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public BOMVISIB(Boolean value) : base("BOMVISIB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
