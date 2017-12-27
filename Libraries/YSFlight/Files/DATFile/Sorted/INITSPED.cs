using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITSPED : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public INITSPED(ISpeed value) : base("INITSPED" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
