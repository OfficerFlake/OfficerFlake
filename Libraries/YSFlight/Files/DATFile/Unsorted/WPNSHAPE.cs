using System;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WPNSHAPE : DATProperty, IDAT_3_Parameters<WeaponType, Boolean, String>
	{
		public WPNSHAPE(WeaponType value1, Boolean value2, String value3) : base("WPNSHAPE" + " " + value1 + " " + value2 + " " + value3)
		{
			Value1 = value1;
			Value2 = value2;
			Value3 = value3;
		}

		public WeaponType Value1 { get; set; }
		public Boolean Value2 { get; set; }
		public String Value3 { get; set; }
	}
}
