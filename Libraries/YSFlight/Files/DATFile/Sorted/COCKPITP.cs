﻿using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class COCKPITP : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public COCKPITP(IPoint3 value) : base("COCKPITP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
