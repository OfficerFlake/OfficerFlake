using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class EXCAMERA : DATProperty, IDAT_3_Parameters<String, IPoint3, IOrientation3>
	{
		public EXCAMERA(String value1, IPoint3 value2, IOrientation3 value3) : base("EXCAMERA" + " " + value1 + " " + value2 + " " + value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}

		public String Value1 { get; set; }
		public IPoint3 Value2 { get; set; }
		public IOrientation3 Value3 { get; set; }
	}
}
