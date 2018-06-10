using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFTHRLD : DATProperty, IDAT_1_Parameter<Single>
	{
		public REFTHRLD(Single value) : base("REFTHRLD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
