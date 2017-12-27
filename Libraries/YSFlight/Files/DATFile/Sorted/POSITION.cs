using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class POSITION : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public POSITION(IPoint3 value) : base("POSITION" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
