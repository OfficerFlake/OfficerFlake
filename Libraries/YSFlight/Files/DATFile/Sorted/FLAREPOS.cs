using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class FLAREPOS : DATProperty, IDAT_2_Parameters<IPoint3, IVector3>
	{
		public FLAREPOS(IPoint3 value1, IVector3 value2) : base("FLAREPOS" + " " + value1 + " " + value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public IPoint3 Value1 { get; set; }
		public IVector3 Value2 { get; set; }
	}
}
