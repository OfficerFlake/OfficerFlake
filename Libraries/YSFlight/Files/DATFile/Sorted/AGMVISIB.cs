using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class AGMVISIB : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public AGMVISIB(Boolean value) : base("AGMVISIB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
