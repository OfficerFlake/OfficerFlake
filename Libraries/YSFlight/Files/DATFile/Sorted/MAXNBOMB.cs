﻿using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNBOMB : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNBOMB(UInt32 value) : base("MAXNBOMB" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
