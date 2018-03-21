using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MACHNGN2 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public MACHNGN2(ICoordinate3 value) : base("MACHNGN2" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
