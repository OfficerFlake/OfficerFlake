using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ISPNLSCL : DATProperty, IDAT_1_Parameter<Single>
	{
		public ISPNLSCL(Single value) : base("ISPNLSCL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
