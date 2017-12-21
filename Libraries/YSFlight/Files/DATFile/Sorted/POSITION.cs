using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

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
