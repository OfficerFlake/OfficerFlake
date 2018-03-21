using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MACHNGN5 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public MACHNGN5(ICoordinate3 value) : base("MACHNGN5" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
