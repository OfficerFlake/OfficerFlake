using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLABRNR : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public CTLABRNR(Boolean value) : base("CTLABRNR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
