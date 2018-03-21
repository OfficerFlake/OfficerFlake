using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LOOKOFST : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public LOOKOFST(ICoordinate3 value) : base("LOOKOFST" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
