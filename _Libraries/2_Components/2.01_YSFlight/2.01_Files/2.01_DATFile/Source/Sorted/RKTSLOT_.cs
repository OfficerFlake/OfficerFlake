using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class RKTSLOT_ : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public RKTSLOT_(ICoordinate3 value) : base("RKTSLOT_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
