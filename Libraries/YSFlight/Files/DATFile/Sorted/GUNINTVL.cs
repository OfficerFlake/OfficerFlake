using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GUNINTVL : DATProperty, IDAT_1_Parameter<Single>
	{
		public GUNINTVL(Single value) : base("GUNINTVL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
