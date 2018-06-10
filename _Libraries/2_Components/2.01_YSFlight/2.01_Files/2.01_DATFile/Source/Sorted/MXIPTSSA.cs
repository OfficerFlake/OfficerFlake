using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MXIPTSSA : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public MXIPTSSA(IAngle value) : base("MXIPTSSA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
