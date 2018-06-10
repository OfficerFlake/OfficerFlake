using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MACHNGN8 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public MACHNGN8(ICoordinate3 value) : base("MACHNGN8" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
