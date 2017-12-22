using System;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRIGGER4 : DATProperty, IDAT_1_Parameter<WeaponCategory>
	{
		public TRIGGER4(WeaponCategory value) : base("TRIGGER4" + " " + value)
		{
			Value = value;
		}

		public WeaponCategory Value { get; set; }
	}
}
