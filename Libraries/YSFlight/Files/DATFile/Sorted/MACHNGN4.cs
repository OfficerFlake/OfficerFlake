using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MACHNGN4 : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public MACHNGN4(IPoint3 value) : base("MACHNGN4" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
