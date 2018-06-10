using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FLAPPOSI : DATProperty, IDAT_1_Parameter<Single>
	{
		public FLAPPOSI(Single value) : base("FLAPPOSI" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
