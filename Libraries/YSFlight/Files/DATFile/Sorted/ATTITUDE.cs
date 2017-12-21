using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class ATTITUDE : DATProperty, IDAT_1_Parameter<IOrientation3>
	{
		public ATTITUDE(IOrientation3 value) : base("ATTITUDE" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IOrientation3 Value { get; set; }
	}
}
