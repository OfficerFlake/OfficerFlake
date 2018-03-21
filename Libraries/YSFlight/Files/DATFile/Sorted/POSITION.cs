using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class POSITION : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public POSITION(ICoordinate3 value) : base("POSITION" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
