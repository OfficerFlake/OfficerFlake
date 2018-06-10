using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GUNPOWER : DATProperty, IDAT_1_Parameter<Single>
	{
		public GUNPOWER(Single value) : base("GUNPOWER" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
