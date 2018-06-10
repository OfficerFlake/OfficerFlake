using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CDSPOILR : DATProperty, IDAT_1_Parameter<Single>
	{
		public CDSPOILR(Single value) : base("CDSPOILR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
