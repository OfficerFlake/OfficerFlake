using System;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LOADWEPN : DATProperty, IDAT_2_Parameters<WeaponType, UInt32>
	{
		public LOADWEPN(WeaponType weaponType, UInt32 quantity) : base("LOADWEPN" + " " + weaponType + " " + quantity)
		{
			Value1 = weaponType;
			Value2 = quantity;
		}

		public WeaponType Value1 { get; set; }
		public UInt32 Value2 { get; set; }
	}
}
