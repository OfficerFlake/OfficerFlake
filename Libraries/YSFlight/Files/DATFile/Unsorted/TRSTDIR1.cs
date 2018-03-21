using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRSTDIR1 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public TRSTDIR1(ICoordinate3 value) : base("TRSTDIR1" + " " + value)
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
