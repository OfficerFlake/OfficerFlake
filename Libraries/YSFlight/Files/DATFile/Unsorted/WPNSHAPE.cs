using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WPNSHAPE : DATProperty, IDAT_3_Parameters<IYSTypeWeaponType, Boolean, String>
	{
		public WPNSHAPE(IYSTypeWeaponType value1, Boolean value2, String value3) : base("WPNSHAPE" + " " + value1 + " " + value2 + " " + value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}

		public IYSTypeWeaponType Value1 { get; set; }
		public Boolean Value2 { get; set; }
		public String Value3 { get; set; }
	}
}
