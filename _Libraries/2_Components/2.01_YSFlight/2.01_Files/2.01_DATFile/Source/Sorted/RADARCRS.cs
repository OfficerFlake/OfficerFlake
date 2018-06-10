using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class RADARCRS : DATProperty, IDAT_1_Parameter<Single>
	{
		public RADARCRS(Single value) : base("RADARCRS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
