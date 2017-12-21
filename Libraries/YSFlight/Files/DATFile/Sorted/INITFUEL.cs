using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITFUEL : DATProperty, IDAT_1_Parameter<Single>
	{
		public INITFUEL(Single value) : base("INITFUEL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
