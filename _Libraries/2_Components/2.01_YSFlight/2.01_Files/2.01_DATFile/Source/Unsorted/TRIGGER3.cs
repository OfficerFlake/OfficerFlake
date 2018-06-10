using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER3 : DATProperty, IDAT_1_Parameter<IYSTypeWeaponCategory>
	{
		public TRIGGER3(IYSTypeWeaponCategory value) : base("TRIGGER3" + " " + value)
		{
			Value = value;
		}

		public IYSTypeWeaponCategory Value { get; set; }
	}
}
