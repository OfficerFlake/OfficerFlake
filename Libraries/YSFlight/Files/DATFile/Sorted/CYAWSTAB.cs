using System;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CYAWSTAB : DATProperty, IDAT_1_Parameter<Single>
	{
		public CYAWSTAB(Single value) : base("CYAWSTAB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
