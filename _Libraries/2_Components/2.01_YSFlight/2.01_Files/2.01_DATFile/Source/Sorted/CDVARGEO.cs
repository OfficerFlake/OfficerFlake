﻿using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CDVARGEO : DATProperty, IDAT_1_Parameter<Single>
	{
		public CDVARGEO(Single value) : base("CDVARGEO" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
