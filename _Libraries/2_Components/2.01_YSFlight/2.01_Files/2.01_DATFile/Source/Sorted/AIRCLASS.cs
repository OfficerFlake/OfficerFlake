using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class AIRCLASS : DATProperty, IDAT_1_Parameter<String>
	{
		public AIRCLASS(String value) : base("AIRCLASS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public String Value { get; set; }
	}
}
