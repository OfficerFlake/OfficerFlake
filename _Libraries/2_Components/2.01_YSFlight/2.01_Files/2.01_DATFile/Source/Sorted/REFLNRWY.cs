using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFLNRWY : DATProperty, IDAT_1_Parameter<IDistance>
	{
		public REFLNRWY(IDistance value) : base("REFLNRWY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IDistance Value { get; set; }
	}
}
