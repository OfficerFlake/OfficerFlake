using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PSTMSPD1 : DATProperty, IDAT_1_Parameter<ISpeed>
	{
		public PSTMSPD1(ISpeed value) : base("PSTMSPD1" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public ISpeed Value { get; set; }
	}
}
