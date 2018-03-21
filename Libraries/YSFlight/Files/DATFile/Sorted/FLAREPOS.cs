using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FLAREPOS : DATProperty, IDAT_2_Parameters<ICoordinate3, ICoordinate3>
	{
		public FLAREPOS(ICoordinate3 value1, ICoordinate3 value2) : base("FLAREPOS" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public ICoordinate3 Value1 { get; set; }
		public ICoordinate3 Value2 { get; set; }
	}
}
