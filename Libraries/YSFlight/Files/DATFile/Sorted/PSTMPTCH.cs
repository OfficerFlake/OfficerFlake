using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMPTCH : DATProperty, IDAT_1_Parameter<IAngle>
	{
		public PSTMPTCH(IAngle value) : base("PSTMPTCH" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IAngle Value { get; set; }
	}
}
