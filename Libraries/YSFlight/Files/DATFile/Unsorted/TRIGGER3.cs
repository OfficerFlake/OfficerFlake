using System;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER3 : DATProperty, IDAT_1_Parameter<WeaponCategory>
	{
		public TRIGGER3(WeaponCategory value) : base("TRIGGER3" + " " + value)
		{
			Value = value;
		}

		public WeaponCategory Value { get; set; }
	}
}
