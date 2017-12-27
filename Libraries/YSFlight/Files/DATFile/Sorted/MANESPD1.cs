using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MANESPD1 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public MANESPD1(ISpeed value) : base("MANESPD1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
