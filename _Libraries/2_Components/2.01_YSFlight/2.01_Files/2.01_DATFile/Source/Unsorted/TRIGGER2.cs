using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER2 : DATProperty, IDAT_1_Parameter<IYSTypeWeaponCategory>
	{
		public TRIGGER2(IYSTypeWeaponCategory value) : base("TRIGGER2" + " " + value)
		{
			Value = value;
		}

		public IYSTypeWeaponCategory Value { get; set; }
	}
}
