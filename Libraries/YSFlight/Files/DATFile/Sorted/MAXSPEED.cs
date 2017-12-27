using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXSPEED : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public MAXSPEED(ISpeed value) : base("MAXSPEED" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
