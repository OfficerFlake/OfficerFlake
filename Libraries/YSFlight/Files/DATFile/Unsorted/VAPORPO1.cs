using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VAPORPO1 : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public VAPORPO1(IPoint3 value) : base("VAPORPO1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
