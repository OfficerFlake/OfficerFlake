using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMPTCH : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public PSTMPTCH(IAngle value) : base("PSTMPTCH" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
