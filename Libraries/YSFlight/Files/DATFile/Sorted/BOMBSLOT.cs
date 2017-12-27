using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class BOMBSLOT : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public BOMBSLOT(IPoint3 value) : base("BOMBSLOT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
