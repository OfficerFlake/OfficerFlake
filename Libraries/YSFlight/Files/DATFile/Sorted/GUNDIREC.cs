﻿using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GUNDIREC : DATProperty, IDAT_1_Parameter<IVector3>
	{
		public GUNDIREC(IVector3 value) : base("GUNDIREC" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IVector3 Value { get; set; }
	}
}
