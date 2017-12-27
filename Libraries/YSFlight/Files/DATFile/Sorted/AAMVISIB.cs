using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class AAMVISIB : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public AAMVISIB(Boolean value) : base("AAMVISIB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
