using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MANESPD2 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public MANESPD2(ISpeed value) : base("MANESPD2" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
