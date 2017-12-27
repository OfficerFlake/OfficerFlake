using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WEIGLOAD : DATProperty, IDAT_1_Parameter<IMass>
	{
		public WEIGLOAD(IMass value) : base("WEIGLOAD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
