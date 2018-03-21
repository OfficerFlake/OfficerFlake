using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WHELGEAR : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public WHELGEAR(ICoordinate3 value) : base("WHELGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
