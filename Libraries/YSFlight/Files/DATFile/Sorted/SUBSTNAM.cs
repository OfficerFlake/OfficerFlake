using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SUBSTNAM : DATProperty, IDAT_1_Parameter<String>
	{
		public SUBSTNAM(String value) : base("SUBSTNAM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public String Value { get; set; }
	}
}
