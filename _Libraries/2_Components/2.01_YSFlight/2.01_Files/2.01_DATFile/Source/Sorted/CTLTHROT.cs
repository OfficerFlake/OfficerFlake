using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CTLTHROT : DATProperty, IDAT_1_Parameter<Single>
	{
		public CTLTHROT(Single value) : base("CTLTHROT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
