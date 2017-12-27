using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class SMOKEGEN : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public SMOKEGEN(IPoint3 value) : base("SMOKEGEN" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
