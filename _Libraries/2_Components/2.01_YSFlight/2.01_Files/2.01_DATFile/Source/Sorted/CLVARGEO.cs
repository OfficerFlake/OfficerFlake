using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CLVARGEO : DATProperty, IDAT_1_Parameter<Single>
	{
		public CLVARGEO(Single value) : base("CLVARGEO" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
