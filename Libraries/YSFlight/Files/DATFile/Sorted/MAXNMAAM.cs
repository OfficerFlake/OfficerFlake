using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNAAMM : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNAAMM(UInt32 value) : base("MAXNAAMM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
