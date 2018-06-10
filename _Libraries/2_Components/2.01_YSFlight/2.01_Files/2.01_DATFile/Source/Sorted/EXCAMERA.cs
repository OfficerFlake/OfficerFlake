using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class EXCAMERA : DATProperty, IDAT_4_Parameters<String, ICoordinate3, IOrientation3, Boolean>
	{
		public EXCAMERA(String value1, ICoordinate3 value2, IOrientation3 value3, Boolean value4) : base("EXCAMERA" + " " + value1 + " " + value2 + " " + value3 + " " + value4)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
			Value4 = value4;
		}

		public String Value1 { get; set; }
		public ICoordinate3 Value2 { get; set; }
		public IOrientation3 Value3 { get; set; }
		public Boolean Value4 { get; set; }
	}
}
