using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GEARHORN : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public GEARHORN(Boolean value) : base("GEARHORN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
