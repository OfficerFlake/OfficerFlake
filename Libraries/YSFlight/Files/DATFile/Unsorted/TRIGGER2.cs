namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER2 : DATProperty, IDAT_1_Parameter<WeaponCategory>
	{
		public TRIGGER2(WeaponCategory value) : base("TRIGGER2" + " " + value)
		{
			Value = value;
		}

		public WeaponCategory Value { get; set; }
	}
}
