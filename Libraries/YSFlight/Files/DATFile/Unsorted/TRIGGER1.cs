namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRIGGER1 : DATProperty, IDAT_1_Parameter<WeaponCategory>
	{
		public TRIGGER1(WeaponCategory value) : base("TRIGGER1" + " " + value)
		{
			Value = value;
		}

		public WeaponCategory Value { get; set; }
	}
}
