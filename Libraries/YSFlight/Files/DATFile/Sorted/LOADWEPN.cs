using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LOADWEPN : DATProperty, IDAT_2_Parameters<IYSTypeWeaponType, UInt32>
	{
		public LOADWEPN(IYSTypeWeaponType IYSTypeWeaponType, UInt32 quantity) : base("LOADWEPN" + " " + IYSTypeWeaponType + " " + quantity)
		{
			Value1 = IYSTypeWeaponType;
			Value2 = quantity;
		}

		public IYSTypeWeaponType Value1 { get; set; }
		public UInt32 Value2 { get; set; }
	}
}
