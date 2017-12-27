using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FLATCLR1 : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public FLATCLR1(IAngle value) : base("FLATCLR1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
