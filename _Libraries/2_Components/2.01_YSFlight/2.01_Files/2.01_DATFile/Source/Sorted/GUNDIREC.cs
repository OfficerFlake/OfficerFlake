using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class GUNDIREC : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public GUNDIREC(ICoordinate3 value) : base("GUNDIREC" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
