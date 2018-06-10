using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VGWSPED2 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public VGWSPED2(ISpeed value) : base("VGWSPED2" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
