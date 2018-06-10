using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class RIGHGEAR : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public RIGHGEAR(ICoordinate3 value) : base("RIGHGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
