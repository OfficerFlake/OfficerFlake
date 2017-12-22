using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CDBYGEAR : DATProperty, IDAT_1_Parameter<Single>
	{
		public CDBYGEAR(Single value) : base("CDBYGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
