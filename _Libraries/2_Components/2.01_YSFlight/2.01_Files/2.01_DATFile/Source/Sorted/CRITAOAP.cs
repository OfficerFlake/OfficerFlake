using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CRITAOAP : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public CRITAOAP(IAngle value) : base("CRITAOAP" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
