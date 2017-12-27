using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SMOKEOIL : DATProperty, IDAT_1_Parameter<IMass>
	{
		public SMOKEOIL(IMass value) : base("SMOKEOIL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
