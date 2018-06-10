using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFVCRUS : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public REFVCRUS(ISpeed value) : base("REFVCRUS" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
