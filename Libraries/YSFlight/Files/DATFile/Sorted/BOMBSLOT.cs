using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class BOMBSLOT : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public BOMBSLOT(ICoordinate3 value) : base("BOMBSLOT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
