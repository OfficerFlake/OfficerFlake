using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXNMFLR : DATProperty, IDAT_1_Parameter<UInt32>
	{
		public MAXNMFLR(UInt32 value) : base("MAXNMFLR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public UInt32 Value { get; set; }
	}
}
