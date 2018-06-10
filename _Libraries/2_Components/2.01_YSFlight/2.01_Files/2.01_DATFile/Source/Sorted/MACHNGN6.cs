using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MACHNGN6 : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public MACHNGN6(ICoordinate3 value) : base("MACHNGN6" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
