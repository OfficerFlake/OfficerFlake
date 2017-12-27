using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LEFTGEAR : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public LEFTGEAR(IPoint3 value) : base("LEFTGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
