using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class THRMILIT : DATProperty, IDAT_1_Parameter<IMass>
	{
		public THRMILIT(IMass value) : base("THRMILIT" + " " + value)
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
