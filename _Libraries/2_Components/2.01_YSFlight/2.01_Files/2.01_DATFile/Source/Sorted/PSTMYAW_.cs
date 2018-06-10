using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMYAW_ : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public PSTMYAW_(IAngle value) : base("PSTMYAW_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
