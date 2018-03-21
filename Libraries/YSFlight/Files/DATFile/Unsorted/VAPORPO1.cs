using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VAPORPO1 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public VAPORPO1(ICoordinate3 value) : base("VAPORPO1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
