using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class COCKPITP : DATProperty, IDAT_1_Parameter<ICoordinate3>
	{
		public COCKPITP(ICoordinate3 value) : base("COCKPITP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ICoordinate3 Value { get; set; }
	}
}
