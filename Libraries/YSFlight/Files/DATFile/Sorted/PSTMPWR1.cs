using System;

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
