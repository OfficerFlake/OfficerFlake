using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITLOAD : DATProperty, IDAT_1_Parameter<IMass>
	{
		public INITLOAD(IMass value) : base("INITLOAD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
