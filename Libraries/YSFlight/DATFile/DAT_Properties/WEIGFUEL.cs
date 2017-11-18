using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using static Com.OfficerFlake.Libraries.YSFlight.Files.DAT.PropertyTypes;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties
{
    public class WEIGFUEL : DAT_Mass
    {
        public WEIGFUEL(Mass value) : base("WEIGFUEL", value)
        {
        }
    }
}
