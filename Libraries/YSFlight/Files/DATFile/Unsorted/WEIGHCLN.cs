using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WEIGHCLN : DATProperty, IDAT_1_Parameter<IMass>
	{
		public WEIGHCLN(IMass value) : base("WEIGHCLN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
