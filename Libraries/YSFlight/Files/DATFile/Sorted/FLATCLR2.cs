using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FLATCLR2 : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public FLATCLR2(IAngle value) : base("FLATCLR2" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
