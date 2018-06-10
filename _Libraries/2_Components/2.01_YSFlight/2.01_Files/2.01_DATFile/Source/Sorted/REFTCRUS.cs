using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFTCRUS : DATProperty, IDAT_1_Parameter<Single>
	{
		public REFTCRUS(Single value) : base("REFTCRUS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
