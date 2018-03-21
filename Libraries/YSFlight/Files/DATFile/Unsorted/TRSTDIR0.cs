using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRSTDIR0 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public TRSTDIR0(ICoordinate3 value) : base("TRSTDIR0" + " " + value)
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
