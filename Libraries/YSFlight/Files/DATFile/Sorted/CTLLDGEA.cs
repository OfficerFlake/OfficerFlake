using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLLDGEA : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public CTLLDGEA(Boolean value) : base("CTLLDGEA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
