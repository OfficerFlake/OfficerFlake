using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CLBYFLAP : DATProperty, IDAT_1_Parameter<Single>
	{
		public CLBYFLAP(Single value) : base("CLBYFLAP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
