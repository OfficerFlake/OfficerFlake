using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class INITLOAD : DAT_Mass
    {
        public INITLOAD(Mass value) : base("INITLOAD", value)
        {
        }
    }
}
