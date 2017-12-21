using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class REFLNRWY : DATProperty, IDAT_1_Parameter<IDistance>
	{
		public REFLNRWY(IDistance value) : base("REFLNRWY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IDistance Value { get; set; }
	}
}
