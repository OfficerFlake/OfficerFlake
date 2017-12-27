using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MXIPTROL : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public MXIPTROL(IAngle value) : base("MXIPTROL" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
