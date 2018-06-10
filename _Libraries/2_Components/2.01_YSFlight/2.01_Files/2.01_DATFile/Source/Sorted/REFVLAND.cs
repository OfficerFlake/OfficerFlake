using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFVLAND : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public REFVLAND(ISpeed value) : base("REFVLAND" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
