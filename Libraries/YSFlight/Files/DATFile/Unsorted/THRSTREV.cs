using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class THRSTREV : DATProperty, IDAT_1_Parameter<Single>
	{
		public THRSTREV(Single value) : base("THRSTREV" + " " + value)
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
