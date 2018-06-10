using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class COCKPITA : DATProperty, IDAT_1_Parameter<IOrientation3>
	{
		public COCKPITA(IOrientation3 value) : base("COCKPITA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IOrientation3 Value { get; set; }
	}
}
