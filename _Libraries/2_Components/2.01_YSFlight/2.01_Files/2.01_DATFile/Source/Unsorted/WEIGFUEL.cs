using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WEIGFUEL : DATProperty, IDAT_1_Parameter<IMass>
	{
		public WEIGFUEL(IMass value) : base("WEIGFUEL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
