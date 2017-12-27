using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SMOKECOL : DATProperty, IDAT_2_Parameters<Byte, I24BitColor>
	{
		public SMOKECOL(Byte value1, I24BitColor value2) : base("SMOKECOL" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public Byte Value1 { get; set; }
		public I24BitColor Value2 { get; set; }
	}
}
