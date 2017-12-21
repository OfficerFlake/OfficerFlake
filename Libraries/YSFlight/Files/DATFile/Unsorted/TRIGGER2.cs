﻿using System;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER2 : DATProperty, IDAT_1_Parameter<String>
	{
		public TRIGGER2(String value) : base("TRIGGER2" + " " + value)
		{
			Value = value;
		}

		public String Value { get; set; }
	}
}