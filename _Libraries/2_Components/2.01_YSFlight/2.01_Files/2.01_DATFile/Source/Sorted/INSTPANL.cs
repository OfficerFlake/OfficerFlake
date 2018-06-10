using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INSTPANL : DATProperty, IDAT_1_Parameter<String>
	{
		public INSTPANL(String value) : base("INSTPANL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public String Value { get; set; }
	}
}
