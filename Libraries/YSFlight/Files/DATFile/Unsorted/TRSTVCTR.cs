using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRSTVCTR : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public TRSTVCTR(Boolean value) : base("TRSTVCTR" + " " + value)
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
