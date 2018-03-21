using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class AGMSLOT_ : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public AGMSLOT_(ICoordinate3 value) : base("AGMSLOT_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
