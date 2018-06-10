using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CRITSPED : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public CRITSPED(ISpeed value) : base("CRITSPED" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
