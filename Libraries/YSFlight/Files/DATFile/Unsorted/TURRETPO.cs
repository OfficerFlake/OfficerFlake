using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETPO : DATProperty, IDAT_3_Parameters<UInt32, IPoint3, IOrientation3>
	{
		public TURRETPO(UInt32 value1, IPoint3 value2, IOrientation3 value3) : base("TURRETPO" + " " + value1 + " " + value2 + " " + value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}

		public UInt32 Value1 { get; set; }
		public IPoint3 Value2 { get; set; }
		public IOrientation3 Value3 { get; set; }
	}
}
