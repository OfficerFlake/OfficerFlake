using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WEAPONCH : DATProperty, IDAT_1_Parameter<IYSTypeWeaponCategory>
	{
		public WEAPONCH(IYSTypeWeaponCategory value) : base("WEAPONCH" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IYSTypeWeaponCategory Value { get; set; }
	}
}
