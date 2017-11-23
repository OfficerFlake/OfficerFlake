using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class PROPELLR : DAT_Power
    {
        public PROPELLR(Power value) : base("PROPELLR", value)
        {
        }
    }
}
