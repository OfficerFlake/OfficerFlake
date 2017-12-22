using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CDBYFLAP : DATProperty, IDAT_1_Parameter<Single>
	{
		public CDBYFLAP(Single value) : base("CDBYFLAP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
