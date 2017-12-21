using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class MXIPTSSA : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public MXIPTSSA(IAngle value) : base("MXIPTSSA" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
