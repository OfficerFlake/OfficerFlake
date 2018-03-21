using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LEFTGEAR : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public LEFTGEAR(ICoordinate3 value) : base("LEFTGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
