using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class TRSTDIR0 : DATProperty, IDAT_1_Parameter<IVector3>
	{
		public TRSTDIR0(IVector3 value) : base("TRSTDIR0" + " " + value)
		{
			Value = value;
		}

		public IVector3 Value { get; set; }
	}
}
