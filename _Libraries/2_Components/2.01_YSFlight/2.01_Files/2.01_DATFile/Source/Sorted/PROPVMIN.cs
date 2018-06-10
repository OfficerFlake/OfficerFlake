using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PROPVMIN : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public PROPVMIN(ISpeed value) : base("PROPVMIN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
