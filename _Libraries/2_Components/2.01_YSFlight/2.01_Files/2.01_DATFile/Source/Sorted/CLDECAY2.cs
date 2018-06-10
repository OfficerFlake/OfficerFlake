using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CLDECAY2 : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public CLDECAY2(IAngle value) : base("CLDECAY2" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
