using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CLDECAY1 : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public CLDECAY1(IAngle value) : base("CLDECAY1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
