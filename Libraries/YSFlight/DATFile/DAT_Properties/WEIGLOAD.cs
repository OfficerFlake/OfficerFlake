using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WEIGLOAD : DAT_Mass
    {
        public WEIGLOAD(Mass value) : base("WEIGLOAD", value)
        {
        }
    }
}
