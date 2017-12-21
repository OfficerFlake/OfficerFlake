using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class INITLOAD : DATProperty, IDAT_1_Parameter<IMass>
	{
		public INITLOAD(IMass value) : base("INITLOAD" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IMass Value { get; set; }
	}
}
