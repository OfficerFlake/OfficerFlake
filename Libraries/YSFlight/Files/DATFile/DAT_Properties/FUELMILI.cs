using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class FUELMILI : DAT_Mass
    {
        public FUELMILI(Mass value) : base("FUELMILI", value)
        {
        }
    }
}
