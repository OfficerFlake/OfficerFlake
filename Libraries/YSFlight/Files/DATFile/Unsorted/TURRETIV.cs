﻿using System;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETIV : DATProperty, IDAT_2_Parameters<UInt32, Single>
	{
		public TURRETIV(UInt32 value1, Single value2) : base("TURRETIV" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public UInt32 Value1 { get; set; }
		public Single Value2 { get; set; }
	}
}
