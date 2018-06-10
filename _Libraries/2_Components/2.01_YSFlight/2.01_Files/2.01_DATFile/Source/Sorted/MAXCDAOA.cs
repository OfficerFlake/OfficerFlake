using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MAXCDAOA : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public MAXCDAOA(IAngle value) : base("MAXCDAOA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
