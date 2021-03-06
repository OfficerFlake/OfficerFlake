﻿using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class NMTURRET : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public NMTURRET(UInt32 value) : base("NMTURRET" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
