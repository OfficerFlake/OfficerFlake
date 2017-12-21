using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class BOMINBAY : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public BOMINBAY(Boolean value) : base("BOMINBAY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
