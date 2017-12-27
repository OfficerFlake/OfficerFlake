using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLIFLAP : DATProperty, IDAT_1_Parameter<Single>
	{
		public CTLIFLAP(Single value) : base("CTLIFLAP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
