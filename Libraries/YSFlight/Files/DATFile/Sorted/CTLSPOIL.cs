using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLSPOIL : DATProperty, IDAT_1_Parameter<Single>
	{
		public CTLSPOIL(Single value) : base("CTLSPOIL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
