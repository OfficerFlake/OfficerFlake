using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class THRAFTBN : DATProperty, IDAT_1_Parameter<IMass>
	{
		public THRAFTBN(IMass value) : base("THRAFTBN" + " " + value)
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
