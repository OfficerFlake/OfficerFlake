using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SCRNCNTR : DATProperty, IDAT_2_Parameters<Single, Single>
	{
		public SCRNCNTR(Single value1, Single value2) : base("SCRNCNTR" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public Single Value1 { get; set; }
		public Single Value2 { get; set; }
	}
}
