using Com.OfficerFlake.Libraries.Interfaces;


namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FUELABRN : DATProperty, IDAT_1_Parameter<IMass>
	{
		public FUELABRN(IMass value) : base("FUELABRN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
