using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GUNSIGHT : DATProperty, IDAT_1_Parameter<Boolean>
	{
		public GUNSIGHT(Boolean value) : base("GUNSIGHT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Boolean Value { get; set; }
	}
}
