using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class IDENTIFY : DATProperty, IDAT_1_Parameter<String>
	{
		public IDENTIFY(String value) : base("IDENTIFY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public String Value { get; set; }
	}
}
