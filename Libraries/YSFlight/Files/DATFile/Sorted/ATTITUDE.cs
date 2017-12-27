using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ATTITUDE : DATProperty, IDAT_1_Parameter<IOrientation3>
	{
		public ATTITUDE(IOrientation3 value) : base("ATTITUDE" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IOrientation3 Value { get; set; }
	}
}
