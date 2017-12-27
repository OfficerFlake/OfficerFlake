using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class VAPORPO0 : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public VAPORPO0(IPoint3 value) : base("VAPORPO0" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
