using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

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
