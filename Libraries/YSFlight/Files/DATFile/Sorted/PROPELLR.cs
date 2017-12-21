using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class PROPELLR : DATProperty, IDAT_1_Parameter<IPower>
	{
		public PROPELLR(IPower value) : base("PROPELLR" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public IPower Value { get; set; }
	}
}
