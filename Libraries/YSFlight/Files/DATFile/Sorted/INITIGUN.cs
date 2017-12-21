using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITIGUN : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public INITIGUN(UInt32 value) : base("INITIGUN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
