using System;
using Com.OfficerFlake.Libraries.IO;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMPWR1 : DATProperty, IDAT_1_Parameter<Single>
	{
		public PSTMPWR1(Single value) : base("PSTMPWR1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public Single Value { get; set; }
	}
}
