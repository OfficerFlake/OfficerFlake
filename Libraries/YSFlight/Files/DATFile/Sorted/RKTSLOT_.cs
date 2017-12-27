using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class RKTSLOT_ : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public RKTSLOT_(IPoint3 value) : base("RKTSLOT_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
