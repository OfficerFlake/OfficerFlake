using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class WHELGEAR : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public WHELGEAR(IPoint3 value) : base("WHELGEAR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
