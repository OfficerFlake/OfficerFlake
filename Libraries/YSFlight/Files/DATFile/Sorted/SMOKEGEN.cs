using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SMOKEGEN : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public SMOKEGEN(ICoordinate3 value) : base("SMOKEGEN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
