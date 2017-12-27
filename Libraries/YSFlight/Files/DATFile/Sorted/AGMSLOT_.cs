using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class AGMSLOT_ : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public AGMSLOT_(IPoint3 value) : base("AGMSLOT_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
