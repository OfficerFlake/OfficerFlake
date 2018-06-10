using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class BMBAYRCS : DATProperty, IDAT_1_Parameter<Single>
	{
		public BMBAYRCS(Single value) : base("BMBAYRCS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
