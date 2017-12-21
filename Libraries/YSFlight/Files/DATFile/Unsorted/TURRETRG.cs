using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TURRETRG : DATProperty, IDAT_2_Parameters<UInt32, IDistance>
	{
		public TURRETRG(UInt32 value1, IDistance value2) : base("TURRETRG" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public UInt32 Value1 { get; set; }
		public IDistance Value2 { get; set; }
	}
}
