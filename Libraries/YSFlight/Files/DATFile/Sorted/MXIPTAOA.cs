using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MXIPTAOA : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public MXIPTAOA(IAngle value) : base("MXIPTAOA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
