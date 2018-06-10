using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CATEGORY : DATProperty, IDAT_1_Parameter<IYSTypeAircraftCategory>
	{
		public CATEGORY(IYSTypeAircraftCategory value) : base("CATEGORY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IYSTypeAircraftCategory Value { get; set; }
	}
}
