namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CATEGORY : DATProperty, IDAT_1_Parameter<AircraftCategory>
	{
		public CATEGORY(AircraftCategory value) : base("CATEGORY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public AircraftCategory Value { get; set; }
	}
}
