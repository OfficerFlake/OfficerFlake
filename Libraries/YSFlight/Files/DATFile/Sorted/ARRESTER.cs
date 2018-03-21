using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ARRESTER : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public ARRESTER(ICoordinate3 value) : base("ARRESTER" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
