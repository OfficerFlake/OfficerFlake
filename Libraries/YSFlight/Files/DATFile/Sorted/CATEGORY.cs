using System.Linq;
using Com.OfficerFlake.Libraries.YSFlight.Types;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
	public class CATEGORY : DATProperty, IDAT_1_Parameter<AircraftCategory>
	{
		public CATEGORY(AircraftCategory value) : base("CATEGORY" + " " + string.Join(" ", value))
		{
			Value = value;
		}

		public AircraftCategory Value { get; set; }
	}
}
