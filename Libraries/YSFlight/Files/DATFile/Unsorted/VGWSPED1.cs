using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VGWSPED1 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public VGWSPED1(ISpeed value) : base("VGWSPED1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
