using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class HASSPOIL : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public HASSPOIL(Boolean value) : base("HASSPOIL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
