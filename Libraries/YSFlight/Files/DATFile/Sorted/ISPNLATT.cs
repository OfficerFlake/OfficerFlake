using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ISPNLATT : DATProperty, IDAT_1_Parameter<IOrientation3>
	{
		public ISPNLATT(IOrientation3 value) : base("ISPNLATT" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IOrientation3 Value { get; set; }
	}
}
