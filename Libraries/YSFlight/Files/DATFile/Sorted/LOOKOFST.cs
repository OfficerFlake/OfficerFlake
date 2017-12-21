using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class LOOKOFST : DATProperty, IDAT_1_Parameter<IPoint3>
	{
		public LOOKOFST(IPoint3 value) : base("LOOKOFST" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPoint3 Value { get; set; }
	}
}
