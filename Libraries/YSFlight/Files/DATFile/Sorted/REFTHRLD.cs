using System;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.YSFlight.Files.DAT;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFTHRLD : DATProperty, IDAT_1_Parameter<Single>
	{
		public REFTHRLD(Single value) : base("REFTHRLD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
