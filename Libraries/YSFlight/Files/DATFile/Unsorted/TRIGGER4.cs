using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class TRIGGER4 : DATProperty, IDAT_1_Parameter<IYSTypeWeaponCategory>
	{
		public TRIGGER4(IYSTypeWeaponCategory value) : base("TRIGGER4" + " " + value)
		{
			Value = value;
		}

		public IYSTypeWeaponCategory Value { get; set; }
	}
}
