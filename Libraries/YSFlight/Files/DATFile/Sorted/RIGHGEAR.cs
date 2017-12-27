using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class RIGHGEAR : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public RIGHGEAR(IPoint3 value) : base("RIGHGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
