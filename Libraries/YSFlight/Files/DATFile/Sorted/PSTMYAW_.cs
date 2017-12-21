using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMYAW_ : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public PSTMYAW_(IAngle value) : base("PSTMYAW_" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
