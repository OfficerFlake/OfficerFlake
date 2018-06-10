using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER1 : DATProperty, IDAT_1_Parameter<IYSTypeWeaponCategory>
	{
		public TRIGGER1(IYSTypeWeaponCategory value) : base("TRIGGER1" + " " + value)
		{
			Value = value;
		}

		public IYSTypeWeaponCategory Value { get; set; }
	}
}
