using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMROLL : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public PSTMROLL(IAngle value) : base("PSTMROLL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
