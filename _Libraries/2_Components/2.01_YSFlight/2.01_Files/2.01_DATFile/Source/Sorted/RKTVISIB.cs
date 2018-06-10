
using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class RKTVISIB : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public RKTVISIB(Boolean value) : base("RKTVISIB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
