using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CRITAOAM : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public CRITAOAM(IAngle value) : base("CRITAOAM" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
