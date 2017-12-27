using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MACHNGUN : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public MACHNGUN(IPoint3 value) : base("MACHNGUN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
