using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FUELMILI : DATProperty, IDAT_1_Parameter<IMass>
	{
		public FUELMILI(IMass value) : base("FUELMILI" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
